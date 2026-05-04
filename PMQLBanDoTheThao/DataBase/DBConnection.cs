using System;
using System.Data;
using System.Data.SqlClient;

namespace PMQLBanDoTheThao.DataBase
{
    internal class DBConnection
    {
        // Thống nhất sử dụng tên biến ConnectionString và Server máy bạn
        public static readonly string ConnectionString = @"Data Source=LAPTOP-LU61T8RJ;Initial Catalog=QL_BanHang;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetDBConnection()
        {
            // Trả về kết nối dựa trên ConnectionString chuẩn
            return new SqlConnection(ConnectionString);
        }

        // Hàm thực thi SQL (Insert, Update, Delete)
        public static int ExecuteNonQuery(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pa != null)
                        cmd.Parameters.AddRange(pa);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Hàm lấy dữ liệu (Đổ vào ComboBox, DataGridView, tìm kiếm)
        public static DataTable GetDataTable(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pa != null)
                        cmd.Parameters.AddRange(pa);

                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Hàm lấy một giá trị duy nhất (Ví dụ: Count, Sum)
        public static object ExecuteScalar(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pa != null)
                        cmd.Parameters.AddRange(pa);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}