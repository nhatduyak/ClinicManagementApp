using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Migrations
{
    public partial class updateusermodify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserIDModify",
                table: "Medicines",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_UserIDModify",
                table: "Medicines",
                column: "UserIDModify");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Users_UserIDModify",
                table: "Medicines",
                column: "UserIDModify",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Users_UserIDModify",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_UserIDModify",
                table: "Medicines");

            migrationBuilder.AlterColumn<string>(
                name: "UserIDModify",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
