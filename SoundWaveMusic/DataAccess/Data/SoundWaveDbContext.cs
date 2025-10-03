using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.Domain.Entities;
using SoundWaveMusic.DataAccess.Repositories;

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

            //Inheritance Configuration using TPH
            modelBuilder.Entity<Product>()
                .HasDiscriminator<string>("ProductType")
                .HasValue<CD>("CD")
                .HasValue<Vinyl>("Vinyl");

            //OrderItem Relationship Configuration
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);
        }
    }
}
