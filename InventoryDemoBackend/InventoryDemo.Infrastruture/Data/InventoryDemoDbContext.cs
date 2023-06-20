using InventoryDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Infrastructure.Data
{
    public class InventoryDemoDbContext: DbContext
    {
        public InventoryDemoDbContext(DbContextOptions<InventoryDemoDbContext> option) : base(option)
        {

        }
        //build relationship many - many with this link 
        //https://www.yogihosting.com/fluent-api-many-to-many-relationship-entity-framework-core/
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Machines>()
        //            .HasMany(m => m.Parts)
        //            .WithMany(m => m.Machines)
        //            .UsingEntity(j => j.ToTable("MachineandPart"));
        //}
        //public DbSet<Machines> Machines { get; set; }
        //public DbSet<Parts> JobCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Records>(entity =>
            {
                entity.HasKey(e => e.POnumber);
                entity.Property(e => e.OrderNumber)
                    .IsRequired();
                entity.Property(e => e.LOTnumber)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.ProductCode)
                    .IsRequired();
            });

            modelBuilder.Entity<Machines>(entity =>
            {
                entity.HasKey(e => e.MachineId);
                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasMaxLength(150);
            });
            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MaterialId);
                entity.Property(e => e.MaterialName)
                    .IsRequired()
                    .HasMaxLength(200);
            });
            modelBuilder.Entity<Operators>(entity =>
            {
                entity.HasKey(e => e.OperatorId);
                entity.Property(e => e.OperatorName)
                    .IsRequired()
                    .HasMaxLength(150);
            });
            modelBuilder.Entity<Records>()
                .HasMany(e => e.Operator)
                .WithMany(m => m.Record)
                .UsingEntity(j => j.ToTable("OperatorAndRecord"));
            modelBuilder.Entity<Records>()
                .HasMany(e => e.Machine)
                .WithMany(m => m.Record)
                .UsingEntity(j => j.ToTable("MachineAndRecord"));

        }
            
        public DbSet<Records> Records { get; set; }
        public DbSet<Operators> Operators { get; set; }
        public DbSet<Machines> Machines { get; set; }
        public DbSet<Material> Materials { get; set; }
    }
}
   
