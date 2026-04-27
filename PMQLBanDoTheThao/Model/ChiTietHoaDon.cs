using System;

namespace PMQLBanDoTheThao.Model
{
    public class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductVariantId { get; set; }

        // Các thuộc tính bổ trợ để hiện lên bảng (GridView)
        public string ProductName { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Thành tiền tự tính
        public decimal ThanhTien => Quantity * Price;
    }
}