using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShare.API.Migrations
{
    /// <inheritdoc />
    public partial class InitSix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserID",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserID",
                table: "Persons",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserID",
                table: "Persons",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserID",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserID",
                table: "Persons",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserID",
                table: "Persons",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
