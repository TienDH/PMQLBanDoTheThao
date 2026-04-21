using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PMQLBanDoTheThao.Controller
{
    public class QuanLyLoaiSanPhamController
    {
        public List<Category> GetAll()
        {
            string sql = "SELECT Id, CategoryName FROM Category ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);

            List<Category> list = new List<Category>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CategoryName = row["CategoryName"].ToString()
                });
            }
            return list;
        }

        public bool Add(string name)
        {
            string sql = "INSERT INTO Category (CategoryName) VALUES (@name)";
            SqlParameter[] pa =
            {
                new SqlParameter("@name", name)
            };

            return DBConnection.ExecuteNonQuery(sql, pa) > 0;
        }

        public bool Update(int id, string name)
        {
            string sql = "UPDATE Category SET CategoryName = @name WHERE Id = @id";
            SqlParameter[] pa =
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name)
            };

            return DBConnection.ExecuteNonQuery(sql, pa) > 0;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM Category WHERE Id = @id";
            SqlParameter[] pa =
            {
                new SqlParameter("@id", id)
            };

            return DBConnection.ExecuteNonQuery(sql, pa) > 0;
        }

        public List<Category> Search(string keyword)
        {
            string sql = "SELECT Id, CategoryName FROM Category WHERE CategoryName LIKE @kw";
            SqlParameter[] pa =
            {
                new SqlParameter("@kw", "%" + keyword + "%")
            };

            DataTable dt = DBConnection.GetDataTable(sql, pa);

            List<Category> list = new List<Category>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CategoryName = row["CategoryName"].ToString()
                });
            }
            return list;
        }
    }
}