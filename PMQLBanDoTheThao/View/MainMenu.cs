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
            panelMain.Controls.Clear();
            QuanLyNhanVien uc = new QuanLyNhanVien();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void BtnQuanLyKho_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {

        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLyLoaiSanPham());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLyVoucher());
        }
    }
}
