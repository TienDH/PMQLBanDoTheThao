using PMQLBanDoTheThao.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyLoaiSanPham : UserControl
    {
        private QuanLyLoaiSanPhamController controller = new QuanLyLoaiSanPhamController();
        private int currentId = 0;
        public QuanLyLoaiSanPham()
        {
            InitializeComponent();
            LoadData();
            dgvLoaiSP.CellClick += dgvLoaiSP_CellClick;
        }
        private void LoadData()
        {
            dgvLoaiSP.DataSource = controller.GetAll();

            if (dgvLoaiSP.Columns["Id"] != null)
                dgvLoaiSP.Columns["Id"].Visible = false;
        }
        private void ClearForm()
        {
            currentId = 0;
            txtTenLoai.Clear();
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Nhập tên loại!");
                txtTenLoai.Focus();
                return false;
            }
            return true;
        }
        private void groupThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
                dgvLoaiSP.DataSource = controller.GetAll();
            else
                dgvLoaiSP.DataSource = controller.Search(keyword);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            currentId = Convert.ToInt32(dgvLoaiSP.Rows[e.RowIndex].Cells["Id"].Value);
            txtTenLoai.Text = dgvLoaiSP.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
        }
        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            currentId = Convert.ToInt32(dgvLoaiSP.Rows[e.RowIndex].Cells["Id"].Value);
            txtTenLoai.Text = dgvLoaiSP.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
        }
        private void txtTenLoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (controller.Add(txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Thêm thành công");
                LoadData();
                ClearForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentId == 0)
            {
                MessageBox.Show("Chọn dữ liệu!");
                return;
            }

            if (!ValidateInput()) return;

            if (controller.Update(currentId, txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData();
                ClearForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentId == 0) return;

            if (MessageBox.Show("Xóa?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (controller.Delete(currentId))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadData();
                    ClearForm();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
