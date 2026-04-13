using System;
using System.Data;
using System.Data.SqlClient;
using PMQLBanDoTheThao.DataBase;
using BCrypt.Net;

namespace PMQLBanDoTheThao.Controller
{
    public class NhanVienController
    {
        public DataTable GetAllUsers()
        {
            string sql = "SELECT Id, Username, [Password], Role FROM [User]";
            return DBConnection.GetDataTable(sql);
        }

        /// <summary>
        /// 2. Thêm nhân viên - ĐÃ XÓA CÁC BIẾN QUYỀN THỪA
        /// </summary>
        public bool AddUser(string user, string pass, string role)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pass);

            string sql = "INSERT INTO [User] (Username, [Password], Role) VALUES (@u, @p, @r)";

            SqlParameter[] sqlParams = {
                new SqlParameter("@u", user.Trim()),
                new SqlParameter("@p", hashedPassword),
                new SqlParameter("@r", role)
            };

            return DBConnection.ExecuteNonQuery(sql, sqlParams) > 0;
        }

        /// <summary>
        /// 3. Cập nhật nhân viên - ĐÃ XÓA CÁC BIẾN QUYỀN THỪA
        /// </summary>
        public bool UpdateUser(int id, string role)
        {
            string sql = "UPDATE [User] SET Role=@r WHERE Id=@id";

            SqlParameter[] sqlParams = {
                new SqlParameter("@id", id),
                new SqlParameter("@r", role)
            };

            return DBConnection.ExecuteNonQuery(sql, sqlParams) > 0;
        }

        public bool DeleteUser(int id)
        {
            string sql = "DELETE FROM [User] WHERE Id=@id AND Role <> 'Admin'";
            SqlParameter[] sqlParams = {
                new SqlParameter("@id", id)
            };
            return DBConnection.ExecuteNonQuery(sql, sqlParams) > 0;
        }
    }
}