using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShare.API.Migrations
{
    /// <inheritdoc />
    public partial class InitEight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cars_CarID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Persons_PersonID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Owners_OwnerID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonID",
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

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonID",
                table: "Owners",
                column: "PersonID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_CarID",
                table: "Bookings",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Persons_PersonID",
                table: "Bookings",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Owners_OwnerID",
                table: "Cars",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Bookings_Cars_CarID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Persons_PersonID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Owners_OwnerID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonID",
                table: "Owners");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Owners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonID",
                table: "Owners",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_CarID",
                table: "Bookings",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Persons_PersonID",
                table: "Bookings",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Owners_OwnerID",
                table: "Cars",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Persons_PersonID",
                table: "Owners",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID");
        }
    }
}
