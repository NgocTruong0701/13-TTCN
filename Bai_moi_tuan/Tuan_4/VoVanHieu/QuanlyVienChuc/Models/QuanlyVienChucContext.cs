using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace de5.Models
{
    public partial class De5Context : DbContext
    {
        public De5Context()
        {
        }

        public De5Context(DbContextOptions<De5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<VienChuc> VienChucs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HOANGCZ;Initial Catalog=De5;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DonVi>(entity =>
            {
                entity.HasKey(e => e.Madv)
                    .HasName("PK__DonVi__272379DF53D24662");

                entity.ToTable("DonVi");

                entity.Property(e => e.Madv)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tendonvi).HasMaxLength(50);
            });

            modelBuilder.Entity<VienChuc>(entity =>
            {
                entity.HasKey(e => e.Mavc)
                    .HasName("PK__VienChuc__27241471D1250CDF");

                entity.ToTable("VienChuc");

                entity.Property(e => e.Mavc)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Hoten).HasMaxLength(50);

                entity.Property(e => e.Madv)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MadvNavigation)
                    .WithMany(p => p.VienChucs)
                    .HasForeignKey(d => d.Madv)
                    .HasConstraintName("FK_VienChuc_DonVi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
