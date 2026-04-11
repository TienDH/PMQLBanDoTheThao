using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PMQLBanDoTheThao.Model;
using BCrypt.Net;
using PMQLBanDoTheThao.DataBase;

namespace PMQLBanDoTheThao.Controller
{
    public class UserController
    {
        private const int BcryptWorkFactor = 12;

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
                return false;

            try
            {
                using (SqlConnection conn = DBConnection.GetDBConnection())
                {
                    conn.Open();
                    // Chỉ lấy các cột chắc chắn có trong DB: Id, Username, Password, Role
                    const string sql = "SELECT Id, Username, [Password], [Role] FROM [dbo].[User] WHERE Username = @user";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@user", SqlDbType.NVarChar, 256).Value = username.Trim();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read()) return false;

                            int userId = Convert.ToInt32(reader["Id"]);
                            string hashedPass = reader["Password"]?.ToString()?.Trim();
                            // Khai báo biến role ở đây để tránh lỗi CS0103
                            string role = reader["Role"] == DBNull.Value ? "Staff" : reader["Role"].ToString();

                            if (string.IsNullOrEmpty(hashedPass)) return false;

                            bool verified = false;
                            try
                            {
                                verified = BCrypt.Net.BCrypt.Verify(password, hashedPass);
                            }
                            catch { verified = false; }

                            if (verified)
                            {
                                // Gán dữ liệu vào Session
                                UserSession.CurrentUser = new User
                                {
                                    Id = userId,
                                    Username = username.Trim(),
                                    Role = role
                                };
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi chi tiết để debug
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CreateUser(string username, string plainPassword, string role = "Staff")
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(plainPassword))
                return false;

            try
            {
                using (SqlConnection conn = DBConnection.GetDBConnection())
                {
                    conn.Open();
                    string hash = BCrypt.Net.BCrypt.HashPassword(plainPassword, BcryptWorkFactor);

                    const string insertSql = "INSERT INTO [dbo].[User] (Username, [Password], [Role]) VALUES (@user, @pass, @role)";
                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.Add("@user", SqlDbType.NVarChar, 256).Value = username.Trim();
                        cmd.Parameters.Add("@pass", SqlDbType.NVarChar, -1).Value = hash;
                        cmd.Parameters.Add("@role", SqlDbType.NVarChar, 50).Value = role;

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        public DataTable GetAllUsers()
        {
            const string sql = "SELECT Id, Username, [Role] FROM [dbo].[User] ORDER BY Username";
            return DBConnection.GetDataTable(sql, null);
        }

        public bool UpdateRole(int userId, string newRole)
        {
            const string sql = "UPDATE [dbo].[User] SET [Role] = @role WHERE Id = @id";
            SqlParameter[] p = {
                new SqlParameter("@role", newRole),
                new SqlParameter("@id", userId)
            };
            return DBConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public bool DeleteUser(int userId)
        {
            const string sql = "DELETE FROM [dbo].[User] WHERE Id = @id";
            SqlParameter[] p = { new SqlParameter("@id", userId) };
            return DBConnection.ExecuteNonQuery(sql, p) > 0;
        }
    }
}