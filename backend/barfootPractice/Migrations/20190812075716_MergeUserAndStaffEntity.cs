using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace barfootPractice.Migrations
{
    public partial class MergeUserAndStaffEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Listings");

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

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Listings",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Listings",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 1,
                column: "Price",
                value: 1200000.0);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 2,
                column: "Price",
                value: 1200000.0);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 3,
                column: "Price",
                value: 1200000.0);

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "sales", "Sales", "sales" });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                columns: new[] { "Email", "Password", "Role", "Username" },
                values: new object[] { "test2@barfoot.co.nz", "salesAdmin", "SalesAdmin", "salesAdmin" });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                columns: new[] { "Email", "Password", "Role", "Username" },
                values: new object[] { "test3@barfoot.co.nz", "salesDepartmentAdmin", "SalesDepartmentAdmin", "salesDepartmentAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Email",
                table: "Staffs",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Username",
                table: "Staffs",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Address",
                table: "Listings",
                column: "Address",
                unique: true,
                filter: "[Address] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Staffs_Email",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_Username",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Listings_Address",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Listings");

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

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Listings",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Listings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Listings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 1,
                columns: new[] { "Price", "StaffId" },
                values: new object[] { 1200000f, 1 });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 2,
                columns: new[] { "Price", "StaffId" },
                values: new object[] { 1200000f, 2 });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 3,
                columns: new[] { "Price", "StaffId" },
                values: new object[] { 1200000f, 3 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "Email",
                value: "test1@barfoot.co.nz");

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "Email",
                value: "test1@barfoot.co.nz");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "StaffId", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "Sales", "User", "sales", "Sales", 1, null, "sales" },
                    { 2, "SalesAdmin", "User", "salesAdmin", "SalesAdmin", 2, null, "salesAdmin" },
                    { 3, "SalesDepartmentAdmin", "User", "salesDepartmentAdmin", "SalesDepartmentAdmin", 3, null, "salesDepartmentAdmin" }
                });
        }
    }
}
