using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationContact.Models
{
    public partial class bdContactContext : DbContext
    {
        public bdContactContext()
        {
        }

        public bdContactContext(DbContextOptions<bdContactContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=PC8F636\\SQLEXPRESS;Database=bdContact; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.cellphone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cellphone");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
