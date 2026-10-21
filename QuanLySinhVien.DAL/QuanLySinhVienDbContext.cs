using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.DAL
{
    public class QuanLySinhVienDbContext : DbContext
    {
        public DbSet<SinhVien> SinhViens { get; set; } = null!;
        public DbSet<Khoa> Khoas { get; set; } = null!;
        public DbSet<ChuyenNganh> ChuyenNganhs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\ECUSSQL2008;Database=QuanLySinhVienDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1 Khoa - nhiều Chuyên ngành. Không cho xóa Khoa khi còn Chuyên ngành
            modelBuilder.Entity<ChuyenNganh>()
                .HasOne(cn => cn.Khoa)
                .WithMany(k => k.ChuyenNganhs)
                .HasForeignKey(cn => cn.KhoaId)
                .OnDelete(DeleteBehavior.Restrict);

            // 1 Chuyên ngành - nhiều Sinh viên. Không cho xóa Chuyên ngành khi còn sinh viên đăng ký
            modelBuilder.Entity<SinhVien>()
                .HasOne(sv => sv.ChuyenNganh)
                .WithMany()
                .HasForeignKey(sv => sv.ChuyenNganhId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mã SV không được trùng
            modelBuilder.Entity<SinhVien>()
                .HasIndex(sv => sv.MaSV)
                .IsUnique();
        }
    }
}
