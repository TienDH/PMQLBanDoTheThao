using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyVoucher : UserControl
    {
        private QuanLyVoucherController controller = new QuanLyVoucherController();
        private int currentId = 0;

        public QuanLyVoucher()
        {
            InitializeComponent();
            LoadData();
            dgvVoucher.CellClick += dgvVoucher_CellClick;

        }
        private void LoadData()
        {
            dgvVoucher.DataSource = controller.GetAll();

            if (dgvVoucher.Columns["Id"] != null)
                dgvVoucher.Columns["Id"].Visible = false;
        }

        private void ClearForm()
        {
            currentId = 0;
            txtCode.Clear();
            txtDiscount.Clear();
            dtpExpiry.Value = DateTime.Now;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Nhập mã!");
                return false;
            }

            if (!int.TryParse(txtDiscount.Text, out int discount) || discount <= 0 || discount > 100)
            {
                MessageBox.Show("Giảm giá 1-100%");
                return false;
            }

            return true;
        }

        private void QuanLyVoucher_Load(object sender, EventArgs e)
        {

        }

        private void txtTenLoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Voucher v = new Voucher
            {
                Code = txtCode.Text.Trim(),
                DiscountPercent = int.Parse(txtDiscount.Text),
                ExpiryDate = dtpExpiry.Value
            };

            if (controller.Add(v))
            {
                MessageBox.Show("Thêm thành công");
                LoadData();
                ClearForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentId == 0) return;
            if (!ValidateInput()) return;

            Voucher v = new Voucher
            {
                Id = currentId,
                Code = txtCode.Text.Trim(),
                DiscountPercent = int.Parse(txtDiscount.Text),
                ExpiryDate = dtpExpiry.Value
            };

            if (controller.Update(v))
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
                dgvVoucher.DataSource = controller.GetAll();
            else
                dgvVoucher.DataSource = controller.Search(keyword);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }
        private void dgvVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            currentId = Convert.ToInt32(dgvVoucher.Rows[e.RowIndex].Cells["Id"].Value);

            txtCode.Text = dgvVoucher.Rows[e.RowIndex].Cells["Code"].Value.ToString();
            txtDiscount.Text = dgvVoucher.Rows[e.RowIndex].Cells["DiscountPercent"].Value.ToString();
            dtpExpiry.Value = Convert.ToDateTime(dgvVoucher.Rows[e.RowIndex].Cells["ExpiryDate"].Value);
        }
    }
}
