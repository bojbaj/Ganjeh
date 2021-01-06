using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganjeh.Infrastructure.Migrations
{
    public partial class state_city_tables_created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegionState",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegionState_RegionCountries_RegionCountryId",
                        column: x => x.RegionCountryId,
                        principalTable: "RegionCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionCity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegionCity_RegionState_RegionStateId",
                        column: x => x.RegionStateId,
                        principalTable: "RegionState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionCity_RegionStateId",
                table: "RegionCity",
                column: "RegionStateId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionState_RegionCountryId",
                table: "RegionState",
                column: "RegionCountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionCity");

            migrationBuilder.DropTable(
                name: "RegionState");
        }
    }
}
