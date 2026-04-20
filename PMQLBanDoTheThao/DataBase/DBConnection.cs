using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.DataBase
{
    public class DBConnection
    {
        // 1. Đổi thành public để Controller thấy được
        // 2. Đổi tên thành ConnectionString cho khớp với code bạn đã viết ở Controller
        // 3. Trỏ vào Database độc lập QL_HoaDon_Module
        public static readonly string ConnectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=QL_HoaDon_Module;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Hàm thực thi SQL (Insert, Update, Delete)
        public static int ExecuteNonQuery(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                if (pa != null)
                    cmd.Parameters.AddRange(pa);

                return cmd.ExecuteNonQuery();
            }
        }

        // Hàm lấy dữ liệu (Đổ vào ComboBox, DataGridView)
        public static DataTable GetDataTable(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                if (pa != null)
                    cmd.Parameters.AddRange(pa);

                conn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}