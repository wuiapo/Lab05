using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormQuanLyChuyenNganh : Form
    {
        // GUI chỉ gọi qua BLL
        private readonly ChuyenNganhBLL chuyenNganhBLL = new ChuyenNganhBLL();
        private readonly KhoaBLL khoaBLL = new KhoaBLL();

        // Id của chuyên ngành đang được chọn để Sửa/Xóa (null = đang ở chế độ Thêm mới)
        private int? idDangSua = null;

        public FormQuanLyChuyenNganh()
        {
            InitializeComponent();

            Load += FormQuanLyChuyenNganh_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += (s, e) => LamMoiForm();
            dgvChuyenNganh.CellClick += dgvChuyenNganh_CellClick;
        }

        // ============================== KHỞI TẠO ==============================
        private void FormQuanLyChuyenNganh_Load(object? sender, EventArgs e)
        {
            // Tiêu đề cột nền xanh chữ trắng giống mẫu
            dgvChuyenNganh.EnableHeadersVisualStyles = false;
            dgvChuyenNganh.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 71, 161);
            dgvChuyenNganh.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChuyenNganh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            TaiDanhSachKhoa();
            LamMoiForm();
            TaiLaiDanhSachChuyenNganh();
        }

        private void TaiDanhSachKhoa()
        {
            try
            {
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "Id";
                cboKhoa.DataSource = khoaBLL.LayDanhSach();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi kết nối", ex);
            }
        }

        private void TaiLaiDanhSachChuyenNganh()
        {
            try
            {
                List<ChuyenNganh> ds = chuyenNganhBLL.LayDanhSach();

                dgvChuyenNganh.Rows.Clear();
                foreach (ChuyenNganh cn in ds)
                {
                    int dong = dgvChuyenNganh.Rows.Add(cn.Id, cn.TenChuyenNganh, cn.Khoa?.TenKhoa ?? "");
                    dgvChuyenNganh.Rows[dong].Tag = cn;     // giữ cả object để click là điền ngay lên form
                }

                dgvChuyenNganh.ClearSelection();
                lblTongSo.Text = $"Tổng số Chuyên ngành: {ds.Count}";
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi kết nối", ex);
            }
        }

        // ============================== CLICK CHỌN DÒNG ==============================
        private void dgvChuyenNganh_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvChuyenNganh.Rows[e.RowIndex].Tag is not ChuyenNganh cn) return;

            txtTenChuyenNganh.Text = cn.TenChuyenNganh;
            if (cn.KhoaId.HasValue) cboKhoa.SelectedValue = cn.KhoaId.Value;
            idDangSua = cn.Id;
        }

        // ==================== THÊM / SỬA / XÓA — gọi thẳng BLL ====================
        private void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                chuyenNganhBLL.ThemMoi(txtTenChuyenNganh.Text, KhoaIdDangChon());

                MessageBox.Show("Thêm chuyên ngành thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                TaiLaiDanhSachChuyenNganh();
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể thêm chuyên ngành", ex);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                chuyenNganhBLL.CapNhat(idDangSua ?? 0, txtTenChuyenNganh.Text, KhoaIdDangChon());

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                TaiLaiDanhSachChuyenNganh();
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể cập nhật chuyên ngành", ex);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (idDangSua.HasValue &&
                MessageBox.Show($"Bạn có chắc muốn xóa chuyên ngành \"{txtTenChuyenNganh.Text}\"?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                // Kiểm tra "còn sinh viên đăng ký không" nằm trong ChuyenNganhBLL.Xoa()
                chuyenNganhBLL.Xoa(idDangSua ?? 0);

                LamMoiForm();
                TaiLaiDanhSachChuyenNganh();
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể xóa chuyên ngành", ex);
            }
        }

        // ============================== HÀM PHỤ ==============================
        private void LamMoiForm()
        {
            txtTenChuyenNganh.Clear();
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            idDangSua = null;
            dgvChuyenNganh.ClearSelection();
            txtTenChuyenNganh.Focus();
        }

        // ComboBox rỗng (chưa có Khoa nào) -> 0, để BLL báo "Vui lòng chọn Khoa"
        private int KhoaIdDangChon() => cboKhoa.SelectedValue as int? ?? 0;

        private static void BaoLoi(string tieuDe, Exception ex)
        {
            MessageBox.Show(ex.GetBaseException().Message, tieuDe,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
