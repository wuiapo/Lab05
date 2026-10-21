# Lab05 – Mô hình 3 lớp (Bài tập 1 + Bài tập 2 gộp chung)

```
Lab05.sln
├── QuanLySinhVien.DAL   (Class Library)
│     Models/ SinhVien, Khoa, ChuyenNganh
│     QuanLySinhVienDbContext, Migrations/ (đã có sẵn migration ThemChuyenNganh)
│     SinhVienDAL, KhoaDAL, ChuyenNganhDAL
├── QuanLySinhVien.BLL   (Class Library)   SinhVienBLL, KhoaBLL, ChuyenNganhBLL     → reference DAL
└── QuanLySinhVien.GUI   (Windows Forms)   FormChinh, FormQuanLyKhoa, FormThemKhoa,
                                           FormTimKiemSinhVien, FormQuanLyChuyenNganh,
                                           FormDangKyChuyenNganh                     → reference CHỈ BLL
```

## Chạy (3 bước)
1. Giải nén ra một thư mục MỚI, mở **Lab05.sln** (không Add vào solution cũ).
2. Package Manager Console → Default project = **QuanLySinhVien.DAL** → gõ:
   ```
   Update-Database -StartupProject QuanLySinhVien.DAL
   ```
   Migration Bài 2 (ThemChuyenNganh) đã viết sẵn, KHÔNG cần Add-Migration.
3. Chuột phải **QuanLySinhVien.GUI** → Set as Startup Project → F5.

Chuỗi kết nối: `Server=localhost\SQLEXPRESS;Database=QuanLySinhVienDb` (trong QuanLySinhVienDbContext.cs).
Máy dùng SQL Server khác thì sửa dòng này trước khi Update-Database.

## Lưu ý dữ liệu cũ
Migration Bài 2 xóa cột SinhViens.KhoaId (sinh viên giờ thuộc Khoa thông qua Chuyên ngành),
nên sinh viên đã có từ Lab04 sẽ hiện "Chưa đăng ký" → vào Đăng ký Chuyên ngành để gán lại.

## Thứ tự dùng thử
Quản lý Khoa (F1) → Quản lý Chuyên ngành → thêm Sinh viên → Đăng ký Chuyên ngành → Tra cứu (Ctrl+F)
Double-click 1 sinh viên trên bảng chính = mở form Đăng ký với sinh viên đó được chọn sẵn.
