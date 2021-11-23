using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP.Models
{
    public partial class perpustakaanContext : DbContext
    {
        public perpustakaanContext()
        {
        }

        public perpustakaanContext(DbContextOptions<perpustakaanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Loginuser1> Loginuser1s { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<User> Users { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("id_admin");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Username)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Loginuser1>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.ToTable("loginuser1");

                entity.Property(e => e.IdLogin)
                    .ValueGeneratedNever()
                    .HasColumnName("id_login");

                entity.Property(e => e.Username)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.ToTable("menu");

                entity.Property(e => e.IdMenu)
                    .ValueGeneratedNever()
                    .HasColumnName("id_menu");

                entity.Property(e => e.Columnn)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralInformation)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("general_information");

                entity.Property(e => e.Mathematic)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("mathematic");

                entity.Property(e => e.Reading)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("reading");

                entity.Property(e => e.Sains)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("sains");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_user");

                entity.Property(e => e.Username)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
