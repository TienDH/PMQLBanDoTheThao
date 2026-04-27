using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.DataBase
{
    internal class DBConnection
    {

        // Thống nhất tên biến là ConnectionString để khớp với code ở các Controller mới
        // Bạn hãy kiểm tra lại Data Source và Initial Catalog sao cho đúng với máy của bạn nhé.
        // Tôi giữ lại Data Source của nhánh HEAD (LAPTOP-LU61T8RJ) vì có vẻ đây là máy chính của bạn.
        public static readonly string ConnectionString = @"Data Source=localhost\MSSQLSERVER01;Initial Catalog=QL_BanHang;Integrated Security=True";


        private static readonly string strcon = @"Data Source=LAPTOP-LU61T8RJ;Initial Catalog=QL_BanHang;Integrated Security=True;TrustServerCertificate=True";


        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(strcon);
        }

        // Hàm thực thi SQL (Insert, Update, Delete)
        public static int ExecuteNonQuery(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    if (pa != null)
                        cmd.Parameters.AddRange(pa);
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
                    conn.Open();
                    if (pa != null)
                        cmd.Parameters.AddRange(pa);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}