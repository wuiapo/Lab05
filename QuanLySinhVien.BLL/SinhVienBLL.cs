using System.Globalization;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.BLL
{
    /// <summary>
    /// Tầng nghiệp vụ của Sinh viên: chứa TOÀN BỘ logic validate.
    /// Gặp dữ liệu sai -> throw Exception với thông báo tiếng Việt, GUI chỉ việc bắt và hiện lên MessageBox.
    /// </summary>
    public class SinhVienBLL
    {
        private readonly SinhVienDAL sinhVienDAL = new SinhVienDAL();
        private readonly ChuyenNganhDAL chuyenNganhDAL = new ChuyenNganhDAL();

        public List<SinhVien> LayDanhSach()
        {
            // Không có gì để validate, gọi thẳng DAL
            return sinhVienDAL.LayDanhSach();
        }

        public SinhVien? LayTheoId(int id)
        {
            return sinhVienDAL.LayTheoId(id);
        }

        /// Hàm dùng chung cho ThemMoi() và CapNhat() — validate mọi điều kiện,
        /// đồng thời "xuất" ra giá trị diemTB đã parse xong (qua tham số out).
        private void ValidateDuLieu(string maSV, string hoTen, string? diemTBText, out double? diemTB)
        {
            // Bước 1: Mã SV không được trống
            if (string.IsNullOrWhiteSpace(maSV))
                throw new Exception("Vui lòng nhập Mã SV!");

            // Bước 2: Họ tên không được trống
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new Exception("Vui lòng nhập Họ tên!");

            // Bước 3: Điểm TB — CHỈ validate nếu người dùng CÓ nhập (được phép để trống = chưa có điểm)
            diemTB = null;
            if (!string.IsNullOrWhiteSpace(diemTBText))
            {
                // Chấp nhận cả "8.5" và "8,5". Dùng InvariantCulture vì máy cài tiếng Việt
                // sẽ hiểu "8.5" thành 85 nếu parse theo culture mặc định.
                string chuoiDiem = diemTBText.Trim().Replace(',', '.');

                // 3a. Parse có thành công không? (TryParse, không dùng Parse để tránh văng lỗi FormatException)
                if (!double.TryParse(chuoiDiem, NumberStyles.Float, CultureInfo.InvariantCulture, out double diem))
                    throw new Exception("Điểm TB phải là số hợp lệ (ví dụ: 7.5)!");

                // 3b. Có nằm trong khoảng 0 - 10 không?
                if (diem < 0 || diem > 10)
                    throw new Exception("Điểm TB phải nằm trong khoảng 0 - 10!");

                // 3c. Qua hết 2 bước trên -> gán vào diemTB
                diemTB = diem;
            }
        }

        public void ThemMoi(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh,
            string? diemTBText)
        {
            // Bước 1: validate — nếu có lỗi, hàm này tự throw, code dừng lại luôn tại đây
            ValidateDuLieu(maSV, hoTen, diemTBText, out double? diemTB);

            // Bước 2: kiểm tra trùng Mã SV. Phải Trim() TRƯỚC khi so sánh/lưu,
            // nếu không " 001" và "001" sẽ bị coi là 2 mã khác nhau.
            maSV = maSV.Trim();
            if (sinhVienDAL.KiemTraTrungMa(maSV))
                throw new Exception($"Mã SV \"{maSV}\" đã tồn tại!");

            // Bước 3: tạo object SinhVien mới, gọi DAL
            sinhVienDAL.ThemMoi(new SinhVien
            {
                MaSV = maSV,
                HoTen = hoTen.Trim(),
                NgaySinh = ngaySinh.Date,
                GioiTinh = gioiTinh,
                DiemTB = diemTB
            });
        }

        public void CapNhat(int id, string maSVHienTai, string hoTen, DateTime ngaySinh,
            string gioiTinh, string? diemTBText)
        {
            if (id <= 0)
                throw new Exception("Vui lòng chọn sinh viên cần sửa!");

            // Tương tự ThemMoi() nhưng KHÔNG kiểm tra trùng mã:
            // Mã SV không được sửa, nên mã hiện tại chắc chắn "trùng" với chính bản ghi này.
            ValidateDuLieu(maSVHienTai, hoTen, diemTBText, out double? diemTB);

            // Nhớ truyền "Id" vào object — thiếu Id thì DAL không biết cập nhật bản ghi nào
            sinhVienDAL.CapNhat(new SinhVien
            {
                Id = id,
                MaSV = maSVHienTai.Trim(),
                HoTen = hoTen.Trim(),
                NgaySinh = ngaySinh.Date,
                GioiTinh = gioiTinh,
                DiemTB = diemTB
            });
        }

        /// <summary>
        /// Bài tập 2: đăng ký (hoặc đổi) chuyên ngành cho sinh viên.
        /// khoaId là Khoa đang chọn trên form — dùng để chắc chắn chuyên ngành thuộc đúng Khoa đó.
        /// </summary>
        public void DangKyChuyenNganh(int sinhVienId, int khoaId, int chuyenNganhId)
        {
            if (sinhVienId <= 0)
                throw new Exception("Vui lòng chọn sinh viên!");
            if (khoaId <= 0)
                throw new Exception("Vui lòng chọn Khoa!");
            if (chuyenNganhId <= 0)
                throw new Exception("Khoa này chưa có chuyên ngành nào, hoặc bạn chưa chọn chuyên ngành!");

            SinhVien? sv = sinhVienDAL.LayTheoId(sinhVienId)
                ?? throw new Exception("Sinh viên này không còn tồn tại trong CSDL!");
            ChuyenNganh? cn = chuyenNganhDAL.LayTheoId(chuyenNganhId)
                ?? throw new Exception("Chuyên ngành này không còn tồn tại trong CSDL!");

            if (cn.KhoaId != khoaId)
                throw new Exception($"Chuyên ngành \"{cn.TenChuyenNganh}\" không thuộc Khoa đã chọn!");

            if (sv.ChuyenNganhId == chuyenNganhId)
                throw new Exception($"Sinh viên {sv.HoTen} đã đăng ký chuyên ngành \"{cn.TenChuyenNganh}\" rồi!");

            sinhVienDAL.DangKyChuyenNganh(sinhVienId, chuyenNganhId);
        }

        public void Xoa(int id)
        {
            // Không có bảng con nào phụ thuộc vào SinhVien (khác với KhoaBLL.Xoa) -> chỉ cần Id hợp lệ
            if (id <= 0)
                throw new Exception("Vui lòng chọn sinh viên cần xóa!");

            sinhVienDAL.Xoa(id);
        }

        public List<SinhVien> TimKiem(string? tuKhoaVanBan, int? khoaId,
            double diemTu, double diemDen, bool baoGomChuaCoDiem)
        {
            // Bước 1: kiểm tra tính hợp lý của khoảng điểm
            if (diemTu < 0 || diemDen > 10)
                throw new Exception("Khoảng Điểm TB phải nằm trong 0 - 10!");
            if (diemTu > diemDen)
                throw new Exception("\"Điểm TB từ\" không được lớn hơn \"đến\"!");

            // Bước 2: gọi DAL thực hiện tìm kiếm
            return sinhVienDAL.TimKiem(tuKhoaVanBan, khoaId, diemTu, diemDen, baoGomChuaCoDiem);
        }
    }
}
