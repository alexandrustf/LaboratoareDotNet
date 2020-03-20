using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
        {

        }
        public DbSet<Person> Persons{ get; set; }
        public DbSet<Picture> Pictures{ get; set; }

        public DbSet<PicturePerson> PicturePersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-29KLT88\\SQLEXPRESS;database=myDb;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PicturePerson>()
                .HasKey(pp => new { pp.PersonId, pp.PictureId });
            modelBuilder.Entity<PicturePerson>()
                .HasOne(pp => pp.Person)
                .WithMany(p => p.PicturePersons)
                .HasForeignKey(p => p.PersonId);
            modelBuilder.Entity<PicturePerson>()
                .HasOne(pp => pp.Picture)
                .WithMany(p => p.PicturePersons)
                .HasForeignKey(p => p.PictureId);

        }
    }
}
