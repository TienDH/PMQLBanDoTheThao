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
<<<<<<< HEAD
        private static readonly string strcon = @"Data Source=LAPTOP-LU61T8RJ;Initial Catalog=QL_BanHang;Integrated Security=True;TrustServerCertificate=True";
=======
        private static string strcon = @"Data Source=.;Initial Catalog=QL_BanHang;Integrated Security=True";
>>>>>>> feature/ql-nhan-vien

        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(strcon);
        }

        //hàm thực thi SQL => ExecuteNonQuery
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
