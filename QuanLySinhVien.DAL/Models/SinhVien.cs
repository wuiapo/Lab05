namespace QuanLySinhVien.DAL.Models
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string MaSV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "";
        public double? DiemTB { get; set; }

        // Bài tập 2 (Lab05): sinh viên KHÔNG thuộc Khoa trực tiếp nữa mà đăng ký theo Chuyên ngành.
        //   Xóa:  public int KhoaId { get; set; }   +   public Khoa? Khoa { get; set; }
        //   Thêm: ChuyenNganhId (int? — sinh viên mới tạo thì chưa đăng ký chuyên ngành) + navigation ChuyenNganh
        // Khoa của sinh viên lấy gián tiếp qua: sv.ChuyenNganh.Khoa
        public int? ChuyenNganhId { get; set; }
        public ChuyenNganh? ChuyenNganh { get; set; }
    }
}
