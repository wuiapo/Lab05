using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLySinhVien.DAL.Migrations
{
    /// <summary>
    /// Bài tập 2: thêm bảng ChuyenNganhs; SinhViens bỏ cột KhoaId, thêm cột ChuyenNganhId.
    /// (Lưu ý: liên kết Sinh viên - Khoa cũ bị xóa, sinh viên cần đăng ký lại chuyên ngành.)
    /// </summary>
    public partial class ThemChuyenNganh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_Khoas_KhoaId",
                table: "SinhViens");

            migrationBuilder.DropIndex(
                name: "IX_SinhViens_KhoaId",
                table: "SinhViens");

            migrationBuilder.DropColumn(
                name: "KhoaId",
                table: "SinhViens");

            migrationBuilder.AddColumn<int>(
                name: "ChuyenNganhId",
                table: "SinhViens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChuyenNganhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuyenNganh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenNganhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuyenNganhs_Khoas_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_ChuyenNganhId",
                table: "SinhViens",
                column: "ChuyenNganhId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenNganhs_KhoaId",
                table: "ChuyenNganhs",
                column: "KhoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_ChuyenNganhs_ChuyenNganhId",
                table: "SinhViens",
                column: "ChuyenNganhId",
                principalTable: "ChuyenNganhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_ChuyenNganhs_ChuyenNganhId",
                table: "SinhViens");

            migrationBuilder.DropTable(
                name: "ChuyenNganhs");

            migrationBuilder.DropIndex(
                name: "IX_SinhViens_ChuyenNganhId",
                table: "SinhViens");

            migrationBuilder.DropColumn(
                name: "ChuyenNganhId",
                table: "SinhViens");

            migrationBuilder.AddColumn<int>(
                name: "KhoaId",
                table: "SinhViens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_KhoaId",
                table: "SinhViens",
                column: "KhoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_Khoas_KhoaId",
                table: "SinhViens",
                column: "KhoaId",
                principalTable: "Khoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
