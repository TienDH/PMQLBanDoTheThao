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
<<<<<<< HEAD

        private static string strcon = @"Data Source=.;Initial Catalog=QL_BanHang;Integrated Security=True";
=======
        private static readonly string strcon = @"Data Source=LAPTOP-LU61T8RJ;Initial Catalog=QL_BanHang;Integrated Security=True;TrustServerCertificate=True";
>>>>>>> feature/ql-loai-sp

        public static SqlConnection GetDBConnection()
        {
            // Sửa lại biến truyền vào là strcon
            return new SqlConnection(strcon);
        }

        // Hàm thực thi SQL (Thêm, Xóa, Sửa)
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

        // Hàm trả về DataTable (Dùng cho hiển thị danh sách và tìm kiếm)
        public static DataTable GetDataTable(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Quan trọng: Mở kết nối trước khi Fill dữ liệu
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
