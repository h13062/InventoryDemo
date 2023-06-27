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
            modelBuilder.Entity<RecordOperator>()
            .HasKey(ro => new { ro.OperatorId, ro.POnumber });

            modelBuilder.Entity<RecordOperator>()
                .HasOne(ro => ro.Operator)
                .WithMany(o => o.RecordOperators)
                .HasForeignKey(ro => ro.OperatorId);

            modelBuilder.Entity<RecordOperator>()
                .HasOne(ro => ro.Record)
                .WithMany(r => r.RecordOperators)
                .HasForeignKey(ro => ro.POnumber);

            modelBuilder.Entity<RecordMachine>()
                .HasKey(rm => new { rm.MachineId, rm.POnumber });

            modelBuilder.Entity<RecordMachine>()
                .HasOne(rm => rm.Machine)
                .WithMany(m => m.RecordMachines)
                .HasForeignKey(rm => rm.MachineId);

            modelBuilder.Entity<RecordMachine>()
                .HasOne(rm => rm.Record)
                .WithMany(r => r.RecordMachines)
                .HasForeignKey(rm => rm.POnumber);

            modelBuilder.Entity<RecordMaterial>()
                .HasKey(rmat => new { rmat.MaterialId, rmat.POnumber });

            modelBuilder.Entity<RecordMaterial>()
                .HasOne(rmat => rmat.Material)
                .WithMany(m => m.RecordMaterials)
                .HasForeignKey(rmat => rmat.MaterialId);

            modelBuilder.Entity<RecordMaterial>()
                .HasOne(rmat => rmat.Record)
                .WithMany(r => r.RecordMaterials)
                .HasForeignKey(rmat => rmat.POnumber);

            modelBuilder.Entity<Record>()
                .HasKey(r => r.POnumber);


            // Other entity configurations

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Operator> Operators { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordMachine> RecordMachines { get; set; }
        public DbSet<RecordOperator> RecordOperators { get; set; }
        public DbSet<RecordMaterial> RecordMaterials { get; set; }
    }
}
   
