using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PMQLBanDoTheThao.Model;
using PMQLBanDoTheThao.DataBase;

namespace PMQLBanDoTheThao.Controller
{
    public class QuanLyKhachHangController
    {
     
        public List<Customer> XuLyTimKiem(string tuKhoa)
        {
            List<Customer> danhSach = new List<Customer>();
            string sql = "SELECT * FROM Customer";
            SqlParameter[] pa = null;

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                sql += " WHERE Name LIKE @key OR Phone LIKE @key";
                pa = new SqlParameter[] { new SqlParameter("@key", "%" + tuKhoa.Trim() + "%") };
            }

            DataTable dt = DBConnection.GetDataTable(sql, pa);

            foreach (DataRow row in dt.Rows)
            {
                danhSach.Add(new Customer
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString()
                });
            }
            return danhSach;
        }

        // ==========================================
        // 2. THÊM KHÁCH HÀNG
        // ==========================================
        public string XuLyThemKhachHang(Customer cus)
        {
            if (string.IsNullOrWhiteSpace(cus.Name) || string.IsNullOrWhiteSpace(cus.Phone))
                return "Tên và số điện thoại không được để trống!";

            string sql = "INSERT INTO Customer (Name, Phone, Address) VALUES (@name, @phone, @address)";

            try
            {
                using (SqlConnection con = DBConnection.GetDBConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@name", cus.Name);
                    cmd.Parameters.AddWithValue("@phone", cus.Phone);
                    cmd.Parameters.AddWithValue("@address", cus.Address);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0 ? "Thêm thành công!" : "Không thể thêm.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.Contains("UNIQUE") ? "Số điện thoại đã tồn tại!" : "Lỗi: " + ex.Message;
            }
        }

        // ==========================================
        // 3. SỬA KHÁCH HÀNG
        // ==========================================
        public string XuLySuaKhachHang(Customer cus)
        {
            string sql = "UPDATE Customer SET Name=@name, Phone=@phone, Address=@address WHERE Id=@id";

            using (SqlConnection con = DBConnection.GetDBConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", cus.Name);
                cmd.Parameters.AddWithValue("@phone", cus.Phone);
                cmd.Parameters.AddWithValue("@address", cus.Address);
                cmd.Parameters.AddWithValue("@id", cus.Id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0 ? "Cập nhật thành công!" : "Thất bại.";
            }
        }

        // ==========================================
        // 4. XÓA KHÁCH HÀNG
        // ==========================================
        public bool XuLyXoaKhachHang(int id)
        {
            string sql = "DELETE FROM Customer WHERE Id=@id";
            using (SqlConnection con = DBConnection.GetDBConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}