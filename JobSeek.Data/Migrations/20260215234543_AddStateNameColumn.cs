using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStateNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_States_StateID",
                table: "UserAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "StateID",
                table: "UserAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_States_StateID",
                table: "UserAccounts",
                column: "StateID",
                principalTable: "States",
                principalColumn: "StateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_States_StateID",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "UserAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "StateID",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_States_StateID",
                table: "UserAccounts",
                column: "StateID",
                principalTable: "States",
                principalColumn: "StateID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
