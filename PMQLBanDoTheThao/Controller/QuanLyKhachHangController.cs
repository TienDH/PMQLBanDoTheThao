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
                sql += " WHERE Name LIKE @key OR Phone LIKE @key OR Email LIKE @key";
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
                    Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : "",
                    // Kiểm tra NULL vì các khách hàng cũ chưa có Email
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : ""
                });
            }
            return danhSach;
        }

        public string XuLyThemKhachHang(Customer cus)
        {
            if (string.IsNullOrWhiteSpace(cus.Name) || string.IsNullOrWhiteSpace(cus.Phone))
                return "Tên và số điện thoại không được để trống!";

            // Thêm Email vào câu lệnh INSERT
            string sql = "INSERT INTO Customer (Name, Phone, Address, Email) VALUES (@name, @phone, @address, @email)";

            try
            {
                using (SqlConnection con = DBConnection.GetDBConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@name", cus.Name);
                    cmd.Parameters.AddWithValue("@phone", cus.Phone);
                    cmd.Parameters.AddWithValue("@address", cus.Address);
                    cmd.Parameters.AddWithValue("@email", cus.Email);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0 ? "Thêm thành công!" : "Không thể thêm.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.Contains("UNIQUE") ? "Số điện thoại đã tồn tại!" : "Lỗi: " + ex.Message;
            }
        }

        public string XuLySuaKhachHang(Customer cus)
        {
            // Thêm Email vào câu lệnh UPDATE
            string sql = "UPDATE Customer SET Name=@name, Phone=@phone, Address=@address, Email=@email WHERE Id=@id";

            using (SqlConnection con = DBConnection.GetDBConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", cus.Name);
                cmd.Parameters.AddWithValue("@phone", cus.Phone);
                cmd.Parameters.AddWithValue("@address", cus.Address);
                cmd.Parameters.AddWithValue("@email", cus.Email);
                cmd.Parameters.AddWithValue("@id", cus.Id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0 ? "Cập nhật thành công!" : "Thất bại.";
            }
        }

        public bool XuLyXoaKhachHang(int id)
        {
            string sql = "DELETE FROM Customer WHERE Id=@id";
            try
            {
                using (SqlConnection con = DBConnection.GetDBConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}