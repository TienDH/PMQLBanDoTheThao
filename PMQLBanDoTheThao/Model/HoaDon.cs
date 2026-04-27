using System;
using System.Collections.Generic;

namespace PMQLBanDoTheThao.Model
{
    // CỰC KỲ QUAN TRỌNG: Phải có chữ public ở đây
    public class HoaDon
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        // Thuộc tính bổ trợ để hiện tên khách hàng/nhân viên lên giao diện
        public string UserName { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Danh sách các món hàng trong hóa đơn này (nếu cần dùng)
        public List<ChiTietHoaDon> OrderDetails { get; set; }

        public HoaDon()
        {
            OrderDetails = new List<ChiTietHoaDon>();
        }
    }
}