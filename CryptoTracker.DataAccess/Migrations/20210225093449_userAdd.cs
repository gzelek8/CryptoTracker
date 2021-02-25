using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoTracker.DataAccess.Migrations
{
    public partial class userAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptocurrencies_Wallets_WalletId",
                table: "Cryptocurrencies");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Wallets",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "WalletId",
                table: "Cryptocurrencies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Cryptocurrencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nick = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptocurrencies_Wallets_WalletId",
                table: "Cryptocurrencies",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Users_UserId",
                table: "Wallets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptocurrencies_Wallets_WalletId",
                table: "Cryptocurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Users_UserId",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Cryptocurrencies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Wallets",
                newName: "Number");

            migrationBuilder.AlterColumn<int>(
                name: "WalletId",
                table: "Cryptocurrencies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptocurrencies_Wallets_WalletId",
                table: "Cryptocurrencies",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
