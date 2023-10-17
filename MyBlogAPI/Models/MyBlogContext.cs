using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBlogAPI.Models
{
    public partial class MyBlogContext : DbContext
    {
        public MyBlogContext()
        {
        }

        public MyBlogContext(DbContextOptions<MyBlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SignUp> SignUps { get; set; } = null!;
        public virtual DbSet<UserCredential> UserCredentials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BlogDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignUp>(entity =>
            {
                entity.ToTable("SignUp");

                entity.HasIndex(e => e.Username, "UQ__SignUp__536C85E415B3DB52")
                    .IsUnique();

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserCred__1788CC4C1E6DFB83");

                entity.HasIndex(e => e.Username, "UQ__UserCred__536C85E45BF5A40A")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserType).HasColumnName("User_Type");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserCredential)
                    .HasForeignKey<UserCredential>(d => d.UserId)
                    .HasConstraintName("FK__UserCrede__UserI__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
