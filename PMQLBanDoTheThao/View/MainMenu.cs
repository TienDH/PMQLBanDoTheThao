using PMQLBanDoTheThao.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQLBanDoTheThao
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLySanPham());
        }
        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            

        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            View.QuanLyKhachHang frmKhachHang = new View.QuanLyKhachHang();

            frmKhachHang.TopLevel = false;                 
            frmKhachHang.FormBorderStyle = FormBorderStyle.None; 
            frmKhachHang.Dock = DockStyle.Fill;            
            panelContent.Controls.Add(frmKhachHang);
            frmKhachHang.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuanLyKho_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
            //    // 1. Xóa các Form cũ đang hiển thị trong Panel để lấy chỗ trống
            //    panelContent.Controls.Clear();

            //    // 2. Khởi tạo Form Báo Cáo (đảm bảo bạn đã tạo file View/BaoCao.cs)
            //    //View.BaoCao frmBaoCao = new View.BaoCao();

            //    // 3. Cấu hình để Form con có thể nhúng được vào Panel
            //    frmBaoCao.TopLevel = false;                  // Bắt buộc: Để form không chạy độc lập
            //    frmBaoCao.FormBorderStyle = FormBorderStyle.None; // Xóa viền/thanh tiêu đề của form con
            //    frmBaoCao.Dock = DockStyle.Fill;             // Phóng to cho lấp đầy vùng màu trắng (panelContent)

            //    // 4. Thêm Form con vào Panel và ra lệnh hiển thị
            //    panelContent.Controls.Add(frmBaoCao);
            //    frmBaoCao.Show();
        }
    }
}
