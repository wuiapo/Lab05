using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.DAL
{
    /// <summary>
    /// Tầng truy cập dữ liệu của Khoa: CHỈ chứa CRUD thuần túy, không có if validate nào.
    /// </summary>
    public class KhoaDAL
    {
        public List<Khoa> LayDanhSach()
        {
            using var db = new QuanLySinhVienDbContext();
            // Sắp xếp theo Tên Khoa cho danh sách ComboBox dễ nhìn
            return db.Khoas.OrderBy(k => k.TenKhoa).ToList();
        }

        public Khoa? LayTheoId(int id)
        {
            using var db = new QuanLySinhVienDbContext();
            return db.Khoas.Find(id);
        }

        public bool KiemTraTrungTen(string tenKhoa, int? idLoaiTru = null)
        {
            using var db = new QuanLySinhVienDbContext();

            // (1) TenKhoa trùng với tenKhoa truyền vào
            // (2) NHƯNG không tính bản ghi có Id == idLoaiTru (khi đang Sửa, không so với chính nó)
            // Viết "idLoaiTru == null ||" để xử lý rõ ràng trường hợp Thêm mới (không loại trừ ai),
            // thay vì phụ thuộc vào việc so sánh int với int? null.
            return db.Khoas.Any(k => k.TenKhoa == tenKhoa
                                  && (idLoaiTru == null || k.Id != idLoaiTru.Value));
        }

        public void ThemMoi(Khoa khoa)
        {
            using var db = new QuanLySinhVienDbContext();
            db.Khoas.Add(khoa);
            db.SaveChanges();   // sau dòng này khoa.Id đã có giá trị
        }

        public void CapNhat(Khoa khoa)
        {
            using var db = new QuanLySinhVienDbContext();

            // Bước 1: tìm bản ghi GỐC theo khoa.Id
            Khoa? khoaTrongDb = db.Khoas.Find(khoa.Id);

            // Bước 2: không tìm thấy -> báo lỗi (giống SinhVienDAL.CapNhat), không âm thầm bỏ qua
            if (khoaTrongDb == null)
                throw new Exception("Khoa này không còn tồn tại trong CSDL (có thể đã bị xóa).");

            // Bước 3: gán lại từng thuộc tính. KHÔNG gán Id: Id là khóa chính, EF Core không cho đổi
            khoaTrongDb.TenKhoa = khoa.TenKhoa;
            khoaTrongDb.NamThanhLap = khoa.NamThanhLap;
            khoaTrongDb.TongSoGiangVien = khoa.TongSoGiangVien;

            // Bước 4: lưu thay đổi
            db.SaveChanges();
        }

        public void Xoa(int id)
        {
            using var db = new QuanLySinhVienDbContext();
            // Hàm này KHÔNG kiểm tra "còn sinh viên hay không" — BLL đã làm việc đó trước khi gọi tới đây
            Khoa? khoa = db.Khoas.Find(id);
            if (khoa == null)
                throw new Exception("Khoa này không còn tồn tại trong CSDL (có thể đã bị xóa).");

            db.Khoas.Remove(khoa);
            db.SaveChanges();
        }

        public int DemSoSinhVienThuocKhoa(int khoaId)
        {
            using var db = new QuanLySinhVienDbContext();
            // Bài tập 2: SinhVien không còn KhoaId -> đếm qua Chuyên ngành của sinh viên
            // Count() đếm ngay trên SQL Server (SELECT COUNT), không kéo cả danh sách về bộ nhớ
            return db.SinhViens.Count(sv => sv.ChuyenNganh != null && sv.ChuyenNganh.KhoaId == khoaId);
        }

        public int DemSoChuyenNganhThuocKhoa(int khoaId)
        {
            using var db = new QuanLySinhVienDbContext();
            return db.ChuyenNganhs.Count(cn => cn.KhoaId == khoaId);
        }
    }
}
