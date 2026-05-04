using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyHoaDon : UserControl
    {
        private HoaDonController _controller = new HoaDonController();
        private DataTable dt = new DataTable();
        private int giam = 0;

        public QuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("SL", typeof(int));
            dt.Columns.Add("Gia", typeof(decimal));

            dgvGioHang.DataSource = dt;

            cboSanPham.DataSource = _controller.GetAllProducts();
            cboSanPham.DisplayMember = "Name";
            cboSanPham.ValueMember = "Id";

            // 🔥 QUAN TRỌNG
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null) return;

            int id = (int)cboSanPham.SelectedValue;

            cboSize.DataSource = _controller.GetSizesByProduct(id);
            cboSize.DisplayMember = "Name";
            cboSize.ValueMember = "Id";

            cboMauSac.DataSource = _controller.GetColorsByProduct(id);
            cboMauSac.DisplayMember = "Name";
            cboMauSac.ValueMember = "Id";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var v = _controller.GetVariant(
                (int)cboSanPham.SelectedValue,
                (int)cboSize.SelectedValue,
                (int)cboMauSac.SelectedValue);

            if (v == null)
            {
                MessageBox.Show("Không tồn tại!");
                return;
            }

            dt.Rows.Add(v.Value.variantId, cboSanPham.Text,
    (int)nmSoLuong.Value, v.Value.price);

            TinhTong();
        }

        private void TinhTong()
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ChiTietHoaDon
                {
                    ProductVariantId = Convert.ToInt32(r["Id"]),
                    Quantity = Convert.ToInt32(r["SL"]),
                    Price = Convert.ToDecimal(r["Gia"])
                });
            }

            decimal tong = _controller.TinhTongTien(list, giam);
            lblTongTien.Text = "TỔNG: " + tong.ToString("N0") + " ₫";
        }

        private void txtMaVoucher_Click(object sender, EventArgs e)
        {
            var res = _controller.ApplyVoucher(txtVoucher.Text);

            if (!res.ok)
            {
                giam = 0;
                MessageBox.Show(res.msg);
            }
            else
            {
                giam = res.percent;
                MessageBox.Show("Áp dụng thành công!");
            }

            TinhTong();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null) return;

            int row = dgvGioHang.CurrentRow.Index;
            dt.Rows[row]["SL"] = (int)nmSoLuong.Value;

            TinhTong();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null) return;

            dt.Rows.RemoveAt(dgvGioHang.CurrentRow.Index);
            TinhTong();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            giam = 0;
            txtVoucher.Clear();
            lblGiamGia.Text = "Giảm giá: 0 ₫";
            TinhTong();
        }

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                nmSoLuong.Value = Convert.ToInt32(
                    dgvGioHang.Rows[e.RowIndex].Cells["SL"].Value);
            }
        }

        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // để trống cũng được
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa code xuất hóa đơn 😄");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ChiTietHoaDon
                {
                    ProductVariantId = Convert.ToInt32(r["Id"]),
                    Quantity = Convert.ToInt32(r["SL"]),
                    Price = Convert.ToDecimal(r["Gia"])
                });
            }

            decimal tong = _controller.TinhTongTien(list, giam);

            if (_controller.SaveHoaDon(list, tong))
            {
                MessageBox.Show("Thanh toán thành công!");
                dt.Rows.Clear();
                TinhTong();
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
        }

        
    }
}