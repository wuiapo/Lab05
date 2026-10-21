namespace QuanLySinhVien.DAL.Models
{
    public class ChuyenNganh
    {
        public int Id { get; set; }                         // Khóa chính
        public string TenChuyenNganh { get; set; } = "";

        public int? KhoaId { get; set; }                    // Khóa ngoại trỏ tới Khoa
        public Khoa? Khoa { get; set; }                     // Navigation property

        public override string ToString() => TenChuyenNganh;
    }
}
