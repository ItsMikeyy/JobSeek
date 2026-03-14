using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedJobListingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "JobListings",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "IsRemote",
                table: "JobListings",
                newName: "IsPublic");

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "JobListings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "JobListings",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateID",
                table: "JobListings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "JobListings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkArrangement",
                table: "JobListings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_CountryID",
                table: "JobListings",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_StateID",
                table: "JobListings",
                column: "StateID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_Countries_CountryID",
                table: "JobListings",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_States_StateID",
                table: "JobListings",
                column: "StateID",
                principalTable: "States",
                principalColumn: "StateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_Countries_CountryID",
                table: "JobListings");

            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_States_StateID",
                table: "JobListings");

            migrationBuilder.DropIndex(
                name: "IX_JobListings_CountryID",
                table: "JobListings");

            migrationBuilder.DropIndex(
                name: "IX_JobListings_StateID",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "StateID",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "WorkArrangement",
                table: "JobListings");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "JobListings",
                newName: "IsRemote");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "JobListings",
                newName: "Location");
        }
    }
}
