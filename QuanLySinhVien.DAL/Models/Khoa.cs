namespace QuanLySinhVien.DAL.Models
{
    public class Khoa
    {
        public int Id { get; set; }                     // Khóa chính (EF Core tự nhận diện tên "Id")
        public string TenKhoa { get; set; } = "";

        // Kiểu int? (cho phép null) vì các khoa đã có trong database chưa có dữ liệu này -> "Chưa có".
        public int? NamThanhLap { get; set; }
        public int? TongSoGiangVien { get; set; }

        // Bài tập 2: navigation property ngược lại -> 1 Khoa có nhiều Chuyên ngành (truy vấn được 2 chiều)
        public ICollection<ChuyenNganh> ChuyenNganhs { get; set; } = new List<ChuyenNganh>();

        public override string ToString() => TenKhoa;
    }
}
