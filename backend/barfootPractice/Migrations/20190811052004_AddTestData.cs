using Microsoft.EntityFrameworkCore.Migrations;

namespace barfootPractice.Migrations
{
    public partial class AddTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "Address", "ConfidentialNote", "Price", "StaffId", "Status" },
                values: new object[,]
                {
                    { 1, "10 auckland street, auckland, 1010", "buyer expectation is under 1m.", 1200000f, null, "open" },
                    { 2, "10 auckland street, auckland, 1010", "buyer expectation is under 1m.", 1200000f, null, "open" },
                    { 3, "10 auckland street, auckland, 1010", "buyer expectation is under 1m.", 1200000f, null, "open" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "test1@barfoot.co.nz", "test1", "123456" },
                    { 2, "test1@barfoot.co.nz", "test1", "123456" },
                    { 3, "test1@barfoot.co.nz", "test1", "123456" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
