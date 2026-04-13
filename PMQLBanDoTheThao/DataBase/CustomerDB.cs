using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PMQLBanDoTheThao.Model;
namespace PMQLBanDoTheThao.DataBase
{
    public class CustomerDB
    {
        // Nhớ thay đổi Server Name cho đúng với máy bạn
        private string connectionString = @"Server=localhost;Database=QL_BanHang;Trusted_Connection=True;";

        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer"; // Tên bảng bạn vừa tạo
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Customer
                    {
                        Id = (int)dr["Id"],
                        Name = dr["Name"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Address = dr["Address"].ToString()
                    });
                }
            }
            return list;
        }
        public bool SuaKhachHang(Customer cus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customer SET Name = @name, Phone = @phone, Address = @addr WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", cus.Id);
                cmd.Parameters.AddWithValue("@name", cus.Name);
                cmd.Parameters.AddWithValue("@phone", cus.Phone);
                cmd.Parameters.AddWithValue("@addr", cus.Address);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaKhachHang(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customer WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool ThemKhachHang(Customer cus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Chỉ thêm Name, Phone, Address (Id tự tăng nhờ IDENTITY)
                string query = "INSERT INTO Customer (Name, Phone, Address) VALUES (@name, @phone, @addr)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", cus.Name);
                cmd.Parameters.AddWithValue("@phone", cus.Phone);
                cmd.Parameters.AddWithValue("@addr", cus.Address);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}