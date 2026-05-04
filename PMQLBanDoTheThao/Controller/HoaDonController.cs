using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PMQLBanDoTheThao.Controller
{
    public class HoaDonController
    {
        // =========================
        // LOAD DATA
        // =========================

        public DataTable GetAllProducts()
        {
            string sql = "SELECT Id, Name FROM Product";
            return DBConnection.GetDataTable(sql);
        }

        public DataTable GetSizesByProduct(int productId)
        {
            string sql = @"SELECT DISTINCT s.Id, s.Name 
                           FROM Size s 
                           JOIN ProductVariant pv ON s.Id = pv.SizeId 
                           WHERE pv.ProductId = @id";

            return DBConnection.GetDataTable(sql,
                new SqlParameter[]
                {
                    new SqlParameter("@id", productId)
                });
        }

        public DataTable GetColorsByProduct(int productId)
        {
            string sql = @"SELECT DISTINCT c.Id, c.Name 
                           FROM Color c 
                           JOIN ProductVariant pv ON c.Id = pv.ColorId 
                           WHERE pv.ProductId = @id";

            return DBConnection.GetDataTable(sql,
                new SqlParameter[]
                {
                    new SqlParameter("@id", productId)
                });
        }

        public (int variantId, decimal price)? GetVariant(int productId, int sizeId, int colorId)
        {
            string sql = @"SELECT pv.Id, p.Price 
                           FROM ProductVariant pv 
                           JOIN Product p ON pv.ProductId = p.Id
                           WHERE pv.ProductId = @p AND pv.SizeId = @s AND pv.ColorId = @c";

            var dt = DBConnection.GetDataTable(sql,
                new SqlParameter[]
                {
                    new SqlParameter("@p", productId),
                    new SqlParameter("@s", sizeId),
                    new SqlParameter("@c", colorId)
                });

            if (dt.Rows.Count == 0) return null;

            return (
                Convert.ToInt32(dt.Rows[0]["Id"]),
                Convert.ToDecimal(dt.Rows[0]["Price"])
            );
        }

        // =========================
        // BUSINESS LOGIC
        // =========================

        public decimal TinhThanhTien(decimal donGia, int soLuong, int phanTramGiam)
        {
            decimal goc = donGia * soLuong;
            decimal giam = goc * phanTramGiam / 100;
            return goc - giam;
        }

        public decimal TinhTongTien(List<ChiTietHoaDon> list, int phanTramGiam)
        {
            decimal tong = 0;
            foreach (var item in list)
            {
                tong += TinhThanhTien(item.Price, item.Quantity, phanTramGiam);
            }
            return tong;
        }

        public (bool ok, string msg, int percent) ApplyVoucher(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return (false, "Chưa nhập mã", 0);

            string sql = "SELECT * FROM Voucher WHERE Code = @c";

            var dt = DBConnection.GetDataTable(sql,
                new SqlParameter[]
                {
                    new SqlParameter("@c", code)
                });

            if (dt.Rows.Count == 0)
                return (false, "Voucher không tồn tại", 0);

            DateTime exp = Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]);
            if (exp.Date < DateTime.Now.Date)
                return (false, "Voucher hết hạn", 0);

            int percent = Convert.ToInt32(dt.Rows[0]["DiscountPercent"]);
            return (true, "OK", percent);
        }

        // =========================
        // SAVE ORDER
        // =========================

        public bool SaveHoaDon(List<ChiTietHoaDon> list, decimal total)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert Order
                        string sqlOrder = @"INSERT INTO Orders (OrderDate, TotalAmount) 
                                            OUTPUT INSERTED.Id 
                                            VALUES (@d, @t)";

                        int orderId;

                        using (var cmd = new SqlCommand(sqlOrder, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@d", DateTime.Now);
                            cmd.Parameters.AddWithValue("@t", total);
                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        foreach (var item in list)
                        {
                            // Insert Detail
                            string sqlDetail = @"INSERT INTO OrderDetail 
(OrderId, ProductVariantId, Quantity, Price) 
VALUES (@o,@p,@q,@pr)";

                            using (var cmd = new SqlCommand(sqlDetail, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@o", orderId);
                                cmd.Parameters.AddWithValue("@p", item.ProductVariantId);
                                cmd.Parameters.AddWithValue("@q", item.Quantity);
                                cmd.Parameters.AddWithValue("@pr", item.Price);
                                cmd.ExecuteNonQuery();
                            }

                            // Trừ kho
                            string sqlStock = @"UPDATE ProductVariant 
                                                SET Quantity = Quantity - @q 
                                                WHERE Id = @id";

                            using (var cmd = new SqlCommand(sqlStock, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@q", item.Quantity);
                                cmd.Parameters.AddWithValue("@id", item.ProductVariantId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}