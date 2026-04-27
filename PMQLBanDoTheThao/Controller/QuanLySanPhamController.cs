using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.Controller
{
    public class QuanLySanPhamController
    {


        public List<Product> GetAllProducts()
        {
            string sql = @"
                SELECT p.Id, p.Name, p.CategoryId, c.CategoryName, p.Price, p.ImagePath
                FROM Product p
                LEFT JOIN Category c ON p.CategoryId = c.Id
                ORDER BY p.Id DESC";

            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToProductList(dt);
        }

        public List<Product> SearchProducts(string keyword)
        {
            string sql = @"
                SELECT p.Id, p.Name, p.CategoryId, c.CategoryName, p.Price, p.ImagePath
                FROM Product p
                LEFT JOIN Category c ON p.CategoryId = c.Id
                WHERE p.Name LIKE @keyword OR c.CategoryName LIKE @keyword
                ORDER BY p.Id DESC";

            SqlParameter[] parameters = { new SqlParameter("@keyword", "%" + keyword + "%") };
            DataTable dt = DBConnection.GetDataTable(sql, parameters);

            return ConvertToProductList(dt);
        }

        public bool AddProduct(Product product)
        {
            string sql = @"
                INSERT INTO Product (Name, CategoryId, Price, ImagePath) 
                VALUES (@name, @categoryId, @price, @imagePath)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@name", product.Name),
                new SqlParameter("@categoryId", product.CategoryId),
                new SqlParameter("@price", product.Price),
                new SqlParameter("@imagePath", product.ImagePath ?? (object)DBNull.Value)
            };

            int result = DBConnection.ExecuteNonQuery(sql, parameters);
            return result > 0;
        }

        public bool UpdateProduct(Product product)
        {
            string sql = @"
                UPDATE Product 
                SET Name = @name, 
                    CategoryId = @categoryId, 
                    Price = @price, 
                    ImagePath = @imagePath
                WHERE Id = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", product.Id),
                new SqlParameter("@name", product.Name),
                new SqlParameter("@categoryId", product.CategoryId),
                new SqlParameter("@price", product.Price),
                new SqlParameter("@imagePath", product.ImagePath ?? (object)DBNull.Value)
            };

            int result = DBConnection.ExecuteNonQuery(sql, parameters);
            return result > 0;
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                // Xóa biến thể trước
                string sqlDeleteVariant = "DELETE FROM ProductVariant WHERE ProductId = @productId";
                DBConnection.ExecuteNonQuery(sqlDeleteVariant, new SqlParameter[] { new SqlParameter("@productId", productId) });

                // Xóa sản phẩm
                string sqlDeleteProduct = "DELETE FROM Product WHERE Id = @productId";
                int result = DBConnection.ExecuteNonQuery(sqlDeleteProduct, new SqlParameter[] { new SqlParameter("@productId", productId) });

                return result > 0;
            }
            catch
            {
                return false;
            }
        }



        public List<ProductVariant> GetVariantsByProductId(int productId)
        {
            string sql = @"
                SELECT pv.Id, pv.ProductId, pv.SizeId, s.Name AS SizeName, 
                       pv.ColorId, c.Name AS ColorName, pv.Quantity
                FROM ProductVariant pv
                JOIN Size s ON pv.SizeId = s.Id
                JOIN Color c ON pv.ColorId = c.Id
                WHERE pv.ProductId = @productId";

            SqlParameter[] parameters = { new SqlParameter("@productId", productId) };
            DataTable dt = DBConnection.GetDataTable(sql, parameters);

            List<ProductVariant> variants = new List<ProductVariant>();
            foreach (DataRow row in dt.Rows)
            {
                variants.Add(new ProductVariant
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    SizeId = Convert.ToInt32(row["SizeId"]),
                    SizeName = row["SizeName"].ToString(),
                    ColorId = Convert.ToInt32(row["ColorId"]),
                    ColorName = row["ColorName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"])
                });
            }
            return variants;
        }

        public bool AddProductVariant(ProductVariant variant)
        {
            string sql = @"
                INSERT INTO ProductVariant (ProductId, SizeId, ColorId, Quantity) 
                VALUES (@productId, @sizeId, @colorId, @quantity)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@productId", variant.ProductId),
                new SqlParameter("@sizeId", variant.SizeId),
                new SqlParameter("@colorId", variant.ColorId),
                new SqlParameter("@quantity", variant.Quantity)
            };

            int result = DBConnection.ExecuteNonQuery(sql, parameters);
            return result > 0;
        }

        public bool UpdateVariantQuantity(int variantId, int quantity)
        {
            string sql = "UPDATE ProductVariant SET Quantity = @quantity WHERE Id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", variantId),
                new SqlParameter("@quantity", quantity)
            };

            int result = DBConnection.ExecuteNonQuery(sql, parameters);
            return result > 0;
        }

        public bool DeleteVariant(int variantId)
        {
            string sql = "DELETE FROM ProductVariant WHERE Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", variantId) };
            int result = DBConnection.ExecuteNonQuery(sql, parameters);
            return result > 0;
        }


        private List<Product> ConvertToProductList(DataTable dt)
        {
            List<Product> list = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    ImagePath = row["ImagePath"] == DBNull.Value ? null : row["ImagePath"].ToString()
                });
            }
            return list;
        }

        public List<Product> FilterProducts(int? categoryId, decimal? maxPrice)
        {
            // Câu lệnh SQL linh hoạt: Nếu tham số null thì bỏ qua điều kiện đó
            string sql = @"
        SELECT p.Id, p.Name, p.CategoryId, c.CategoryName, p.Price, p.ImagePath
        FROM Product p
        LEFT JOIN Category c ON p.CategoryId = c.Id
        WHERE (@categoryId IS NULL OR p.CategoryId = @categoryId)
          AND (@maxPrice IS NULL OR p.Price <= @maxPrice)
        ORDER BY p.Price ASC";

            SqlParameter[] parameters = {
        new SqlParameter("@categoryId", (object)categoryId ?? DBNull.Value),
        new SqlParameter("@maxPrice", (object)maxPrice ?? DBNull.Value)
    };

            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            return ConvertToProductList(dt);
        }

        // Lấy danh sách tất cả Kích thước (Size) để đổ vào ComboBox
        public DataTable GetAllSizes()
        {
            string sql = "SELECT Id, Name FROM Size";
            return DBConnection.GetDataTable(sql);
        }

        // Lấy danh sách tất cả Màu sắc (Color) để đổ vào ComboBox
        public DataTable GetAllColors()
        {
            string sql = "SELECT Id, Name FROM Color";
            return DBConnection.GetDataTable(sql);
        }
        // Lấy danh sách Danh mục để đổ vào ComboBox
        public DataTable GetAllCategories()
        {
            // Dựa vào câu SQL cũ của bạn, mình thấy cột tên danh mục là CategoryName
            string sql = "SELECT Id, CategoryName FROM Category";
            return DBConnection.GetDataTable(sql);
        }

    }
}
