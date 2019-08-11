using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace barfootPractice.Migrations
{
    public partial class AddConfidentialNoteAndStatusOnListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfidentialNote",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Listings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfidentialNote",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Listings");
        }
    }
}
