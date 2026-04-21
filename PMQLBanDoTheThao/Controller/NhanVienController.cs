using System;
using System.Data;
using System.Data.SqlClient;
using PMQLBanDoTheThao.DataBase;
using BCrypt.Net;

namespace PMQLBanDoTheThao.Controller
{
    public class NhanVienController
    {
        // Khởi tạo đối tượng kết nối Database

        /// <summary>
        /// 1. Lấy danh sách tất cả nhân viên và quyền hạn
        /// </summary>
        public DataTable GetAllUsers()
        {
            string sql = "SELECT Id, Username, Role, CanManageProduct, CanManageInvoice, CanManageStaff, CanSeeStatistic FROM [User]";
            return DBConnection.GetDataTable(sql);
        }

        /// <summary>
        /// 2. Thêm nhân viên mới kèm phân quyền động
        /// </summary>
        public bool AddUser(string user, string pass, string role, bool sp, bool hd, bool nv, bool tk)
        {
            // Sử dụng tham số @ để tránh SQL Injection
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pass);

            string sql = "INSERT INTO [User] (Username, [Password], Role, CanManageProduct, CanManageInvoice, CanManageStaff, CanSeeStatistic) " +
                         "VALUES (@u, @p, @r, @sp, @hd, @nv, @tk)";

            SqlParameter[] sqlParams = {
        new SqlParameter("@u", user.Trim()),
        new SqlParameter("@p", hashedPassword), // Sử dụng biến đã mã hóa thay vì pass gốc
        new SqlParameter("@r", role),
        new SqlParameter("@sp", sp),
        new SqlParameter("@hd", hd),
        new SqlParameter("@nv", nv),
        new SqlParameter("@tk", tk)
    };

            return DBConnection.ExecuteNonQuery(sql, sqlParams) > 0;
        }

        /// <summary>
        /// 3. Cập nhật thông tin, chức vụ và quyền hạn nhân viên
        /// </summary>
        public bool UpdateUser(int id, string role, bool sp, bool hd, bool nv, bool tk)
        {
            string sql = "UPDATE [User] SET Role=@r, CanManageProduct=@sp, CanManageInvoice=@hd, " +
                         "CanManageStaff=@nv, CanSeeStatistic=@tk WHERE Id=@id";

            SqlParameter[] sqlParams = {
                new SqlParameter("@id", id),
                new SqlParameter("@r", role),
                new SqlParameter("@sp", sp),
                new SqlParameter("@hd", hd),
                new SqlParameter("@nv", nv),
                new SqlParameter("@tk", tk)
            };

            return DBConnection.ExecuteNonQuery(sql, sqlParams) > 0;
        }

        /// <summary>
        /// 4. Xóa nhân viên (Chặn xóa tài khoản Admin để bảo mật hệ thống)
        /// </summary>
        public bool DeleteUser(int id)
        {
            // Điều kiện Role != 'Admin' giúp ngăn việc vô tình xóa mất tài khoản quản trị cao nhất
            string sql = "DELETE FROM [User] WHERE Id=@id AND Role <> 'Admin'";

            SqlParameter[] sqlParams = {
                new SqlParameter("@id", id)
            };

            return DBConnection.ExecuteNonQuery(sql, sqlParams) > 0;
        }
    }
}