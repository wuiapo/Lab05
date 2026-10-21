using System.Globalization;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormChinh : Form
    {
        // GUI chỉ gọi qua BLL — KHÔNG còn "new QuanLySinhVienDbContext()" ở đây nữa
        private readonly SinhVienBLL sinhVienBLL = new SinhVienBLL();

        // Id của sinh viên đang được chọn để Sửa/Xóa (null = đang ở chế độ Thêm mới)
        private int? idDangSua = null;

        public FormChinh()
        {
            InitializeComponent();

            // Gắn sự kiện bằng code -> KHÔNG cần double-click các nút trong Designer
            Load += FormChinh_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) MoFormDangKy(); };

            // Menu Dữ liệu -> Quản lý khoa (F1) / Tra cứu sinh viên (Ctrl+F)
            mnuQuanLyKhoa.Click += mnuQuanLyKhoa_Click;
            tìmKiếmToolStripMenuItem.Text = "Tra cứu Sinh viên";
            tìmKiếmToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            tìmKiếmToolStripMenuItem.Click += mnuTimKiem_Click;
        }

        // 2 hàm rỗng này do Designer tham chiếu tới (xóa sẽ lỗi build)
        private void lblDiemTB_Click(object sender, EventArgs e) { }
        private void gpbThongTinSinhVien_Enter(object sender, EventArgs e) { }

        // ============================== KHỞI TẠO ==============================
        private void FormChinh_Load(object? sender, EventArgs e)
        {
            CauHinhGiaoDien();
            TaoMenu();
            LamMoiForm();
            TaiLaiDanhSachSinhVien();
        }

        private void CauHinhGiaoDien()
        {
            Text = "Quản Lý Sinh Viên";

            // Tiêu đề luôn nằm giữa header kể cả khi phóng to form
            lblQuanLyThongTinSV.AutoSize = false;
            lblQuanLyThongTinSV.Dock = DockStyle.Fill;
            lblQuanLyThongTinSV.TextAlign = ContentAlignment.MiddleCenter;

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.MaxDate = DateTime.Today;

            // Bài tập 2: sinh viên không còn chọn Khoa trực tiếp — Khoa đi theo Chuyên ngành
            // và được chọn ở form "Đăng ký Chuyên ngành". Ẩn ô Khoa + nút "+" (Designer giữ nguyên),
            // đẩy ô Điểm TB lên đúng chỗ ô Khoa cũ cho khỏi trống.
            lblKhoa.Visible = false;
            cboKhoa.Visible = false;
            btnCong.Visible = false;
            lblDiemTB.Location = lblKhoa.Location;
            txtDiemTB.Location = cboKhoa.Location;

            // Cột "Khoa" giờ hiển thị "Chuyên ngành (Khoa)"
            Khoa.HeaderText = "Chuyên ngành (Khoa)";

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Thêm mục con vào 2 menu "Tệp" và "Dữ liệu" đã vẽ sẵn
        private void TaoMenu()
        {
            tệpToolStripMenuItem.DropDownItems.Add("Thoát", null, (s, e) => Close());

            // Chèn 2 mục mới vào GIỮA "Quản lý khoa" và "Tra cứu Sinh viên" (giống hình mẫu)
            int viTri = dữLiệuToolStripMenuItem.DropDownItems.IndexOf(tìmKiếmToolStripMenuItem);
            dữLiệuToolStripMenuItem.DropDownItems.Insert(viTri,
                new ToolStripMenuItem("Quản lý Chuyên ngành", null, mnuQuanLyChuyenNganh_Click));
            dữLiệuToolStripMenuItem.DropDownItems.Insert(viTri + 1,
                new ToolStripMenuItem("Đăng ký Chuyên ngành", null, (s, e) => MoFormDangKy()));
        }

        // ============================== ĐỌC DỮ LIỆU ==============================
        private void TaiLaiDanhSachSinhVien()
        {
            try
            {
                List<SinhVien> dsSinhVien = sinhVienBLL.LayDanhSach();

                dataGridView1.Rows.Clear();
                foreach (SinhVien sv in dsSinhVien)
                {
                    // Thứ tự khớp 6 cột trong Designer: Mã SV | Họ và tên | Ngày sinh | Giới tính | Khoa | Điểm TB
                    int dong = dataGridView1.Rows.Add(
                        sv.MaSV,
                        sv.HoTen,
                        sv.NgaySinh.ToString("dd/MM/yyyy"),
                        sv.GioiTinh,
                        HienThiChuyenNganh(sv),
                        sv.DiemTB.HasValue ? sv.DiemTB.Value.ToString("0.##") : "Chưa có");

                    dataGridView1.Rows[dong].Tag = sv.Id;   // giấu Id vào Tag để dùng khi click chọn dòng
                }

                dataGridView1.ClearSelection();
                tslblTongSo.Text = $"Tổng số sinh viên: {dsSinhVien.Count}";
                tslblSanSang.Text = "Sẵn sàng";
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi kết nối", ex);
            }
        }

        // "Công nghệ phần mềm (Công nghệ thông tin)" hoặc "Chưa đăng ký"
        private static string HienThiChuyenNganh(SinhVien sv) =>
            sv.ChuyenNganh == null
                ? "Chưa đăng ký"
                : $"{sv.ChuyenNganh.TenChuyenNganh} ({sv.ChuyenNganh.Khoa?.TenKhoa})";

        // ============================== CLICK CHỌN DÒNG ==============================
        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;                                     // click vào tiêu đề cột
            if (dataGridView1.Rows[e.RowIndex].Tag is not int id) return;

            try
            {
                SinhVien? sv = sinhVienBLL.LayTheoId(id);
                if (sv == null) return;

                txtMaSoSV.Text = sv.MaSV;
                txtHoTen.Text = sv.HoTen;
                dtpNgaySinh.Value = sv.NgaySinh;
                radNam.Checked = sv.GioiTinh == "Nam";
                radNu.Checked = sv.GioiTinh == "Nữ";
                txtDiemTB.Text = sv.DiemTB.HasValue
                    ? sv.DiemTB.Value.ToString(CultureInfo.InvariantCulture)
                    : "";

                idDangSua = sv.Id;
                txtMaSoSV.Enabled = false;              // Mã SV là khóa định danh, không cho sửa
                tslblSanSang.Text = $"Đang chọn: {sv.MaSV} - {sv.HoTen}  |  Double-click để đăng ký chuyên ngành";
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi đọc dữ liệu", ex);
            }
        }

        // ==================== THÊM / SỬA / XÓA — gọi thẳng BLL, không tự validate ở đây ====================
        private void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                sinhVienBLL.ThemMoi(
                    txtMaSoSV.Text,
                    txtHoTen.Text,
                    dtpNgaySinh.Value,
                    radNam.Checked ? "Nam" : "Nữ",
                    txtDiemTB.Text);

                MessageBox.Show("Thêm sinh viên thành công!.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                TaiLaiDanhSachSinhVien();
            }
            catch (Exception ex)
            {
                // Toàn bộ lỗi validate (thiếu thông tin, trùng mã, điểm sai...) đều được
                // BLL ném ra dưới dạng Exception với message tiếng Việt dễ hiểu
                BaoLoi("Không thể thêm sinh viên", ex);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                sinhVienBLL.CapNhat(
                    idDangSua ?? 0,                     // 0 = chưa chọn -> BLL sẽ báo "Vui lòng chọn sinh viên"
                    txtMaSoSV.Text,
                    txtHoTen.Text,
                    dtpNgaySinh.Value,
                    radNam.Checked ? "Nam" : "Nữ",
                    txtDiemTB.Text);

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                TaiLaiDanhSachSinhVien();
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể cập nhật sinh viên", ex);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            // Chưa chọn dòng nào thì không hỏi xác nhận, chuyển thẳng cho BLL báo lỗi
            if (idDangSua.HasValue &&
                MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {txtMaSoSV.Text} - {txtHoTen.Text}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                sinhVienBLL.Xoa(idDangSua ?? 0);

                LamMoiForm();
                TaiLaiDanhSachSinhVien();
                tslblSanSang.Text = "Đã xóa sinh viên";
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể xóa sinh viên", ex);
                TaiLaiDanhSachSinhVien();
            }
        }

        // ============================== LÀM MỚI ==============================
        private void btnLamMoi_Click(object? sender, EventArgs e) => LamMoiForm();

        private void LamMoiForm()
        {
            txtMaSoSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            radNam.Checked = true;

            txtMaSoSV.Enabled = true;
            idDangSua = null;
            dataGridView1.ClearSelection();
            txtMaSoSV.Focus();
        }

        // ============================== MỞ CÁC FORM CON ==============================

        // ShowDialog: phải đóng form con mới quay lại FormChinh.
        // Form con có thể đã thay đổi Khoa / Chuyên ngành -> nạp lại bảng sinh viên sau khi đóng.
        private void mnuQuanLyKhoa_Click(object? sender, EventArgs e)
        {
            using var form = new FormQuanLyKhoa();
            form.ShowDialog(this);
            TaiLaiDanhSachSinhVien();
        }

        private void mnuQuanLyChuyenNganh_Click(object? sender, EventArgs e)
        {
            using var form = new FormQuanLyChuyenNganh();
            form.ShowDialog(this);
            TaiLaiDanhSachSinhVien();
        }

        // Đang chọn sinh viên nào trên bảng thì mở form Đăng ký với sinh viên đó được chọn sẵn
        private void MoFormDangKy()
        {
            using var form = new FormDangKyChuyenNganh(idDangSua);
            form.ShowDialog(this);
            LamMoiForm();
            TaiLaiDanhSachSinhVien();
        }

        private void mnuTimKiem_Click(object? sender, EventArgs e)
        {
            using var form = new FormTimKiemSinhVien();
            form.ShowDialog(this);
        }

        // ============================== HÀM PHỤ ==============================
        private void BaoLoi(string tieuDe, Exception ex)
        {
            MessageBox.Show(ex.GetBaseException().Message, tieuDe,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tslblSanSang.Text = tieuDe;
        }
    }
}
