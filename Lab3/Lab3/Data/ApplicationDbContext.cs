using System;
using System.Collections.Generic;
using System.Text;
using Lab3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Province>()
                .HasKey(p => p.ProvinceCode);
            builder.Entity<City>()
                .HasKey(c => c.CityId);
            builder.Entity<City>()
                .HasOne(c=>c.Province)
                .WithMany(c=>c.Cities)
                .HasForeignKey(c => c.ProvinceCode)
                .IsRequired();

                //why does this print duplicate provinceCode columns?
            //builder.Entity<Province>()
            //    .HasMany(c => c.Cities)
            //    .WithOne(c => c.Province)
            //    .IsRequired();
        }
    }
}
