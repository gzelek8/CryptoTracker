using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoTracker.DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cryptocurrencies_CryptocurrencyId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CryptocurrencyId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "CryptocurrencyId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CryptocurrencyId",
                table: "Transactions",
                column: "CryptocurrencyId",
                unique: true,
                filter: "[CryptocurrencyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cryptocurrencies_CryptocurrencyId",
                table: "Transactions",
                column: "CryptocurrencyId",
                principalTable: "Cryptocurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cryptocurrencies_CryptocurrencyId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CryptocurrencyId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "CryptocurrencyId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CryptocurrencyId",
                table: "Transactions",
                column: "CryptocurrencyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cryptocurrencies_CryptocurrencyId",
                table: "Transactions",
                column: "CryptocurrencyId",
                principalTable: "Cryptocurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
