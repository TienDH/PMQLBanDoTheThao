using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMQLBanDoTheThao.Model;
using PMQLBanDoTheThao.DataBase;
namespace PMQLBanDoTheThao.Controller
{
    public class QuanLyKhachHangController
    {
        // Khởi tạo kết nối DB dùng chung cho cả class
        private CustomerDB db = new CustomerDB();

        // ==========================================
        // 1. Hàm xử lý logic THÊM khách hàng
        // ==========================================
        public List<Customer> XuLyTimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return db.GetAll(); // Nếu không gõ gì mà bấm tìm thì ra tất cả
            }
            return db.TimKiemKhachHang(tuKhoa.Trim());
        }
        public string XuLyThemKhachHang(Customer cus)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(cus.Name) || string.IsNullOrWhiteSpace(cus.Phone))
            {
                return "Tên và số điện thoại không được để trống!";
            }

            try
            {
                // Tiến hành thêm vào DB
                bool ketQua = db.ThemKhachHang(cus);
                if (ketQua)
                {
                    return "Thêm khách hàng thành công!";
                }
                else
                {
                    return "Có lỗi xảy ra, không thể thêm.";
                }
            }
            catch (System.Exception ex)
            {
                // Bắt lỗi nếu nhập trùng số điện thoại (Vi phạm UNIQUE trong SQL)
                if (ex.Message.Contains("UNIQUE KEY") || ex.Message.Contains("duplicate"))
                {
                    return "Lỗi: Số điện thoại này đã tồn tại trong hệ thống!";
                }
                return "Lỗi cơ sở dữ liệu: " + ex.Message;
            }
        }

        // ==========================================
        // 2. Hàm xử lý logic SỬA khách hàng
        // ==========================================
        public string XuLySuaKhachHang(Customer cus)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(cus.Name) || string.IsNullOrWhiteSpace(cus.Phone))
            {
                return "Tên và số điện thoại không được để trống!";
            }

            // Gọi xuống DataBase để lưu
            bool ketQua = db.SuaKhachHang(cus);
            if (ketQua)
            {
                return "Cập nhật thành công!";
            }
            else
            {
                return "Cập nhật thất bại! Vui lòng thử lại.";
            }
        }

        // ==========================================
        // 3. Hàm xử lý logic XÓA khách hàng
        // ==========================================
        public bool XuLyXoaKhachHang(int id)
        {
            return db.XoaKhachHang(id);
        }
    }
}