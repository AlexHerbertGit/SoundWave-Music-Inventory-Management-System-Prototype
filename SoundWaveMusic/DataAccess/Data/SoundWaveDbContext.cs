using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.Entities;

namespace SoundWaveMusic.DataAccess.Data
{
    public class SoundWaveDbContext : DbContext
    {
        public SoundWaveDbContext(DbContextOptions<SoundWaveDbContext> options)
            : base(options) { }

        //DbSets for each entity in business domain
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CD> CDs { get; set; }
        public DbSet<Vinyl> Vinyls { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            

            //Album Relationships
            modelBuilder.Entity<Album>()
                .HasKey(a => a.AlbumId);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(al => al.Albums)
                .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Genre)
                .WithMany(g => g.Albums)
                .HasForeignKey(a => a.GenreId);

            //Artist Relationships
            modelBuilder.Entity<Artist>()
                .HasKey(a => a.ArtistId);

            //Product Relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Album)
                .WithMany(a => a.Products)
                .HasForeignKey(p => p.AlbumId);

            //OrderItem Relationship Configuration
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);


            // TPT Configuration
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<CD>().ToTable("CD");
            modelBuilder.Entity<Vinyl>().ToTable("Vinyl");

            // Table names
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
            
        }
    }
}
