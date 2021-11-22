using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FromDB
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Hobby> Hobbies { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonHobby> PersonHobbies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost; DataBase=db;Integrated Security=false; User Id=root;password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.PersonId, "IX_Addresses_PersonId")
                    .IsUnique();

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.CurrentDepartmentId, "IX_Persons_CurrentDepartmentId");

                entity.HasOne(d => d.CurrentDepartment)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CurrentDepartmentId);
            });

            modelBuilder.Entity<PersonHobby>(entity =>
            {
                entity.HasKey(e => new { e.HobbiesId, e.PersonsId });

                entity.HasIndex(e => e.PersonsId, "IX_PersonHobbies_PersonsId");

                entity.HasOne(d => d.Hobbies)
                    .WithMany(p => p.PersonHobbies)
                    .HasForeignKey(d => d.HobbiesId);

                entity.HasOne(d => d.Persons)
                    .WithMany(p => p.PersonHobbies)
                    .HasForeignKey(d => d.PersonsId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
