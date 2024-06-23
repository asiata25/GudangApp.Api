using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GudangApp.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class BarangTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "barang",
                columns: table => new
                {
                    kode = table.Column<string>(type: "TEXT", nullable: false),
                    nama = table.Column<string>(type: "TEXT", nullable: false),
                    harga = table.Column<int>(type: "INTEGER", nullable: false),
                    jumlah = table.Column<int>(type: "INTEGER", nullable: false),
                    expired = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    kode_gudang = table.Column<string>(type: "TEXT", nullable: false),
                    GudangKode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barang", x => x.kode);
                    table.ForeignKey(
                        name: "FK_barang_gudang_GudangKode",
                        column: x => x.GudangKode,
                        principalTable: "gudang",
                        principalColumn: "kode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_barang_GudangKode",
                table: "barang",
                column: "GudangKode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "barang");
        }
    }
}
