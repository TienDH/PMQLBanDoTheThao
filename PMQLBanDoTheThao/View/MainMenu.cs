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

        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuanLyKho_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
            // 1. Xóa giao diện cũ đang hiển thị
            panelMain.Controls.Clear();

            // 2. Gọi Form Báo Cáo
            View.BaoCao frmBaoCao = new View.BaoCao();

            // 3. Ép Form thành Control con để nhúng được vào Panel
            frmBaoCao.TopLevel = false;
            frmBaoCao.FormBorderStyle = FormBorderStyle.None;
            frmBaoCao.Dock = DockStyle.Fill; // Tự động phóng to cho vừa khít

            // 4. Hiển thị lên
            panelMain.Controls.Add(frmBaoCao);
            frmBaoCao.Show();
        }
    }
}
