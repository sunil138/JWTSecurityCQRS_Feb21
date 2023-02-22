using System;
using System.Collections.Generic;
using JWTSecurityCQRS_Feb21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JWTSecurityCQRS_Feb21.DataAccess
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Temployee> Temployees { get; set; } = null!;
        public virtual DbSet<Tuser> Tusers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Data Source=IN3238393W2\\SQLEXPRESS;Initial Catalog=EmployeeDB;Trusted_Connection=True;");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Temployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("TEmployee");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tuser>(entity =>
            {
                entity.ToTable("TUsers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
