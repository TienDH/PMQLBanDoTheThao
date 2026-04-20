using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PMQLBanDoTheThao.Controller
{
    public class HoaDonController
    {
        // 1. LẤY TẤT CẢ HÓA ĐƠN (GetAll)
        public List<HoaDon> GetAllHoaDons()
        {
            const string sql = @"
                SELECT o.Id, o.UserId, u.FullName AS UserName, o.OrderDate, o.TotalAmount
                FROM Orders o
                LEFT JOIN Users u ON o.UserId = u.Id
                ORDER BY o.Id DESC";

            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToHoaDonList(dt);
        }

        // 1b. Lấy 1 hóa đơn theo Id (kèm chi tiết nếu cần)
        public HoaDon GetHoaDonById(int id)
        {
            const string sql = @"
                SELECT o.Id, o.UserId, u.FullName AS UserName, o.OrderDate, o.TotalAmount
                FROM Orders o
                LEFT JOIN Users u ON o.UserId = u.Id
                WHERE o.Id = @id";

            var p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToHoaDonList(dt);
            var hoaDon = list.Count > 0 ? list[0] : null;
            if (hoaDon != null)
            {
                hoaDon.OrderDetails = GetOrderDetailsByOrderId(hoaDon.Id);
            }
            return hoaDon;
        }

        // 2. THÊM MỚI HÓA ĐƠN (Add) - Bao gồm cả lưu Chi tiết và Trừ kho
        // Trả về bool để giữ tương thích; xử lý trong transaction, kiểm tra tồn kho trước khi trừ.
        public bool AddHoaDon(HoaDon hoaDon, List<ChiTietHoaDon> chiTiets)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 2.1 Chèn Orders (trả về Id mới)
                        const string sqlOrder = "INSERT INTO Orders (UserId, OrderDate, TotalAmount) OUTPUT INSERTED.Id VALUES (@uid, @date, @total)";
                        using (var cmdOrder = new SqlCommand(sqlOrder, conn, trans))
                        {
                            cmdOrder.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int) { Value = hoaDon.UserId });
                            cmdOrder.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime) { Value = DateTime.Now });
                            var pTotal = new SqlParameter("@total", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = hoaDon.TotalAmount };
                            cmdOrder.Parameters.Add(pTotal);

                            var obj = cmdOrder.ExecuteScalar();
                            if (obj == null)
                                throw new Exception("Failed to insert order.");

                            int newOrderId = Convert.ToInt32(obj);

                            // 2.2 Trước khi chèn chi tiết, validate tồn kho cho từng biến thể
                            foreach (var item in chiTiets)
                            {
                                const string sqlCheck = "SELECT Quantity FROM ProductVariant WHERE Id = @pvid";
                                using (var cmdCheck = new SqlCommand(sqlCheck, conn, trans))
                                {
                                    cmdCheck.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                    var currentQtyObj = cmdCheck.ExecuteScalar();
                                    if (currentQtyObj == null)
                                        throw new Exception($"ProductVariant {item.ProductVariantId} not found.");

                                    int currentQty = Convert.ToInt32(currentQtyObj);
                                    if (item.Quantity <= 0)
                                        throw new Exception("Quantity must be greater than 0.");

                                    if (currentQty < item.Quantity)
                                        throw new Exception($"Insufficient stock for ProductVariant {item.ProductVariantId}. Available: {currentQty}, Requested: {item.Quantity}");
                                }

                                // 2.3 Lưu chi tiết
                                const string sqlDetail = "INSERT INTO OrderDetail (OrderId, ProductVariantId, Quantity, Price) VALUES (@oid, @pvid, @qty, @prc)";
                                using (var cmdDetail = new SqlCommand(sqlDetail, conn, trans))
                                {
                                    cmdDetail.Parameters.Add(new SqlParameter("@oid", SqlDbType.Int) { Value = newOrderId });
                                    cmdDetail.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                    cmdDetail.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int) { Value = item.Quantity });
                                    var pPrice = new SqlParameter("@prc", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = item.Price };
                                    cmdDetail.Parameters.Add(pPrice);

                                    cmdDetail.ExecuteNonQuery();
                                }

                                // 2.4 Trừ kho
                                const string sqlUpdateStock = "UPDATE ProductVariant SET Quantity = Quantity - @qty WHERE Id = @pvid";
                                using (var cmdStock = new SqlCommand(sqlUpdateStock, conn, trans))
                                {
                                    cmdStock.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int) { Value = item.Quantity });
                                    cmdStock.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                    cmdStock.ExecuteNonQuery();
                                }
                            } // end foreach

                            trans.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        try { trans.Rollback(); } catch { }
                        Trace.WriteLine(ex);
                        return false;
                    }
                }
            }
        }

        // 3. SỬA HÓA ĐƠN (Update) - Cập nhật tổng tiền hoặc ngày
        public bool UpdateHoaDon(HoaDon hoaDon)
        {
            const string sql = "UPDATE Orders SET TotalAmount = @total, OrderDate = @date WHERE Id = @id";
            var pId = new SqlParameter("@id", SqlDbType.Int) { Value = hoaDon.Id };
            var pTotal = new SqlParameter("@total", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = hoaDon.TotalAmount };
            var pDate = new SqlParameter("@date", SqlDbType.DateTime) { Value = hoaDon.OrderDate };

            return DBConnection.ExecuteNonQuery(sql, new[] { pId, pTotal, pDate }) > 0;
        }

        // 4. XÓA HÓA ĐƠN (Delete) - Phải khôi phục tồn kho trong transaction
        public bool DeleteHoaDon(int hoaDonId)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 4.1 Lấy danh sách OrderDetail để khôi phục tồn kho
                        const string sqlSelectDetails = "SELECT ProductVariantId, Quantity FROM OrderDetail WHERE OrderId = @id";
                        var details = new List<Tuple<int, int>>();
                        using (var cmdSel = new SqlCommand(sqlSelectDetails, conn, trans))
                        {
                            cmdSel.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = hoaDonId });
                            using (var rdr = cmdSel.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    details.Add(Tuple.Create(Convert.ToInt32(rdr["ProductVariantId"]), Convert.ToInt32(rdr["Quantity"])));
                                }
                            }
                        }

                        // 4.2 Khôi phục tồn kho
                        const string sqlRestore = "UPDATE ProductVariant SET Quantity = Quantity + @qty WHERE Id = @pvid";
                        foreach (var d in details)
                        {
                            using (var cmdRestore = new SqlCommand(sqlRestore, conn, trans))
                            {
                                cmdRestore.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int) { Value = d.Item2 });
                                cmdRestore.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = d.Item1 });
                                cmdRestore.ExecuteNonQuery();
                            }
                        }

                        // 4.3 Xóa chi tiết
                        const string sqlDelDetail = "DELETE FROM OrderDetail WHERE OrderId = @id";
                        using (var cmdDelDet = new SqlCommand(sqlDelDetail, conn, trans))
                        {
                            cmdDelDet.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = hoaDonId });
                            cmdDelDet.ExecuteNonQuery();
                        }

                        // 4.4 Xóa hóa đơn chính
                        const string sqlDelOrder = "DELETE FROM Orders WHERE Id = @id";
                        using (var cmdDelOrder = new SqlCommand(sqlDelOrder, conn, trans))
                        {
                            cmdDelOrder.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = hoaDonId });
                            int result = cmdDelOrder.ExecuteNonQuery();
                            if (result <= 0)
                                throw new Exception("Delete order failed.");
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { trans.Rollback(); } catch { }
                        Trace.WriteLine(ex);
                        return false;
                    }
                }
            }
        }

        // 5. TÌM KIẾM HÓA ĐƠN
        public List<HoaDon> SearchHoaDons(string keyword)
        {
            const string sql = @"
                SELECT o.Id, o.UserId, u.FullName AS UserName, o.OrderDate, o.TotalAmount
                FROM Orders o
                LEFT JOIN Users u ON o.UserId = u.Id
                WHERE CAST(o.Id AS VARCHAR(50)) LIKE @key OR u.FullName LIKE @key
                ORDER BY o.Id DESC";

            var pKey = new SqlParameter("@key", SqlDbType.NVarChar, 200) { Value = "%" + keyword + "%" };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { pKey });
            return ConvertToHoaDonList(dt);
        }

        // Lấy chi tiết hóa đơn (OrderDetail) kèm thông tin tên sản phẩm, size, color
        public List<ChiTietHoaDon> GetOrderDetailsByOrderId(int orderId)
        {
            const string sql = @"
                SELECT od.Id, od.OrderId, od.ProductVariantId, pv.Quantity AS CurrentStock, od.Quantity, od.Price,
                       p.Name AS ProductName, s.Name AS SizeName, c.Name AS ColorName
                FROM OrderDetail od
                LEFT JOIN ProductVariant pv ON od.ProductVariantId = pv.Id
                LEFT JOIN Product p ON pv.ProductId = p.Id
                LEFT JOIN Size s ON pv.SizeId = s.Id
                LEFT JOIN Color c ON pv.ColorId = c.Id
                WHERE od.OrderId = @orderId";

            var p = new SqlParameter("@orderId", SqlDbType.Int) { Value = orderId };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });

            var list = new List<ChiTietHoaDon>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietHoaDon
                {
                    Id = Convert.ToInt32(row["Id"]),
                    OrderId = Convert.ToInt32(row["OrderId"]),
                    ProductVariantId = Convert.ToInt32(row["ProductVariantId"]),
                    ProductName = row["ProductName"] == DBNull.Value ? string.Empty : row["ProductName"].ToString(),
                    SizeName = row["SizeName"] == DBNull.Value ? string.Empty : row["SizeName"].ToString(),
                    ColorName = row["ColorName"] == DBNull.Value ? string.Empty : row["ColorName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Price = Convert.ToDecimal(row["Price"])
                });
            }

            return list;
        }

        // Hàm chuyển đổi DataTable -> List<HoaDon>
        private List<HoaDon> ConvertToHoaDonList(DataTable dt)
        {
            var list = new List<HoaDon>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HoaDon
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    UserName = row["UserName"].ToString(),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"])
                });
            }
            return list;
        }
    }
}