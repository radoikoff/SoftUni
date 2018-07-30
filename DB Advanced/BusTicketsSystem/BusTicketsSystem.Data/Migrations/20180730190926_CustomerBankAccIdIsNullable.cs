using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicketsSystem.Data.Migrations
{
    public partial class CustomerBankAccIdIsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_BankAccounts_BankAccountId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BankAccountId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BankAccountId",
                table: "Customers",
                column: "BankAccountId",
                unique: true,
                filter: "[BankAccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_BankAccounts_BankAccountId",
                table: "Customers",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_BankAccounts_BankAccountId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BankAccountId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BankAccountId",
                table: "Customers",
                column: "BankAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_BankAccounts_BankAccountId",
                table: "Customers",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
