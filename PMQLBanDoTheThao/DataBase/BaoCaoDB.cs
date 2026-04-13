using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.DataBase
{
    public class BaoCaoDB
    {
        public List<DoanhThuReport> GetDoanhThuTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            List<DoanhThuReport> list = new List<DoanhThuReport>();

            // Ép thời gian của 'Đến ngày' thành 23:59:59 để lấy trọn vẹn ngày cuối cùng
            DateTime denNgayCuoi = denNgay.Date.AddDays(1).AddTicks(-1);

            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                // Câu lệnh SQL: Lấy ngày (bỏ giờ phút) và tính tổng TotalAmount, nhóm theo ngày
                string query = @"
                    SELECT 
                        CAST(OrderDate AS DATE) AS Ngay,
                        SUM(TotalAmount) AS TongDoanhThu
                    FROM Orders
                    WHERE OrderDate >= @tuNgay AND OrderDate <= @denNgayCuoi
                    GROUP BY CAST(OrderDate AS DATE)
                    ORDER BY Ngay ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tuNgay", tuNgay.Date);
                cmd.Parameters.AddWithValue("@denNgayCuoi", denNgayCuoi);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DoanhThuReport
                    {
                        Ngay = Convert.ToDateTime(dr["Ngay"]),
                        TongDoanhThu = dr["TongDoanhThu"] != DBNull.Value ? Convert.ToDecimal(dr["TongDoanhThu"]) : 0
                    });
                }
            }
            return list;
        }
    }
}
