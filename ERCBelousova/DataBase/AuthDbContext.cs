using ERCBelousova.Data;
using ERCBelousova.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ERCBelousova.DataBase
{
    public class AuthDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> People { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("People");
                entity.HasKey(p => p.PersonId);
                entity.HasData(new Person
                {
                    PersonId = 1,
                    FullName = "Уточка",
                    AccountId = 1
                });
            });
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Number).HasMaxLength(15);
                entity.Property(x => x.StartDate).IsRequired();
                entity.Property(x => x.EndDate).IsRequired();
                entity.Property(x => x.Address).HasMaxLength(250);
                entity.Property(x => x.Area);
                //entity.Property(x => x.Residents);
                   
                entity.HasData(new Account
                {
                    Id = 1,
                    Number = "1234567",
                    StartDate = "12-12-2023",
                    EndDate = "12-12-2026",
                    Address = "Улица Уточкина 1",
                    Area = 123,
                    Residents = "Уточка b"
                });
            });
        }
    }
}