using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.Model
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int Quantity { get; set; }

        public ProductVariant() { }

        public ProductVariant(int productId, int sizeId, int colorId, int quantity)
        {
            ProductId = productId;
            SizeId = sizeId;
            ColorId = colorId;
            Quantity = quantity;
        }
    }
}
