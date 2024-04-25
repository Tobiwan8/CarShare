using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShare.API.Migrations
{
    /// <inheritdoc />
    public partial class InitThirteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonID",
                table: "Owners");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonID",
                table: "Owners",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonID",
                table: "Owners");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonID",
                table: "Owners",
                column: "PersonID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
