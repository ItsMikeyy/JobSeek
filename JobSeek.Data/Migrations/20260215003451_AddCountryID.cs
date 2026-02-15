using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityID",
                table: "UserAccounts");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_CountryID",
                table: "UserAccounts",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_StateID",
                table: "UserAccounts",
                column: "StateID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Countries_CountryID",
                table: "UserAccounts",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_States_StateID",
                table: "UserAccounts",
                column: "StateID",
                principalTable: "States",
                principalColumn: "StateID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Countries_CountryID",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_States_StateID",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_CountryID",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_StateID",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserAccounts");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
