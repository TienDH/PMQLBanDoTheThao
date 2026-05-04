using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PMQLBanDoTheThao.Controller
{
    public class BaoCaoController
    {
        // ==============================================================
        // HÀM 1: LẤY DỮ LIỆU GỘP THEO NGÀY (DÙNG CHO CHART)
        // ==============================================================
        public List<DoanhThuReport> LayDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay.Date > denNgay.Date)
            {
                throw new Exception("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
            }

            DateTime denNgayCuoi = denNgay.Date.AddDays(1).AddTicks(-1);

            string sql = @"SELECT CAST(OrderDate AS DATE) AS Ngay, SUM(TotalAmount) AS TongDoanhThu 
                           FROM Orders 
                           WHERE OrderDate >= @tuNgay AND OrderDate <= @denNgay 
                           GROUP BY CAST(OrderDate AS DATE) 
                           ORDER BY Ngay ASC";

            SqlParameter[] pa = new SqlParameter[]
            {
                new SqlParameter("@tuNgay", tuNgay.Date),
                new SqlParameter("@denNgay", denNgayCuoi)
            };

            DataTable dt = DBConnection.GetDataTable(sql, pa);
            List<DoanhThuReport> danhSach = new List<DoanhThuReport>();

            foreach (DataRow row in dt.Rows)
            {
                danhSach.Add(new DoanhThuReport
                {
                    Ngay = Convert.ToDateTime(row["Ngay"]),
                    TongDoanhThu = row["TongDoanhThu"] != DBNull.Value ? Convert.ToDecimal(row["TongDoanhThu"]) : 0
                });
            }

            return danhSach;
        }

        // ==============================================================
        // HÀM 2: LẤY CHI TIẾT TỪNG ĐƠN HÀNG (DÙNG CHO DATAGRIDVIEW)
        // ==============================================================
        public List<OrderDetailReport> LayDanhSachDonHang(DateTime tuNgay, DateTime denNgay)
        {
            DateTime denNgayCuoi = denNgay.Date.AddDays(1).AddTicks(-1);

            string sql = @"
                SELECT 
                    o.Id AS OrderId, 
                    o.OrderDate, 
                    c.Name AS CustomerName, 
                    u.Username AS StaffName, 
                    o.TotalAmount
                FROM Orders o
                LEFT JOIN Customer c ON o.CustomerId = c.Id
                LEFT JOIN [User] u ON o.UserId = u.Id
                WHERE o.OrderDate >= @tuNgay AND o.OrderDate <= @denNgay
                ORDER BY o.OrderDate DESC";

            SqlParameter[] pa = new SqlParameter[]
            {
                new SqlParameter("@tuNgay", tuNgay.Date),
                new SqlParameter("@denNgay", denNgayCuoi)
            };

            DataTable dt = DBConnection.GetDataTable(sql, pa);
            List<OrderDetailReport> danhSach = new List<OrderDetailReport>();

            foreach (DataRow row in dt.Rows)
            {
                danhSach.Add(new OrderDetailReport
                {
                    OrderId = Convert.ToInt32(row["OrderId"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    CustomerName = row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : "Khách Lẻ",
                    StaffName = row["StaffName"].ToString(),
                    TotalAmount = row["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(row["TotalAmount"]) : 0
                });
            }

            return danhSach;
        }
    }
}