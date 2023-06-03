using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TX_2.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Danhmuc>()
                .Property(e => e.Mota)
                .IsUnicode(false);

            modelBuilder.Entity<Danhmuc>()
                .HasMany(e => e.Sanphams)
                .WithRequired(e => e.Danhmuc)
                .WillCascadeOnDelete(false);
        }
    }
}
