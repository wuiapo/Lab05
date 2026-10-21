using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormQuanLyKhoa : Form
    {
        // GUI chỉ gọi qua BLL
        private readonly KhoaBLL khoaBLL = new KhoaBLL();

        // Id của khoa đang được chọn để Sửa/Xóa (null = đang ở chế độ Thêm mới)
        private int? idDangSua = null;

        public FormQuanLyKhoa()
        {
            InitializeComponent();

            // Sự kiện Load đã được Designer gắn sẵn (FormQuanLyKhoa_Load)
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvKhoa.CellClick += dgvKhoa_CellClick;
            chkNamChuaRo.CheckedChanged += (s, e) => nudNamThanhLap.Enabled = !chkNamChuaRo.Checked;
            chkGVChuaRo.CheckedChanged += (s, e) => nudTongSoGV.Enabled = !chkGVChuaRo.Checked;
            dgvKhoa.DataBindingComplete += (s, e) => dgvKhoa.ClearSelection();   // không tự chọn dòng đầu
        }

        // ============================== KHỞI TẠO ==============================
        private void FormQuanLyKhoa_Load(object sender, EventArgs e)
        {
            CauHinhGiaoDien();
            LamMoiForm();
            TaiLaiDanhSachKhoa();
        }

        private void CauHinhGiaoDien()
        {
            // Đặt Maximum trước rồi mới đặt Minimum (mặc định Maximum = 100 < 1900)
            nudNamThanhLap.Maximum = DateTime.Today.Year;
            nudNamThanhLap.Minimum = 1900;
            nudTongSoGV.Minimum = 0;
            nudTongSoGV.Maximum = 10000;

            dgvKhoa.ReadOnly = true;
            dgvKhoa.AllowUserToAddRows = false;
            dgvKhoa.AllowUserToDeleteRows = false;
            dgvKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoa.MultiSelect = false;
            dgvKhoa.RowHeadersVisible = false;
            dgvKhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhoa.BackgroundColor = Color.White;

            // Tiêu đề cột nền xanh chữ trắng giống mẫu
            dgvKhoa.EnableHeadersVisualStyles = false;
            dgvKhoa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 71, 161);
            dgvKhoa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKhoa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        // ============================== ĐỌC DỮ LIỆU ==============================
        private void TaiLaiDanhSachKhoa()
        {
            try
            {
                List<Khoa> dsKhoa = khoaBLL.LayDanhSach();
                dgvKhoa.DataSource = dsKhoa;

                // Cột được tạo tự động theo thuộc tính của Khoa -> đặt lại tiêu đề, ẩn Id
                dgvKhoa.Columns[nameof(Khoa.Id)].Visible = false;

                // Bài tập 2: Khoa có thêm navigation "ChuyenNganhs" (danh sách) -> không hiển thị thành cột
                if (dgvKhoa.Columns.Contains(nameof(Khoa.ChuyenNganhs)))
                    dgvKhoa.Columns[nameof(Khoa.ChuyenNganhs)].Visible = false;
                dgvKhoa.Columns[nameof(Khoa.TenKhoa)].HeaderText = "Tên Khoa";
                dgvKhoa.Columns[nameof(Khoa.NamThanhLap)].HeaderText = "Năm thành lập";
                dgvKhoa.Columns[nameof(Khoa.TongSoGiangVien)].HeaderText = "Tổng số Giảng viên";

                // Giá trị null hiển thị "Chưa có" thay vì ô trống
                dgvKhoa.Columns[nameof(Khoa.NamThanhLap)].DefaultCellStyle.NullValue = "Chưa có";
                dgvKhoa.Columns[nameof(Khoa.TongSoGiangVien)].DefaultCellStyle.NullValue = "Chưa có";

                tslblTongSo.Text = $"Tổng số Khoa: {dsKhoa.Count}";
                tslblTrangThai.Text = "Sẵn sàng";
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi kết nối", ex);
            }
        }

        // ============================== CLICK CHỌN DÒNG ==============================
        private void dgvKhoa_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;                                          // click vào tiêu đề cột
            if (dgvKhoa.Rows[e.RowIndex].DataBoundItem is not Khoa khoa) return;

            txtTenKhoa.Text = khoa.TenKhoa;

            chkNamChuaRo.Checked = !khoa.NamThanhLap.HasValue;
            if (khoa.NamThanhLap.HasValue)
                nudNamThanhLap.Value = khoa.NamThanhLap.Value;

            chkGVChuaRo.Checked = !khoa.TongSoGiangVien.HasValue;
            if (khoa.TongSoGiangVien.HasValue)
                nudTongSoGV.Value = khoa.TongSoGiangVien.Value;

            idDangSua = khoa.Id;
            tslblTrangThai.Text = $"Đang chọn: {khoa.TenKhoa}";
        }

        // ==================== THÊM / SỬA / XÓA — gọi thẳng KhoaBLL ====================
        private void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                khoaBLL.ThemMoi(txtTenKhoa.Text, NamThanhLapNhap(), TongSoGVNhap());

                MessageBox.Show("Thêm khoa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                TaiLaiDanhSachKhoa();
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể thêm khoa", ex);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                // idDangSua null -> truyền 0, BLL sẽ báo "Vui lòng chọn khoa cần sửa"
                khoaBLL.CapNhat(idDangSua ?? 0, txtTenKhoa.Text, NamThanhLapNhap(), TongSoGVNhap());

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                TaiLaiDanhSachKhoa();
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể cập nhật khoa", ex);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            // Chưa chọn dòng nào thì không hỏi xác nhận, chuyển thẳng cho BLL báo lỗi
            if (idDangSua.HasValue &&
                MessageBox.Show($"Bạn có chắc muốn xóa khoa \"{txtTenKhoa.Text}\"?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                // Kiểm tra "còn sinh viên thuộc khoa không" nằm trong KhoaBLL.Xoa()
                khoaBLL.Xoa(idDangSua ?? 0);

                LamMoiForm();
                TaiLaiDanhSachKhoa();
                tslblTrangThai.Text = "Đã xóa khoa";
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể xóa khoa", ex);
            }
        }

        // ============================== LÀM MỚI ==============================
        private void btnLamMoi_Click(object? sender, EventArgs e) => LamMoiForm();

        private void LamMoiForm()
        {
            txtTenKhoa.Clear();
            nudNamThanhLap.Value = nudNamThanhLap.Minimum;
            nudTongSoGV.Value = 0;
            chkNamChuaRo.Checked = true;      // mặc định "Chưa rõ" giống hình mẫu
            chkGVChuaRo.Checked = true;
            nudNamThanhLap.Enabled = false;   // gán lại cho chắc (nếu Checked vốn đã true thì CheckedChanged không chạy)
            nudTongSoGV.Enabled = false;

            idDangSua = null;
            dgvKhoa.ClearSelection();
            tslblTrangThai.Text = "Sẵn sàng";
            txtTenKhoa.Focus();
        }

        // ============================== HÀM PHỤ ==============================

        // Chỉ ĐỌC giá trị trên form (tick "Chưa rõ" = null). Việc kiểm tra hợp lệ do KhoaBLL làm.
        private int? NamThanhLapNhap() => chkNamChuaRo.Checked ? null : (int)nudNamThanhLap.Value;
        private int? TongSoGVNhap() => chkGVChuaRo.Checked ? null : (int)nudTongSoGV.Value;

        private void BaoLoi(string tieuDe, Exception ex)
        {
            MessageBox.Show(ex.GetBaseException().Message, tieuDe,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tslblTrangThai.Text = tieuDe;
        }
    }
}
