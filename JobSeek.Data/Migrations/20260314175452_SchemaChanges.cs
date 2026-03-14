using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class SchemaChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_Countries_CountryID",
                table: "JobListings");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "JobListings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_Countries_CountryID",
                table: "JobListings",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_Countries_CountryID",
                table: "JobListings");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "JobListings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_Countries_CountryID",
                table: "JobListings",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID");
        }
    }
}
