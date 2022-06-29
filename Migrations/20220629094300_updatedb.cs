using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufactureId",
                table: "Medicines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_ManufactureId",
                table: "Medicines",
                column: "ManufactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Manufactures_ManufactureId",
                table: "Medicines",
                column: "ManufactureId",
                principalTable: "Manufactures",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Manufactures_ManufactureId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_ManufactureId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ManufactureId",
                table: "Medicines");
        }
    }
}
