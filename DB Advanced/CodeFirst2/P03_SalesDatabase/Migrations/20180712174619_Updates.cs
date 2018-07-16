using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_SalesDatabase.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Products",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                unicode: false,
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 80,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                unicode: false,
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 80);
        }
    }
}
