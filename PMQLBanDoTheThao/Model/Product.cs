using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }     // Dùng để hiển thị
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        // Danh sách biến thể
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();

        public Product() { }

        public Product(int id, string name, int categoryId, decimal price, string imagePath = null)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Price = price;
            ImagePath = imagePath;
        }
    }
}
