using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShare.API.Migrations
{
    /// <inheritdoc />
    public partial class InitFourteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Owners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
