﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace test4.Models
{
    public partial class De2Context : DbContext
    {
        public De2Context()
        {
        }

        public De2Context(DbContextOptions<De2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BenhNhan> BenhNhans { get; set; }
        public virtual DbSet<KhoaKham> KhoaKhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-K7MPJGP\\SQLEXPRESS01;Initial Catalog=De2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.HasKey(e => e.Mabn)
                    .HasName("PK__BenhNhan__272369950B484FEE");

                entity.ToTable("BenhNhan");

                entity.Property(e => e.Mabn)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Hoten).HasMaxLength(50);

                entity.Property(e => e.Makhoa)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SongayNv).HasColumnName("SongayNV");

                entity.HasOne(d => d.MakhoaNavigation)
                    .WithMany(p => p.BenhNhans)
                    .HasForeignKey(d => d.Makhoa)
                    .HasConstraintName("FK_BenhNhan_KhoaKham");
            });

            modelBuilder.Entity<KhoaKham>(entity =>
            {
                entity.HasKey(e => e.Makhoa)
                    .HasName("PK__KhoaKham__5E7F1383A59B577B");

                entity.ToTable("KhoaKham");

                entity.Property(e => e.Makhoa)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tenkhoa).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
