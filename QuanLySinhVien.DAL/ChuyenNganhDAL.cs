using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.DAL
{
    /// <summary>
    /// Tầng truy cập dữ liệu của Chuyên ngành: CHỈ chứa CRUD thuần túy, không có if validate nào.
    /// </summary>
    public class ChuyenNganhDAL
    {
        public List<ChuyenNganh> LayDanhSach()
        {
            using var db = new QuanLySinhVienDbContext();
            // Include Khoa để hiển thị cột "Khoa" trên DataGridView
            return db.ChuyenNganhs
                .Include(cn => cn.Khoa)
                .OrderBy(cn => cn.Khoa!.TenKhoa)
                .ThenBy(cn => cn.TenChuyenNganh)
                .ToList();
        }

        // Dùng cho form Đăng ký: chọn Khoa nào thì chỉ hiện Chuyên ngành của Khoa đó
        public List<ChuyenNganh> LayTheoKhoa(int khoaId)
        {
            using var db = new QuanLySinhVienDbContext();
            return db.ChuyenNganhs
                .Where(cn => cn.KhoaId == khoaId)
                .OrderBy(cn => cn.TenChuyenNganh)
                .ToList();
        }

        public ChuyenNganh? LayTheoId(int id)
        {
            using var db = new QuanLySinhVienDbContext();
            return db.ChuyenNganhs
                .Include(cn => cn.Khoa)
                .FirstOrDefault(cn => cn.Id == id);
        }

        // Trùng tên trong CÙNG một Khoa (2 Khoa khác nhau có thể có chuyên ngành cùng tên)
        public bool KiemTraTrungTen(string tenChuyenNganh, int khoaId, int? idLoaiTru = null)
        {
            using var db = new QuanLySinhVienDbContext();
            return db.ChuyenNganhs.Any(cn => cn.TenChuyenNganh == tenChuyenNganh
                                          && cn.KhoaId == khoaId
                                          && (idLoaiTru == null || cn.Id != idLoaiTru.Value));
        }

        public void ThemMoi(ChuyenNganh chuyenNganh)
        {
            using var db = new QuanLySinhVienDbContext();
            db.ChuyenNganhs.Add(chuyenNganh);
            db.SaveChanges();
        }

        public void CapNhat(ChuyenNganh chuyenNganh)
        {
            using var db = new QuanLySinhVienDbContext();

            // Tìm bản ghi GỐC theo Id rồi gán lại từng thuộc tính (không gán Id)
            ChuyenNganh? cnTrongDb = db.ChuyenNganhs.Find(chuyenNganh.Id);
            if (cnTrongDb == null)
                throw new Exception("Chuyên ngành này không còn tồn tại trong CSDL (có thể đã bị xóa).");

            cnTrongDb.TenChuyenNganh = chuyenNganh.TenChuyenNganh;
            cnTrongDb.KhoaId = chuyenNganh.KhoaId;
            db.SaveChanges();
        }

        public void Xoa(int id)
        {
            using var db = new QuanLySinhVienDbContext();
            // Không kiểm tra "còn sinh viên không" ở đây — BLL đã làm trước khi gọi tới
            ChuyenNganh? cn = db.ChuyenNganhs.Find(id);
            if (cn == null)
                throw new Exception("Chuyên ngành này không còn tồn tại trong CSDL (có thể đã bị xóa).");

            db.ChuyenNganhs.Remove(cn);
            db.SaveChanges();
        }

        public int DemSoSinhVienThuocChuyenNganh(int chuyenNganhId)
        {
            using var db = new QuanLySinhVienDbContext();
            return db.SinhViens.Count(sv => sv.ChuyenNganhId == chuyenNganhId);
        }
    }
}
