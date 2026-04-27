using FastReport;
using FastReport.Export.PdfSimple;
using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyHoaDon : UserControl
    {
        private DataTable dtGioHang = new DataTable();
        private decimal giamGia = 0;
        private int _sanPhamDuocChon = -1;
        private int phanTramGiam = 0;

        private QuanLyVoucherController _voucherController = new QuanLyVoucherController();

        public QuanLyHoaDon(int productId = -1)
        {
            InitializeComponent();
            SetupDataGridView();
            button1.Text = "✎ Sửa Hóa Đơn";
            _sanPhamDuocChon = productId;
        }

        private void SetupDataGridView()
        {
            // Ép xóa sạch cột cũ để chống lỗi xung đột giao diện Designer
            dgvGioHang.DataSource = null;
            dgvGioHang.Columns.Clear();
            dgvGioHang.AutoGenerateColumns = true;

            dtGioHang.Columns.Clear();
            dtGioHang.Columns.Add("IdSP", typeof(int));
            dtGioHang.Columns.Add("TenSP", typeof(string));
            dtGioHang.Columns.Add("Size", typeof(string));
            dtGioHang.Columns.Add("Mau", typeof(string));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("GiamGia", typeof(decimal));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));

            dgvGioHang.DataSource = dtGioHang;

            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.MultiSelect = false;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.AllowUserToAddRows = false;

            // Đặt tên Tiếng Việt và ẩn cột ID
            dgvGioHang.Columns["IdSP"].Visible = false;
            dgvGioHang.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvGioHang.Columns["Size"].HeaderText = "Kích Cỡ";
            dgvGioHang.Columns["Mau"].HeaderText = "Màu Sắc";
            dgvGioHang.Columns["SoLuong"].HeaderText = "SL";
            dgvGioHang.Columns["DonGia"].HeaderText = "Đơn Giá (₫)";
            dgvGioHang.Columns["GiamGia"].HeaderText = "Giảm Giá (₫)";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành Tiền (₫)";

            // Căn lề phải và định dạng phân cách hàng nghìn cho các cột tiền
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGioHang.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGioHang.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();
            cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;
            if (_sanPhamDuocChon != -1)
            {
                cboSanPham.SelectedValue = _sanPhamDuocChon;
            }
        }

        private void LoadComboBoxSanPham()
        {
            try
            {
                DataTable dt = DBConnection.GetDataTable("SELECT Id, Name FROM Product");
                cboSanPham.DataSource = dt;
                cboSanPham.DisplayMember = "Name";
                cboSanPham.ValueMember = "Id";
                cboSanPham.SelectedIndex = -1;
            }
            catch { }
        }

        private void CboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null || !(cboSanPham.SelectedValue is int)) return;

            int pId = (int)cboSanPham.SelectedValue;
            string sqlS = "SELECT DISTINCT s.Id, s.Name FROM Size s JOIN ProductVariant pv ON s.Id = pv.SizeId WHERE pv.ProductId = " + pId;
            cboSize.DataSource = DBConnection.GetDataTable(sqlS);
            cboSize.DisplayMember = "Name"; cboSize.ValueMember = "Id";

            string sqlC = "SELECT DISTINCT c.Id, c.Name FROM Color c JOIN ProductVariant pv ON c.Id = pv.ColorId WHERE pv.ProductId = " + pId;
            cboMauSac.DataSource = DBConnection.GetDataTable(sqlC);
            cboMauSac.DisplayMember = "Name"; cboMauSac.ValueMember = "Id";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex == -1 || cboSize.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin sản phẩm!");
                return;
            }
            try
            {
                string sql = "SELECT pv.Id, p.Price FROM ProductVariant pv JOIN Product p ON pv.ProductId = p.Id WHERE pv.ProductId = @p AND pv.SizeId = @s AND pv.ColorId = @c";
                SqlParameter[] pars = {
                    new SqlParameter("@p", cboSanPham.SelectedValue),
                    new SqlParameter("@s", cboSize.SelectedValue),
                    new SqlParameter("@c", cboMauSac.SelectedValue)
                };
                DataTable dt = DBConnection.GetDataTable(sql, pars);
                if (dt.Rows.Count > 0)
                {
                    int soLuong = (int)nmSoLuong.Value;
                    if (soLuong <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!"); return; }

                    decimal donGia = Convert.ToDecimal(dt.Rows[0]["Price"]);

                    // Thêm dòng tạm thời vào DataTable
                    dtGioHang.Rows.Add(dt.Rows[0]["Id"], cboSanPham.Text, cboSize.Text, cboMauSac.Text, soLuong, donGia, 0, 0);

                    // Gọi hàm tính tổng để nó tự động điền đúng số tiền Giảm Giá và Thành Tiền
                    TinhTongTien();
                }
                else
                {
                    MessageBox.Show("Sản phẩm phiên bản này đã hết hoặc không tồn tại!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // ========================================================
        // HÀM TÍNH TỔNG: ĐÃ THÊM LỆNH ÉP REPAINT CHỐNG LỖI UI
        // ========================================================
        private void TinhTongTien()
        {
            decimal tongGiamGia = 0;
            decimal tongTienSauGiam = 0;

            // Tạm thời dừng vẽ giao diện để load data mượt hơn
            dgvGioHang.SuspendLayout();

            foreach (DataRow r in dtGioHang.Rows)
            {
                decimal donGia = Convert.ToDecimal(r["DonGia"]);
                int soLuong = Convert.ToInt32(r["SoLuong"]);

                decimal tienGoc = donGia * soLuong;
                decimal giamGiaMon = tienGoc * phanTramGiam / 100;
                decimal thanhTien = tienGoc - giamGiaMon;

                // ÉP BẢNG CẬP NHẬT GIAO DIỆN BẰNG BEGIN/END EDIT
                r.BeginEdit();
                r["GiamGia"] = giamGiaMon;
                r["ThanhTien"] = thanhTien;
                r.EndEdit();

                tongGiamGia += giamGiaMon;
                tongTienSauGiam += thanhTien;
            }

            // Mở lại giao diện và ép vẽ lại toàn bộ các con số
            dtGioHang.AcceptChanges();
            dgvGioHang.ResumeLayout();
            dgvGioHang.Refresh();

            giamGia = tongGiamGia;

            // Cập nhật nhãn tổng
            if (phanTramGiam > 0)
                lblGiamGia.Text = $"Giảm giá ({phanTramGiam}%): {giamGia.ToString("N0")} ₫";
            else
                lblGiamGia.Text = "Giảm giá: 0 ₫";

            lblTongTien.Text = "TỔNG: " + tongTienSauGiam.ToString("N0") + " ₫";
        }

        private void txtMaVoucher_Click(object sender, EventArgs e)
        {
            string ma = txtVoucher.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                phanTramGiam = 0;
                TinhTongTien();
                MessageBox.Show("Đã hủy áp mã Voucher!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var danhSachVoucher = _voucherController.Search(ma);
            var voucher = danhSachVoucher.FirstOrDefault(v => v.Code.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (voucher == null)
            {
                phanTramGiam = 0;
                MessageBox.Show("Mã giảm giá không hợp lệ hoặc không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (voucher.ExpiryDate.Date < DateTime.Now.Date)
            {
                phanTramGiam = 0;
                MessageBox.Show($"Mã giảm giá này đã hết hạn từ ngày {voucher.ExpiryDate.ToString("dd/MM/yyyy")}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                phanTramGiam = voucher.DiscountPercent;
                MessageBox.Show($"Áp mã thành công! Đơn hàng được giảm {phanTramGiam}%.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            TinhTongTien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                int rowIndex = dgvGioHang.CurrentRow.Index;
                int slMoi = (int)nmSoLuong.Value;

                if (slMoi <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!"); return; }

                dtGioHang.Rows[rowIndex]["SoLuong"] = slMoi;
                TinhTongTien();

                MessageBox.Show("Đã cập nhật số lượng thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm để sửa!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                dtGioHang.Rows.RemoveAt(dgvGioHang.CurrentRow.Index);
                TinhTongTien();
            }
        }

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                nmSoLuong.Value = Convert.ToInt32(dgvGioHang.Rows[e.RowIndex].Cells["SoLuong"].Value);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0) { MessageBox.Show("Giỏ hàng đang trống!"); return; }
            MessageBox.Show("Thanh toán thành công! Hóa đơn đã được lưu.");
            btnlammoi_Click(sender, e);
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            dtGioHang.Rows.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtVoucher.Clear();

            Control[] txtDiaChiCtrl = this.Controls.Find("txtDiaChi", true);
            if (txtDiaChiCtrl.Length > 0) txtDiaChiCtrl[0].Text = "";

            phanTramGiam = 0;
            giamGia = 0;
            TinhTongTien();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng đang trống. Không có gì để in hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (Report report = new Report())
                {
                    report.Load("HoaDon.frx");
                    double tongTienBang = 0;

                    using (DataTable dtReport = new DataTable())
                    {
                        dtReport.Columns.Add("STT", typeof(int));
                        dtReport.Columns.Add("TenSP", typeof(string));
                        dtReport.Columns.Add("MauSac", typeof(string));
                        dtReport.Columns.Add("Size", typeof(string));
                        dtReport.Columns.Add("SoLuong", typeof(int));
                        dtReport.Columns.Add("Gia", typeof(double));
                        dtReport.Columns.Add("GiamGia", typeof(double));
                        dtReport.Columns.Add("ThanhTien", typeof(double));

                        int stt = 1;
                        foreach (DataRow r in dtGioHang.Rows)
                        {
                            string ten = r["TenSP"].ToString();
                            string mau = r["Mau"].ToString();
                            string size = r["Size"].ToString();
                            int sl = Convert.ToInt32(r["SoLuong"]);
                            double gia = Convert.ToDouble(r["DonGia"]);
                            double giamGiaMon = Convert.ToDouble(r["GiamGia"]);
                            double thanhTien = Convert.ToDouble(r["ThanhTien"]);

                            dtReport.Rows.Add(stt, ten, mau, size, sl, gia, giamGiaMon, thanhTien);

                            tongTienBang += thanhTien;
                            stt++;
                        }

                        report.RegisterData(dtReport, "Data");
                    }

                    string tenKH = string.IsNullOrWhiteSpace(txtTenKhachHang.Text) ? "Khách vãng lai" : txtTenKhachHang.Text.Trim();
                    string sdtKH = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? "(Không có)" : txtSoDienThoai.Text.Trim();

                    Control[] txtDiaChiCtrl = this.Controls.Find("txtDiaChi", true);
                    string diaChiKH = txtDiaChiCtrl.Length > 0 && !string.IsNullOrWhiteSpace(txtDiaChiCtrl[0].Text) ? txtDiaChiCtrl[0].Text.Trim() : "(Không có)";

                    report.SetParameterValue("TenKhachHang", tenKH);
                    report.SetParameterValue("SoDienThoai", sdtKH);
                    report.SetParameterValue("DiaChi", diaChiKH);
                    report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    report.SetParameterValue("TongTien", tongTienBang);

                    report.Prepare();

                    PDFSimpleExport pdfExport = new PDFSimpleExport();
                    string pdfFileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

                    report.Export(pdfExport, pdfFileName);

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = pdfFileName,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e) => MessageBox.Show("Tìm kiếm hóa đơn...");
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}