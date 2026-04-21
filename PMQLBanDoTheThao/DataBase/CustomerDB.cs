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
        // ĐÃ XÓA chuỗi connectionString ở đây!

        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();

            // ĐÃ ĐỔI: Gọi DBConnection.GetDBConnection() dùng chung của toàn dự án
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                string query = "SELECT * FROM Customer";
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
            using (SqlConnection conn = DBConnection.GetDBConnection())
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
            using (SqlConnection conn = DBConnection.GetDBConnection())
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
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                string query = "INSERT INTO Customer (Name, Phone, Address) VALUES (@name, @phone, @addr)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", cus.Name);
                cmd.Parameters.AddWithValue("@phone", cus.Phone);
                cmd.Parameters.AddWithValue("@addr", cus.Address);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Đã tích hợp luôn hàm tìm kiếm cho bạn ở đây
        public List<Customer> TimKiemKhachHang(string tuKhoa)
        {
            List<Customer> list = new List<Customer>();
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                string query = "SELECT * FROM Customer WHERE Name LIKE @tuKhoa OR Phone LIKE @tuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");
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
    }
}