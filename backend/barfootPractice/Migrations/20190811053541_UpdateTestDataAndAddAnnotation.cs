using Microsoft.EntityFrameworkCore.Migrations;

namespace barfootPractice.Migrations
{
    public partial class UpdateTestDataAndAddAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Staffs_StaffId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_StaffId",
                table: "Listings");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Staffs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Staffs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staffs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Listings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Listings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Listings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 1,
                column: "StaffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 2,
                column: "StaffId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 3,
                column: "StaffId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Staffs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Staffs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staffs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 1,
                column: "StaffId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 2,
                column: "StaffId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 3,
                column: "StaffId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_StaffId",
                table: "Listings",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Staffs_StaffId",
                table: "Listings",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
