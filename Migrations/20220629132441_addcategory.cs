using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Migrations
{
    public partial class addcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Medicines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_CategoryId",
                table: "Medicines",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Categories_CategoryId",
                table: "Medicines",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Categories_CategoryId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_CategoryId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Medicines");
        }
    }
}
