using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PMQLBanDoTheThao.Controller
{
    public class QuanLyVoucherController
    {
        public List<Voucher> GetAll()
        {
            string sql = "SELECT * FROM Voucher ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);

            List<Voucher> list = new List<Voucher>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Voucher
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Code = row["Code"].ToString(),
                    DiscountPercent = Convert.ToInt32(row["DiscountPercent"]),
                    ExpiryDate = Convert.ToDateTime(row["ExpiryDate"])
                });
            }
            return list;
        }

        public bool Add(Voucher v)
        {
            string sql = @"INSERT INTO Voucher (Code, DiscountPercent, ExpiryDate)
                           VALUES (@code, @discount, @date)";

            SqlParameter[] pa =
            {
                new SqlParameter("@code", v.Code),
                new SqlParameter("@discount", v.DiscountPercent),
                new SqlParameter("@date", v.ExpiryDate)
            };

            return DBConnection.ExecuteNonQuery(sql, pa) > 0;
        }

        public bool Update(Voucher v)
        {
            string sql = @"UPDATE Voucher 
                           SET Code = @code, DiscountPercent = @discount, ExpiryDate = @date
                           WHERE Id = @id";

            SqlParameter[] pa =
            {
                new SqlParameter("@id", v.Id),
                new SqlParameter("@code", v.Code),
                new SqlParameter("@discount", v.DiscountPercent),
                new SqlParameter("@date", v.ExpiryDate)
            };

            return DBConnection.ExecuteNonQuery(sql, pa) > 0;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM Voucher WHERE Id = @id";

            SqlParameter[] pa =
            {
                new SqlParameter("@id", id)
            };

            return DBConnection.ExecuteNonQuery(sql, pa) > 0;
        }

        public List<Voucher> Search(string keyword)
        {
            string sql = "SELECT * FROM Voucher WHERE Code LIKE @kw";

            SqlParameter[] pa =
            {
                new SqlParameter("@kw", "%" + keyword + "%")
            };

            DataTable dt = DBConnection.GetDataTable(sql, pa);

            List<Voucher> list = new List<Voucher>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Voucher
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Code = row["Code"].ToString(),
                    DiscountPercent = Convert.ToInt32(row["DiscountPercent"]),
                    ExpiryDate = Convert.ToDateTime(row["ExpiryDate"])
                });
            }
            return list;
        }
    }
}