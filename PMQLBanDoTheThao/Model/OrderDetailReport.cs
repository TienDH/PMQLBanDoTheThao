using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.Model
{
    public class OrderDetailReport
    {
        public int OrderId { get; set; }        // MaDon cũ
        public DateTime OrderDate { get; set; }   // NgayLap cũ
        public string CustomerName { get; set; } // TenKhachHang cũ
        public string StaffName { get; set; }    // NhanVienPhuTrach cũ
        public decimal TotalAmount { get; set; } // TongTien cũ
    }
}
