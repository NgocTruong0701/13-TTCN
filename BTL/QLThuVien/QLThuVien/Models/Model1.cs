using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLThuVien.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CHUDESACH> CHUDESACHes { get; set; }
        public virtual DbSet<NGUOIMUON> NGUOIMUONs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<PHIEUMUON> PHIEUMUONs { get; set; }
        public virtual DbSet<PHIEUMUON_SACH> PHIEUMUON_SACH { get; set; }
        public virtual DbSet<PHIEUTRA> PHIEUTRAs { get; set; }
        public virtual DbSet<PHIEUTRA_SACH> PHIEUTRA_SACH { get; set; }
        public virtual DbSet<QUANTRIVIEN> QUANTRIVIENs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUDESACH>()
                .Property(e => e.maChuDe)
                .IsFixedLength();

            modelBuilder.Entity<CHUDESACH>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.CHUDESACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUOIMUON>()
                .Property(e => e.maNguoiMuon)
                .IsFixedLength();

            modelBuilder.Entity<NGUOIMUON>()
                .HasMany(e => e.PHIEUMUONs)
                .WithRequired(e => e.NGUOIMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUOIMUON>()
                .HasMany(e => e.PHIEUTRAs)
                .WithRequired(e => e.NGUOIMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.maNXB)
                .IsFixedLength();

            modelBuilder.Entity<NHAXUATBAN>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.NHAXUATBAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.maPhieuMuon)
                .IsFixedLength();

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.tienTheCho)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.maNguoiMuon)
                .IsFixedLength();

            modelBuilder.Entity<PHIEUMUON>()
                .HasMany(e => e.PHIEUMUON_SACH)
                .WithRequired(e => e.PHIEUMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUON_SACH>()
                .Property(e => e.maSach)
                .IsFixedLength();

            modelBuilder.Entity<PHIEUMUON_SACH>()
                .Property(e => e.maPhieuMuon)
                .IsFixedLength();

            modelBuilder.Entity<PHIEUTRA>()
                .Property(e => e.maPhieuTra)
                .IsFixedLength();

            modelBuilder.Entity<PHIEUTRA>()
                .Property(e => e.tienHoanTra)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUTRA>()
                .Property(e => e.maNguoiMuon)
                .IsFixedLength();

            modelBuilder.Entity<PHIEUTRA>()
                .HasMany(e => e.PHIEUTRA_SACH)
                .WithRequired(e => e.PHIEUTRA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUTRA_SACH>()
                .Property(e => e.maSach)
                .IsFixedLength();

            modelBuilder.Entity<PHIEUTRA_SACH>()
                .Property(e => e.maPhieuTra)
                .IsFixedLength();

            modelBuilder.Entity<QUANTRIVIEN>()
                .Property(e => e.maQTV)
                .IsFixedLength();

            modelBuilder.Entity<SACH>()
                .Property(e => e.maSach)
                .IsFixedLength();

            modelBuilder.Entity<SACH>()
                .Property(e => e.giaSach)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SACH>()
                .Property(e => e.maTacGia)
                .IsFixedLength();

            modelBuilder.Entity<SACH>()
                .Property(e => e.maChuDe)
                .IsFixedLength();

            modelBuilder.Entity<SACH>()
                .Property(e => e.maNXB)
                .IsFixedLength();

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.PHIEUMUON_SACH)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.PHIEUTRA_SACH)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.maTacGia)
                .IsFixedLength();

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.TACGIA)
                .WillCascadeOnDelete(false);
        }
    }
}
