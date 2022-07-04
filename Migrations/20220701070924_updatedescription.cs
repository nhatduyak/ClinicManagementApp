using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Migrations
{
    public partial class updatedescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_BoolGroups_BloodGroupID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BoolGroups_BloodGroupID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "BoolGroups");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Genders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BloodGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroups", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_BloodGroups_BloodGroupID",
                table: "Doctors",
                column: "BloodGroupID",
                principalTable: "BloodGroups",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BloodGroups_BloodGroupID",
                table: "Patients",
                column: "BloodGroupID",
                principalTable: "BloodGroups",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_BloodGroups_BloodGroupID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BloodGroups_BloodGroupID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "BloodGroups");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Genders");

            migrationBuilder.CreateTable(
                name: "BoolGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoolGroups", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_BoolGroups_BloodGroupID",
                table: "Doctors",
                column: "BloodGroupID",
                principalTable: "BoolGroups",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BoolGroups_BloodGroupID",
                table: "Patients",
                column: "BloodGroupID",
                principalTable: "BoolGroups",
                principalColumn: "ID");
        }
    }
}
