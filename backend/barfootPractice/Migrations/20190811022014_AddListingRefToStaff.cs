using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace barfootPractice.Migrations
{
    public partial class AddListingRefToStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Listings",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Staffs_StaffId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_StaffId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Listings");
        }
    }
}
