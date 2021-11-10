using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LC.DAL.EF
{
    public partial class BSContext : DbContext
    {
        public BSContext()
            : base("name=BSContext")
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Deposit> Deposit { get; set; }
        public virtual DbSet<Guarantor> Guarantor { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Person)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Person)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guarantor>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Guarantor>()
                .HasMany(e => e.Loan)
                .WithRequired(e => e.Guarantor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guarantor>()
                .HasMany(e => e.Person)
                .WithRequired(e => e.Guarantor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.IDNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Deposit)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Loan)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);
        }
    }
}
