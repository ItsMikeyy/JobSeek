using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyIDtoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "UserAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_CompanyID",
                table: "UserAccounts",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Companies_CompanyID",
                table: "UserAccounts",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Companies_CompanyID",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_CompanyID",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "UserAccounts");
        }
    }
}
