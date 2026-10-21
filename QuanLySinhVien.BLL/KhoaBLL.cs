using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.BLL
{
    /// <summary>
    /// Tầng nghiệp vụ của Khoa: validate dữ liệu và QUYẾT ĐỊNH có cho thêm/sửa/xóa hay không.
    /// </summary>
    public class KhoaBLL
    {
        private readonly KhoaDAL khoaDAL = new KhoaDAL();

        public List<Khoa> LayDanhSach()
        {
            // Không cần validate gì — chỉ đọc dữ liệu
            return khoaDAL.LayDanhSach();
        }

        public Khoa? LayTheoId(int id)
        {
            return khoaDAL.LayTheoId(id);
        }

        private void ValidateDuLieu(string tenKhoa, int? namThanhLap, int? tongSoGiangVien)
        {
            // Bước 1: Tên Khoa bắt buộc phải có
            if (string.IsNullOrWhiteSpace(tenKhoa))
                throw new Exception("Vui lòng nhập Tên Khoa!");

            // Bước 2: Năm thành lập — CHỈ kiểm tra nếu người dùng CÓ nhập. Hợp lệ: 1900 -> năm hiện tại
            if (namThanhLap.HasValue && (namThanhLap.Value < 1900 || namThanhLap.Value > DateTime.Now.Year))
                throw new Exception($"Năm thành lập phải nằm trong khoảng 1900 - {DateTime.Now.Year}!");

            // Bước 3: Tổng số Giảng viên — CHỈ kiểm tra nếu CÓ nhập, không được là số âm
            if (tongSoGiangVien.HasValue && tongSoGiangVien.Value < 0)
                throw new Exception("Tổng số Giảng viên không được là số âm!");
        }

        public void ThemMoi(string tenKhoa, int? namThanhLap, int? tongSoGiangVien)
        {
            // Bước 1: validate
            ValidateDuLieu(tenKhoa, namThanhLap, tongSoGiangVien);
            tenKhoa = tenKhoa.Trim();

            // Bước 2: kiểm tra trùng tên. Thêm mới -> gọi với 1 tham số (chưa có Id nào cần loại trừ)
            if (khoaDAL.KiemTraTrungTen(tenKhoa))
                throw new Exception($"Khoa \"{tenKhoa}\" đã tồn tại!");

            // Bước 3: tạo object Khoa mới, gọi DAL
            khoaDAL.ThemMoi(new Khoa
            {
                TenKhoa = tenKhoa,
                NamThanhLap = namThanhLap,
                TongSoGiangVien = tongSoGiangVien
            });
        }

        public void CapNhat(int id, string tenKhoa, int? namThanhLap, int? tongSoGiangVien)
        {
            if (id <= 0)
                throw new Exception("Vui lòng chọn khoa cần sửa!");

            ValidateDuLieu(tenKhoa, namThanhLap, tongSoGiangVien);
            tenKhoa = tenKhoa.Trim();

            // Sửa -> PHẢI truyền idLoaiTru: nếu không, giữ nguyên tên cũ và bấm Sửa
            // sẽ bị báo "trùng" với chính bản ghi đang sửa.
            if (khoaDAL.KiemTraTrungTen(tenKhoa, id))
                throw new Exception($"Khoa \"{tenKhoa}\" đã tồn tại!");

            // Tạo object Khoa (nhớ gán cả "Id"), gọi DAL
            khoaDAL.CapNhat(new Khoa
            {
                Id = id,
                TenKhoa = tenKhoa,
                NamThanhLap = namThanhLap,
                TongSoGiangVien = tongSoGiangVien
            });
        }

        /// <summary>
        /// Xóa Khoa — BLL chịu trách nhiệm QUYẾT ĐỊNH có cho xóa hay không.
        /// </summary>
        public void Xoa(int id)
        {
            if (id <= 0)
                throw new Exception("Vui lòng chọn khoa cần xóa!");

            string tenKhoa = khoaDAL.LayTheoId(id)?.TenKhoa ?? "";

            // Bài tập 2: Khoa còn Chuyên ngành -> không cho xóa (Chuyên ngành trỏ tới Khoa bằng khóa ngoại)
            int soChuyenNganh = khoaDAL.DemSoChuyenNganhThuocKhoa(id);
            if (soChuyenNganh > 0)
                throw new Exception(
                    $"Không thể xóa khoa \"{tenKhoa}\" vì đang có {soChuyenNganh} chuyên ngành thuộc khoa này.\n" +
                    "Hãy xóa (hoặc chuyển) các chuyên ngành đó trước.");

            // Bước 1: hỏi DAL — Khoa này hiện có bao nhiêu sinh viên (qua chuyên ngành)?
            int soSinhVien = khoaDAL.DemSoSinhVienThuocKhoa(id);

            // Bước 2: nếu > 0, KHÔNG cho xóa — nêu rõ con số cụ thể
            if (soSinhVien > 0)
            {
                throw new Exception(
                    $"Không thể xóa khoa \"{tenKhoa}\" vì đang có {soSinhVien} sinh viên thuộc khoa này.\n" +
                    "Hãy chuyển các sinh viên sang khoa khác (hoặc xóa họ) trước.");
            }

            // Bước 3: hợp lệ (không còn sinh viên nào) -> mới thật sự gọi DAL
            khoaDAL.Xoa(id);
        }
    }
}
