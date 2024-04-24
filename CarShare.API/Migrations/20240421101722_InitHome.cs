using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShare.API.Migrations
{
    /// <inheritdoc />
    public partial class InitHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Owners_OwnerId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Owners",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Cars",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                newName: "IX_Cars_OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Owners_OwnerID",
                table: "Cars",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Owners_OwnerID",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Owners",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Cars",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_OwnerID",
                table: "Cars",
                newName: "IX_Cars_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Owners_OwnerId",
                table: "Cars",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");
        }
    }
}
