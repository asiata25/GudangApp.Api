using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GudangApp.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class GudangTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gudang",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    nama = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gudang", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gudang");
        }
    }
}
