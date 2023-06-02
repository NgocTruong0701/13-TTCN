using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace nguyenandung.Models
{
    public partial class WineStoreDB : DbContext
    {
        public WineStoreDB()
            : base("name=WineStoreDB")
        {
        }

        public virtual DbSet<Catalogy> Catalogies { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogy>()
                .Property(e => e.CatalogyID)
                .IsFixedLength();

            modelBuilder.Entity<Catalogy>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Catalogy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Vintage)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.CatalogyID)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
