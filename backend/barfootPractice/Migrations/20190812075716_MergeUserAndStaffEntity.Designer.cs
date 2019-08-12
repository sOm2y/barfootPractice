﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using barfootPractice.Models;

namespace barfootPractice.Migrations
{
    [DbContext(typeof(BarfootContext))]
    [Migration("20190812075716_MergeUserAndStaffEntity")]
    partial class MergeUserAndStaffEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("barfootPractice.Models.Listing", b =>
                {
                    b.Property<int>("ListingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ConfidentialNote");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<double>("Price")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0.0);

                    b.Property<string>("Status");

                    b.HasKey("ListingId");

                    b.HasIndex("Address")
                        .IsUnique()
                        .HasFilter("[Address] IS NOT NULL");

                    b.ToTable("Listings");

                    b.HasData(
                        new
                        {
                            ListingId = 1,
                            Address = "10 auckland street, auckland, 1010",
                            ConfidentialNote = "buyer expectation is under 1m.",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 1200000.0,
                            Status = "open"
                        },
                        new
                        {
                            ListingId = 2,
                            Address = "10 auckland street, auckland, 1010",
                            ConfidentialNote = "buyer expectation is under 1m.",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 1200000.0,
                            Status = "open"
                        },
                        new
                        {
                            ListingId = 3,
                            Address = "10 auckland street, auckland, 1010",
                            ConfidentialNote = "buyer expectation is under 1m.",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 1200000.0,
                            Status = "open"
                        });
                });

            modelBuilder.Entity("barfootPractice.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Role");

                    b.Property<string>("Token");

                    b.Property<string>("Username");

                    b.HasKey("StaffId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Staffs");

                    b.HasData(
                        new
                        {
                            StaffId = 1,
                            Email = "test1@barfoot.co.nz",
                            Name = "test1",
                            Password = "sales",
                            Phone = "123456",
                            Role = "Sales",
                            Username = "sales"
                        },
                        new
                        {
                            StaffId = 2,
                            Email = "test2@barfoot.co.nz",
                            Name = "test1",
                            Password = "salesAdmin",
                            Phone = "123456",
                            Role = "SalesAdmin",
                            Username = "salesAdmin"
                        },
                        new
                        {
                            StaffId = 3,
                            Email = "test3@barfoot.co.nz",
                            Name = "test1",
                            Password = "salesDepartmentAdmin",
                            Phone = "123456",
                            Role = "SalesDepartmentAdmin",
                            Username = "salesDepartmentAdmin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
