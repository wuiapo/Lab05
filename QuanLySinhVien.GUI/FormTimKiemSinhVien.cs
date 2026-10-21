using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormTimKiemSinhVien : Form
    {
        // GUI chỉ gọi qua BLL
        private readonly SinhVienBLL sinhVienBLL = new SinhVienBLL();
        private readonly KhoaBLL khoaBLL = new KhoaBLL();

        // Trong lúc nạp ComboBox / xóa bộ lọc, các sự kiện "thay đổi" sẽ bắn liên tục -> tạm không tìm
        private bool dangNapDuLieu = false;

        public FormTimKiemSinhVien()
        {
            InitializeComponent();

            Load += FormTimKiemSinhVien_Load;

            // Tìm ngay khi người dùng thay đổi bất kỳ điều kiện lọc nào
            txtTuKhoa.TextChanged += (s, e) => TimKiem();
            cboKhoa.SelectedIndexChanged += (s, e) => TimKiem();
            nudDiemTu.ValueChanged += (s, e) => TimKiem();
            nudDiemDen.ValueChanged += (s, e) => TimKiem();
            chkBaoGomChuaCoDiem.CheckedChanged += (s, e) => TimKiem();
            btnXoaBoLoc.Click += btnXoaBoLoc_Click;
        }

        private void FormTimKiemSinhVien_Load(object? sender, EventArgs e)
        {
            // Tiêu đề cột nền xanh chữ trắng giống mẫu
            dgvKetQua.EnableHeadersVisualStyles = false;
            dgvKetQua.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 71, 161);
            dgvKetQua.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKetQua.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            NapDanhSachKhoa();
            TimKiem();
        }

        private void NapDanhSachKhoa()
        {
            dangNapDuLieu = true;
            try
            {
                // Mục đầu tiên Id = 0 nghĩa là "không lọc theo Khoa"
                List<Khoa> dsKhoa = khoaBLL.LayDanhSach();
                dsKhoa.Insert(0, new Khoa { Id = 0, TenKhoa = "-- Tất cả Khoa --" });

                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "Id";
                cboKhoa.DataSource = dsKhoa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangNapDuLieu = false;
            }
        }

        private void TimKiem()
        {
            if (dangNapDuLieu) return;

            try
            {
                int idKhoa = cboKhoa.SelectedValue as int? ?? 0;

                List<SinhVien> ketQua = sinhVienBLL.TimKiem(
                    txtTuKhoa.Text,
                    idKhoa == 0 ? null : idKhoa,          // 0 = "Tất cả Khoa"
                    (double)nudDiemTu.Value,
                    (double)nudDiemDen.Value,
                    chkBaoGomChuaCoDiem.Checked);

                HienThiKetQua(ketQua);
            }
            catch (Exception ex)
            {
                // Tìm theo từng lần gõ phím -> báo lỗi ngay trên nhãn kết quả thay vì bật MessageBox liên tục
                dgvKetQua.Rows.Clear();
                lblKetQua.ForeColor = Color.Firebrick;
                lblKetQua.Text = ex.GetBaseException().Message;
            }
        }

        private void HienThiKetQua(List<SinhVien> ketQua)
        {
            dgvKetQua.Rows.Clear();
            foreach (SinhVien sv in ketQua)
            {
                dgvKetQua.Rows.Add(
                    sv.Id,
                    sv.MaSV,
                    sv.HoTen,
                    sv.NgaySinh.ToString("dd/MM/yyyy"),
                    sv.GioiTinh,
                    sv.DiemTB.HasValue ? sv.DiemTB.Value.ToString("0.##") : "",
                    sv.ChuyenNganh?.Khoa?.TenKhoa ?? "Chưa đăng ký");   // Khoa lấy qua Chuyên ngành
            }
            dgvKetQua.ClearSelection();

            lblKetQua.ForeColor = Color.FromArgb(13, 71, 161);
            lblKetQua.Text = $"Tìm thấy: {ketQua.Count} sinh viên";
        }

        private void btnXoaBoLoc_Click(object? sender, EventArgs e)
        {
            dangNapDuLieu = true;
            txtTuKhoa.Clear();
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            nudDiemTu.Value = 0;
            nudDiemDen.Value = 10;
            chkBaoGomChuaCoDiem.Checked = true;
            dangNapDuLieu = false;

            TimKiem();
            txtTuKhoa.Focus();
        }
    }
}
