using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using PlatinumEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatinumEF
{
    class Context : DbContext
    {
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=db;username=root;password=12345")
                //.LogTo(Console.WriteLine)
                ;       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Department>().Property(p => p.Name).HasColumnName("Title");

            modelBuilder.Entity<Person>()
                .HasOne<Department>(p => p.Department)
                .WithMany(d => d.Persons)
                .HasForeignKey(p => p.CurrentDepartmentId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Hobbies)
                .WithMany(h => h.Persons)
                .UsingEntity(j => j.ToTable("PersonHobbies"));

            modelBuilder.Entity<Department>().HasData(new
            {
                Id = 1,
                Name = "Test"
            });

            modelBuilder.Entity<Person>().HasData(new
            {
                Id = 8,
                Name = "Oleg1",
                Surname = "Tarusov",
                CurrentDepartmentId = 1,
            });

            modelBuilder.Entity<Person>().HasData(new
            Person
            {
                Id = 9,
                Name = "Vasya2",
                Surname = "Petrov",
                CurrentDepartmentId = 1
            });


        }
        public DbSet<Person> Persons {get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }
    }
}
