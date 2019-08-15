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
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Barfoot"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //EF core code first data annotation
            modelBuilder.Entity<Listing>()
                .Property(l => l.ListingId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Listing>()
               .Property(l => l.Created)
               .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Listing>()
               .Property(l => l.Price)
               .HasDefaultValue(0.00);

            modelBuilder.Entity<Listing>()
               .HasIndex(l => l.Address)
               .IsUnique();

            modelBuilder.Entity<Staff>()
                .Property(s => s.StaffId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Staff>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Staff>()
                .HasIndex(s => s.Username)
                .IsUnique();

            modelBuilder.Entity<Staff>().HasData(
                new Staff() { StaffId = 1, Email = "test1@barfoot.co.nz", Name = "test1", Phone = "123456", Username = "sales", Password = "sales", Role = StaffRole.Sales },
                new Staff() { StaffId = 2, Email = "test2@barfoot.co.nz", Name = "test1", Phone = "123456", Username = "salesAdmin", Password = "salesAdmin", Role = StaffRole.SalesAdmin },
                new Staff() { StaffId = 3, Email = "test3@barfoot.co.nz", Name = "test1", Phone = "123456", Username = "salesDepartmentAdmin", Password = "salesDepartmentAdmin", Role = StaffRole.SalesDepartmentAdmin });

            modelBuilder.Entity<Listing>().HasData(
                new Listing() { ListingId = 1,  Address = "11 auckland street, auckland, 1010", Price = 1200000, Status = "open", ConfidentialNote = "buyer expectation is under 1m." },
                new Listing() { ListingId = 2,  Address = "12 auckland street, auckland, 1010", Price = 1200000, Status = "open", ConfidentialNote = "buyer expectation is under 1m." },
                new Listing() { ListingId = 3,  Address = "13 auckland street, auckland, 1010", Price = 1200000, Status = "open", ConfidentialNote = "buyer expectation is under 1m."});   

        }
    }
}
