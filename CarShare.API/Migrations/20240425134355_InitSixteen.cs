using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShare.API.Migrations
{
    /// <inheritdoc />
    public partial class InitSixteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonID",
                table: "Owners");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonID",
                table: "Owners",
                column: "PersonID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonID",
                table: "Owners");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonID",
                table: "Owners",
                column: "PersonID");
        }
    }
}
