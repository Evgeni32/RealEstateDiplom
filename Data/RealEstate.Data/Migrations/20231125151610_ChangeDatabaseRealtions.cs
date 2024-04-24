using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class ChangeDatabaseRealtions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Districts_DistrictId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_DistrictId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "DistrictId",
                table: "PropertyTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_DistrictId",
                table: "PropertyTypes",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTypes_Districts_DistrictId",
                table: "PropertyTypes",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypes_Districts_DistrictId",
                table: "PropertyTypes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTypes_DistrictId",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "PropertyTypes");

            migrationBuilder.AddColumn<string>(
                name: "DistrictId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_DistrictId",
                table: "Properties",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Districts_DistrictId",
                table: "Properties",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");
        }
    }
}
