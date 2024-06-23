using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GudangApp.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class DropColumnGudangKode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_barang_gudang_GudangKode",
                table: "barang");

            migrationBuilder.DropIndex(
                name: "IX_barang_GudangKode",
                table: "barang");

            migrationBuilder.DropColumn(
                name: "GudangKode",
                table: "barang");

            migrationBuilder.CreateIndex(
                name: "IX_barang_kode_gudang",
                table: "barang",
                column: "kode_gudang");

            migrationBuilder.AddForeignKey(
                name: "FK_barang_gudang_kode_gudang",
                table: "barang",
                column: "kode_gudang",
                principalTable: "gudang",
                principalColumn: "kode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_barang_gudang_kode_gudang",
                table: "barang");

            migrationBuilder.DropIndex(
                name: "IX_barang_kode_gudang",
                table: "barang");

            migrationBuilder.AddColumn<string>(
                name: "GudangKode",
                table: "barang",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_barang_GudangKode",
                table: "barang",
                column: "GudangKode");

            migrationBuilder.AddForeignKey(
                name: "FK_barang_gudang_GudangKode",
                table: "barang",
                column: "GudangKode",
                principalTable: "gudang",
                principalColumn: "kode");
        }
    }
}
