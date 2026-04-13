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

namespace PMQLBanDoTheThao.View
{
    public partial class BaoCao : Form
    {
        private BaoCaoController controller = new BaoCaoController();

        public BaoCao()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;

                // 1. Gọi Controller lấy dữ liệu
                List<DoanhThuReport> duLieu = controller.LayDoanhThu(tuNgay, denNgay);

                // 2. Đổ dữ liệu lên DataGridView
                dgvBaoCao.DataSource = duLieu;

                // Tùy chỉnh tên cột cho đẹp
                if (dgvBaoCao.Columns.Count > 0)
                {
                    dgvBaoCao.Columns["Ngay"].HeaderText = "Ngày Giao Dịch";
                    dgvBaoCao.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    dgvBaoCao.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu (VNĐ)";
                    dgvBaoCao.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0"; // Format tiền tệ có dấu phẩy
                    dgvBaoCao.Columns["TongDoanhThu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // 3. Tính tổng tất cả các ngày để in ra Label
                decimal tongCong = duLieu.Sum(x => x.TongDoanhThu);
                lblTongDoanhThu.Text = $"Tổng doanh thu: {tongCong:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
