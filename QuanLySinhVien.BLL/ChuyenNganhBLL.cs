using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.BLL
{
    /// <summary>
    /// Tầng nghiệp vụ của Chuyên ngành: validate dữ liệu và quyết định có cho thêm/sửa/xóa hay không.
    /// </summary>
    public class ChuyenNganhBLL
    {
        private readonly ChuyenNganhDAL chuyenNganhDAL = new ChuyenNganhDAL();

        public List<ChuyenNganh> LayDanhSach() => chuyenNganhDAL.LayDanhSach();

        public List<ChuyenNganh> LayTheoKhoa(int khoaId) => chuyenNganhDAL.LayTheoKhoa(khoaId);

        public ChuyenNganh? LayTheoId(int id) => chuyenNganhDAL.LayTheoId(id);

        private void ValidateDuLieu(string tenChuyenNganh, int khoaId)
        {
            if (string.IsNullOrWhiteSpace(tenChuyenNganh))
                throw new Exception("Vui lòng nhập Tên chuyên ngành!");

            if (khoaId <= 0)
                throw new Exception("Vui lòng chọn Khoa cho chuyên ngành! (Nếu chưa có Khoa nào, vào Quản lý Khoa để thêm trước)");
        }

        public void ThemMoi(string tenChuyenNganh, int khoaId)
        {
            ValidateDuLieu(tenChuyenNganh, khoaId);
            tenChuyenNganh = tenChuyenNganh.Trim();

            if (chuyenNganhDAL.KiemTraTrungTen(tenChuyenNganh, khoaId))
                throw new Exception($"Chuyên ngành \"{tenChuyenNganh}\" đã có trong Khoa này!");

            chuyenNganhDAL.ThemMoi(new ChuyenNganh
            {
                TenChuyenNganh = tenChuyenNganh,
                KhoaId = khoaId
            });
        }

        public void CapNhat(int id, string tenChuyenNganh, int khoaId)
        {
            if (id <= 0)
                throw new Exception("Vui lòng chọn chuyên ngành cần sửa!");

            ValidateDuLieu(tenChuyenNganh, khoaId);
            tenChuyenNganh = tenChuyenNganh.Trim();

            // Sửa -> truyền idLoaiTru để không bị báo trùng với chính nó
            if (chuyenNganhDAL.KiemTraTrungTen(tenChuyenNganh, khoaId, id))
                throw new Exception($"Chuyên ngành \"{tenChuyenNganh}\" đã có trong Khoa này!");

            chuyenNganhDAL.CapNhat(new ChuyenNganh
            {
                Id = id,
                TenChuyenNganh = tenChuyenNganh,
                KhoaId = khoaId
            });
        }

        public void Xoa(int id)
        {
            if (id <= 0)
                throw new Exception("Vui lòng chọn chuyên ngành cần xóa!");

            // Còn sinh viên đăng ký chuyên ngành này -> không cho xóa, nêu rõ số lượng
            int soSinhVien = chuyenNganhDAL.DemSoSinhVienThuocChuyenNganh(id);
            if (soSinhVien > 0)
            {
                string ten = chuyenNganhDAL.LayTheoId(id)?.TenChuyenNganh ?? "";
                throw new Exception(
                    $"Không thể xóa chuyên ngành \"{ten}\" vì đang có {soSinhVien} sinh viên đăng ký.\n" +
                    "Hãy cho các sinh viên này đăng ký chuyên ngành khác trước.");
            }

            chuyenNganhDAL.Xoa(id);
        }
    }
}
