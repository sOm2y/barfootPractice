using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace barfootPractice.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false, defaultValue: 0.0),
                    Status = table.Column<string>(nullable: true),
                    ConfidentialNote = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "Address", "ConfidentialNote", "Price", "Status" },
                values: new object[] { 1, "11 auckland street, auckland, 1010", "buyer expectation is under 1m.", 1200000.0, "open" });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "Address", "ConfidentialNote", "Price", "Status" },
                values: new object[] { 2, "12 auckland street, auckland, 1010", "buyer expectation is under 1m.", 1200000.0, "open" });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "Address", "ConfidentialNote", "Price", "Status" },
                values: new object[] { 3, "13 auckland street, auckland, 1010", "buyer expectation is under 1m.", 1200000.0, "open" });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Email", "Name", "Password", "Phone", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "test1@barfoot.co.nz", "test1", "sales", "123456", "Sales", null, "sales" },
                    { 2, "test2@barfoot.co.nz", "test1", "salesAdmin", "123456", "SalesAdmin", null, "salesAdmin" },
                    { 3, "test3@barfoot.co.nz", "test1", "salesDepartmentAdmin", "123456", "SalesDepartmentAdmin", null, "salesDepartmentAdmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Address",
                table: "Listings",
                column: "Address",
                unique: true,
                filter: "[Address] IS NOT NULL");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
