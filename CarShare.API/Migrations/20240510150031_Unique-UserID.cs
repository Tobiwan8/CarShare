using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShare.API.Migrations
{
    /// <inheritdoc />
    public partial class UniqueUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_UserID",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserID",
                table: "Persons",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_UserID",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserID",
                table: "Persons",
                column: "UserID");
        }
    }
}
