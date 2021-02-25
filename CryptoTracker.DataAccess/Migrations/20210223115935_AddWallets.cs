using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoTracker.DataAccess.Migrations
{
    public partial class AddWallets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "Cryptocurrencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptocurrencies_Wallets_WalletId",
                table: "Cryptocurrencies");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Cryptocurrencies_WalletId",
                table: "Cryptocurrencies");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Cryptocurrencies");
        }
    }
}
