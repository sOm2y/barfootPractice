﻿using Microsoft.EntityFrameworkCore;

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

    }
}