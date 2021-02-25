using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoTracker.DataAccess.Migrations
{
    public partial class wallet_crypto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptocurrencies_Wallets_WalletId",
                table: "Cryptocurrencies");

            migrationBuilder.DropIndex(
                name: "IX_Cryptocurrencies_WalletId",
                table: "Cryptocurrencies");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Cryptocurrencies");

            migrationBuilder.CreateTable(
                name: "CryptocurrencyWallet",
                columns: table => new
                {
                    CryptocurrenciesId = table.Column<int>(type: "int", nullable: false),
                    WalletsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptocurrencyWallet", x => new { x.CryptocurrenciesId, x.WalletsId });
                    table.ForeignKey(
                        name: "FK_CryptocurrencyWallet_Cryptocurrencies_CryptocurrenciesId",
                        column: x => x.CryptocurrenciesId,
                        principalTable: "Cryptocurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CryptocurrencyWallet_Wallets_WalletsId",
                        column: x => x.WalletsId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptocurrencyWallet_WalletsId",
                table: "CryptocurrencyWallet",
                column: "WalletsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptocurrencyWallet");

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "Cryptocurrencies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cryptocurrencies_WalletId",
                table: "Cryptocurrencies",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptocurrencies_Wallets_WalletId",
                table: "Cryptocurrencies",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
