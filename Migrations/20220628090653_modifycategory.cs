using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicManagement.Migrations
{
    public partial class modifycategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryID",
                table: "Categories");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "PaymentHeaders",
                type: "smallmoney",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                table: "paymentDetails",
                type: "smallmoney",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Medicines",
                type: "smallmoney",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                table: "Medicines",
                type: "smallmoney",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OldUnitPrice",
                table: "Medicines",
                type: "smallmoney",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OldSellPrice",
                table: "Medicines",
                type: "smallmoney",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryID",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryID",
                table: "Categories");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "PaymentHeaders",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "smallmoney",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                table: "paymentDetails",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "smallmoney",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Medicines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "smallmoney",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                table: "Medicines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "smallmoney",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OldUnitPrice",
                table: "Medicines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "smallmoney",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OldSellPrice",
                table: "Medicines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "smallmoney",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
