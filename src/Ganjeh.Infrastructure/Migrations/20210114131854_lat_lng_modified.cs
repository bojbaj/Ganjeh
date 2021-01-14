using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganjeh.Infrastructure.Migrations
{
    public partial class lat_lng_modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Addresses",
                type: "decimal(10,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Addresses",
                type: "decimal(10,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Addresses",
                type: "decimal(8,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Addresses",
                type: "decimal(8,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,6)");
        }
    }
}
