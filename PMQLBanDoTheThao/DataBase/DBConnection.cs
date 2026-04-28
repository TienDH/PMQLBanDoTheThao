using System;
using System.Data;
using System.Data.SqlClient;

namespace PMQLBanDoTheThao.DataBase
{
    public class DBConnection
    {
        private static readonly string strcon = @"Data Source=localhost;Initial Catalog=QL_BanHang;Integrated Security=True";

        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(strcon);
        }

        public static int ExecuteNonQuery(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (pa != null) cmd.Parameters.AddRange(pa);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }   

        public static DataTable GetDataTable(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                if (pa != null) cmd.Parameters.AddRange(pa);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static object ExecuteScalar(string sql, SqlParameter[] pa = null)
        {
            using (SqlConnection conn = GetDBConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (pa != null) cmd.Parameters.AddRange(pa);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}