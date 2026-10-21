using QuanLySinhVien.BLL;

namespace QuanLySinhVien.GUI
{
    public partial class FormThemKhoa : Form
    {
        private readonly KhoaBLL khoaBLL = new KhoaBLL();

        // Form cha (FormChinh) đọc property này SAU KHI ShowDialog() trả về DialogResult.OK
        public string TenKhoaMoi { get; private set; } = "";

        public FormThemKhoa()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate (tên trống, trùng tên...) đều nằm trong KhoaBLL
                khoaBLL.ThemMoi(txtTenKhoa.Text, null, null);

                TenKhoaMoi = txtTenKhoa.Text.Trim();
                MessageBox.Show("Thêm khoa mới thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gán DialogResult -> form đang mở bằng ShowDialog() sẽ tự đóng và trả về OK
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // Lỗi -> giữ form mở để người dùng sửa lại tên
                MessageBox.Show(ex.GetBaseException().Message, "Không thể thêm khoa",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhoa.Focus();
            }
        }

        // Nút Hủy không cần viết code: trong Designer đã đặt btnHuy.DialogResult = Cancel
    }
}
