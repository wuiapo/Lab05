using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.DAL
{
    /// <summary>
    /// Tầng truy cập dữ liệu của Sinh viên: CHỈ chứa CRUD thuần túy, không có if validate nào.
    /// Mỗi hàm tự mở một DbContext riêng (using) và hủy ngay khi xong, không giữ DbContext sống lâu.
    /// </summary>
    public class SinhVienDAL
    {
        // Quan hệ 2 cấp: SinhVien -> ChuyenNganh -> Khoa
        // Include nạp cấp 1 (ChuyenNganh), ThenInclude nạp tiếp cấp 2 (Khoa của chuyên ngành đó)
        private static IQueryable<SinhVien> TruyVanDayDu(QuanLySinhVienDbContext db) =>
            db.SinhViens
                .Include(sv => sv.ChuyenNganh)
                    .ThenInclude(cn => cn!.Khoa);

        public List<SinhVien> LayDanhSach()
        {
            using var db = new QuanLySinhVienDbContext();
            return TruyVanDayDu(db).OrderBy(sv => sv.MaSV).ToList();
        }

        public SinhVien? LayTheoId(int id)
        {
            using var db = new QuanLySinhVienDbContext();
            return TruyVanDayDu(db).FirstOrDefault(sv => sv.Id == id);
        }

        public bool KiemTraTrungMa(string maSV)
        {
            using var db = new QuanLySinhVienDbContext();
            // Any() dừng ngay khi gặp bản ghi đầu tiên -> nhanh hơn Where().Count() > 0
            return db.SinhViens.Any(sv => sv.MaSV == maSV);
        }

        public void ThemMoi(SinhVien sv)
        {
            using var db = new QuanLySinhVienDbContext();
            db.SinhViens.Add(sv);
            db.SaveChanges();   // chưa gọi SaveChanges thì chưa ghi xuống database
        }

        public void CapNhat(SinhVien sv)
        {
            using var db = new QuanLySinhVienDbContext();

            // Bước 1: tìm lại bản ghi GỐC theo Id. Object "sv" truyền vào KHÔNG được DbContext này
            // theo dõi (tracking), nên phải sửa trên object lấy từ chính db này thì EF mới biết mà lưu.
            SinhVien? svTrongDb = db.SinhViens.Find(sv.Id);

            if (svTrongDb == null)
                throw new Exception("Sinh viên này không còn tồn tại trong CSDL (có thể đã bị xóa).");

            // Bước 2: gán lại từng thuộc tính. KHÔNG gán Id, MaSV.
            // KHÔNG gán ChuyenNganhId: chuyên ngành chỉ đổi qua chức năng Đăng ký (hàm DangKyChuyenNganh bên dưới)
            svTrongDb.HoTen = sv.HoTen;
            svTrongDb.NgaySinh = sv.NgaySinh;
            svTrongDb.GioiTinh = sv.GioiTinh;
            svTrongDb.DiemTB = sv.DiemTB;

            // Bước 3: lưu thay đổi
            db.SaveChanges();
        }

        public void DangKyChuyenNganh(int sinhVienId, int chuyenNganhId)
        {
            using var db = new QuanLySinhVienDbContext();
            SinhVien? sv = db.SinhViens.Find(sinhVienId);
            if (sv == null)
                throw new Exception("Sinh viên này không còn tồn tại trong CSDL (có thể đã bị xóa).");

            sv.ChuyenNganhId = chuyenNganhId;
            db.SaveChanges();
        }

        public void Xoa(int id)
        {
            using var db = new QuanLySinhVienDbContext();
            SinhVien? sv = db.SinhViens.Find(id);
            if (sv == null)
                throw new Exception("Sinh viên này không còn tồn tại trong CSDL (có thể đã bị xóa).");

            db.SinhViens.Remove(sv);
            db.SaveChanges();
        }

        public List<SinhVien> TimKiem(string? tuKhoaVanBan, int? khoaId,
            double diemTu, double diemDen, bool baoGomChuaCoDiem)
        {
            using var db = new QuanLySinhVienDbContext();

            // Bước 1: bắt đầu truy vấn với Include, AsQueryable() để có thể "xếp chồng" thêm Where()
            IQueryable<SinhVien> truyVan = TruyVanDayDu(db).AsQueryable();

            // Bước 2: có từ khóa -> lọc theo MaSV hoặc HoTen (Contains, không phân biệt hoa/thường)
            if (!string.IsNullOrWhiteSpace(tuKhoaVanBan))
            {
                string tuKhoa = tuKhoaVanBan.Trim().ToLower();
                truyVan = truyVan.Where(sv => sv.MaSV.ToLower().Contains(tuKhoa)
                                           || sv.HoTen.ToLower().Contains(tuKhoa));
            }

            // Bước 3: có chọn Khoa -> lọc theo Khoa CỦA CHUYÊN NGÀNH (sinh viên không còn KhoaId trực tiếp).
            // Sinh viên chưa đăng ký chuyên ngành thì không thuộc Khoa nào -> bị loại khi lọc theo Khoa.
            if (khoaId.HasValue)
                truyVan = truyVan.Where(sv => sv.ChuyenNganh != null && sv.ChuyenNganh.KhoaId == khoaId.Value);

            // Bước 4: khoảng Điểm TB.
            // DiemTB là double? -> sinh viên chưa có điểm (null) KHÔNG thỏa "DiemTB >= diemTu" nên sẽ bị loại.
            // Vì vậy phải xét riêng trường hợp null theo cờ baoGomChuaCoDiem. Phần điều kiện có rẽ nhánh này
            // được lọc trong bộ nhớ (sau ToList) để logic C# rõ ràng, không phụ thuộc cách dịch sang SQL.
            List<SinhVien> ketQua = truyVan.OrderBy(sv => sv.MaSV).ToList();

            return ketQua
                .Where(sv => sv.DiemTB.HasValue
                    ? sv.DiemTB.Value >= diemTu && sv.DiemTB.Value <= diemDen
                    : baoGomChuaCoDiem)
                .ToList();
        }
    }
}
