using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormDangKyChuyenNganh : Form
    {
        // GUI chỉ gọi qua BLL
        private readonly SinhVienBLL sinhVienBLL = new SinhVienBLL();
        private readonly KhoaBLL khoaBLL = new KhoaBLL();
        private readonly ChuyenNganhBLL chuyenNganhBLL = new ChuyenNganhBLL();

        // Sinh viên được chọn sẵn khi mở form (FormChinh truyền vào nếu đang chọn 1 dòng), có thể null
        private readonly int? idSinhVienChonSan;

        // Trong lúc gán DataSource cho ComboBox, SelectedIndexChanged bắn liên tục -> tạm bỏ qua
        private bool dangNapDuLieu = false;

        public FormDangKyChuyenNganh(int? idSinhVienChonSan = null)
        {
            InitializeComponent();
            this.idSinhVienChonSan = idSinhVienChonSan;

            Load += FormDangKyChuyenNganh_Load;
            cboSinhVien.Format += cboSinhVien_Format;
            cboSinhVien.SelectedIndexChanged += (s, e) => KhiChonSinhVien();
            cboKhoa.SelectedIndexChanged += (s, e) => { if (!dangNapDuLieu) TaiChuyenNganhTheoKhoa(); };
            btnDangKy.Click += btnDangKy_Click;
            // btnDong không cần code: Designer đã đặt DialogResult = Cancel -> bấm là đóng form
        }

        // ============================== KHỞI TẠO ==============================
        private void FormDangKyChuyenNganh_Load(object? sender, EventArgs e)
        {
            dangNapDuLieu = true;
            try
            {
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "Id";
                cboKhoa.DataSource = khoaBLL.LayDanhSach();

                cboSinhVien.ValueMember = "Id";
                cboSinhVien.DataSource = sinhVienBLL.LayDanhSach();
                if (idSinhVienChonSan.HasValue)
                    cboSinhVien.SelectedValue = idSinhVienChonSan.Value;
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi kết nối", ex);
            }
            finally
            {
                dangNapDuLieu = false;
            }

            KhiChonSinhVien();
        }

        // ComboBox sinh viên hiển thị dạng "25807700104 - Nguyễn Văn A"
        // (SinhVien không có thuộc tính nào chứa sẵn chuỗi này nên không dùng DisplayMember được)
        private void cboSinhVien_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is SinhVien sv)
                e.Value = $"{sv.MaSV} - {sv.HoTen}";
        }

        // ============================== CHỌN SINH VIÊN ==============================
        private void KhiChonSinhVien()
        {
            if (dangNapDuLieu) return;

            try
            {
                // Lấy lại từ database (không dùng object cũ trong ComboBox) để thấy được lần đăng ký vừa xong
                int idSV = cboSinhVien.SelectedValue as int? ?? 0;
                SinhVien? sv = idSV > 0 ? sinhVienBLL.LayTheoId(idSV) : null;
                ChuyenNganh? cnHienTai = sv?.ChuyenNganh;

                lblHienTai.Text = cnHienTai == null
                    ? "Chưa đăng ký"
                    : $"{cnHienTai.TenChuyenNganh} ({cnHienTai.Khoa?.TenKhoa})";

                // Sinh viên đã có chuyên ngành -> chọn sẵn Khoa + Chuyên ngành đó cho tiện đổi
                if (cnHienTai?.KhoaId != null)
                {
                    dangNapDuLieu = true;
                    cboKhoa.SelectedValue = cnHienTai.KhoaId.Value;
                    dangNapDuLieu = false;
                }
                TaiChuyenNganhTheoKhoa(cnHienTai?.Id);
            }
            catch (Exception ex)
            {
                dangNapDuLieu = false;
                BaoLoi("Lỗi", ex);
            }
        }

        // ============================== CHỌN KHOA -> LỌC CHUYÊN NGÀNH ==============================
        private void TaiChuyenNganhTheoKhoa(int? idChuyenNganhCanChon = null)
        {
            try
            {
                int khoaId = cboKhoa.SelectedValue as int? ?? 0;

                cboChuyenNganh.DisplayMember = "TenChuyenNganh";
                cboChuyenNganh.ValueMember = "Id";
                cboChuyenNganh.DataSource = khoaId > 0
                    ? chuyenNganhBLL.LayTheoKhoa(khoaId)
                    : new List<ChuyenNganh>();

                if (idChuyenNganhCanChon.HasValue)
                    cboChuyenNganh.SelectedValue = idChuyenNganhCanChon.Value;
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi đọc dữ liệu", ex);
            }
        }

        // ============================== ĐĂNG KÝ ==============================
        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            try
            {
                // Toàn bộ kiểm tra (đã chọn đủ chưa, chuyên ngành có thuộc Khoa không, có đăng ký trùng không)
                // nằm trong SinhVienBLL.DangKyChuyenNganh()
                sinhVienBLL.DangKyChuyenNganh(
                    cboSinhVien.SelectedValue as int? ?? 0,
                    cboKhoa.SelectedValue as int? ?? 0,
                    cboChuyenNganh.SelectedValue as int? ?? 0);

                MessageBox.Show($"Đã đăng ký chuyên ngành \"{cboChuyenNganh.Text}\" cho sinh viên {cboSinhVien.Text}.",
                    "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                KhiChonSinhVien();   // cập nhật dòng "Chuyên ngành hiện tại"
            }
            catch (Exception ex)
            {
                BaoLoi("Không thể đăng ký", ex);
            }
        }

        private static void BaoLoi(string tieuDe, Exception ex)
        {
            MessageBox.Show(ex.GetBaseException().Message, tieuDe,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
