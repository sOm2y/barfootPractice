using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace barfootPractice.Models
{
    public class BarfootContext: DbContext
    {
        public BarfootContext(DbContextOptions<BarfootContext> options)
           : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("barfoot"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasData(
                new Staff() { StaffId = 1, Email = "test1@barfoot.co.nz", Name = "test1", Phone = "123456" },
                new Staff() { StaffId = 2, Email = "test1@barfoot.co.nz", Name = "test1", Phone = "123456" },
                new Staff() { StaffId = 3, Email = "test1@barfoot.co.nz", Name = "test1", Phone = "123456" });

            modelBuilder.Entity<Listing>().HasData(
                new Listing() { ListingId = 1,  Address = "10 auckland street, auckland, 1010", Price = 1200000, Status = "open", ConfidentialNote = "buyer expectation is under 1m.", StaffId = 1 },
                new Listing() { ListingId = 2,  Address = "10 auckland street, auckland, 1010", Price = 1200000, Status = "open", ConfidentialNote = "buyer expectation is under 1m.", StaffId = 2 },
                new Listing() { ListingId = 3,  Address = "10 auckland street, auckland, 1010", Price = 1200000, Status = "open", ConfidentialNote = "buyer expectation is under 1m.", StaffId = 3});

     

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, FirstName = "Sales",                StaffId=1,   LastName = "User", Username = "sales",                  Password = "sales", Role = StaffRole.Sales }, 
                new User() { Id = 2, FirstName = "SalesAdmin",           StaffId=2,   LastName = "User", Username = "salesAdmin",             Password = "salesAdmin",  Role = StaffRole.SalesAdmin },
                new User() { Id = 3, FirstName = "SalesDepartmentAdmin", StaffId=3,   LastName = "User", Username = "salesDepartmentAdmin",   Password = "salesDepartmentAdmin",  Role = StaffRole.SalesDepartmentAdmin });

   

        }
    }
}
