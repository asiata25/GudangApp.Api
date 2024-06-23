using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GudangApp.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameGudangIdToKode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "gudang",
                newName: "kode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kode",
                table: "gudang",
                newName: "id");
        }
    }
}
