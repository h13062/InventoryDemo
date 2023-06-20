﻿// <auto-generated />
using System;
using InventoryDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryDemo.Infrastructure.Migrations
{
    [DbContext(typeof(InventoryDemoDbContext))]
    partial class InventoryDemoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InventoryDemo.Core.Entities.Machines", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MachineId"), 1L, 1);

                    b.Property<string>("MachineName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("InventoryDemo.Core.Entities.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"), 1L, 1);

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("InventoryDemo.Core.Entities.Operators", b =>
                {
                    b.Property<int>("OperatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OperatorId"), 1L, 1);

                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("OperatorId");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("InventoryDemo.Core.Entities.Records", b =>
                {
                    b.Property<int>("POnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("POnumber"), 1L, 1);

                    b.Property<DateTime>("CompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LOTnumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int>("ProductCode")
                        .HasColumnType("int");

                    b.HasKey("POnumber");

                    b.HasIndex("MaterialId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("MachinesRecords", b =>
                {
                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("RecordPOnumber")
                        .HasColumnType("int");

                    b.HasKey("MachineId", "RecordPOnumber");

                    b.HasIndex("RecordPOnumber");

                    b.ToTable("MachineAndRecord", (string)null);
                });

            modelBuilder.Entity("OperatorsRecords", b =>
                {
                    b.Property<int>("OperatorId")
                        .HasColumnType("int");

                    b.Property<int>("RecordPOnumber")
                        .HasColumnType("int");

                    b.HasKey("OperatorId", "RecordPOnumber");

                    b.HasIndex("RecordPOnumber");

                    b.ToTable("OperatorAndRecord", (string)null);
                });

            modelBuilder.Entity("InventoryDemo.Core.Entities.Records", b =>
                {
                    b.HasOne("InventoryDemo.Core.Entities.Material", "Material")
                        .WithMany("Record")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("MachinesRecords", b =>
                {
                    b.HasOne("InventoryDemo.Core.Entities.Machines", null)
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryDemo.Core.Entities.Records", null)
                        .WithMany()
                        .HasForeignKey("RecordPOnumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OperatorsRecords", b =>
                {
                    b.HasOne("InventoryDemo.Core.Entities.Operators", null)
                        .WithMany()
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryDemo.Core.Entities.Records", null)
                        .WithMany()
                        .HasForeignKey("RecordPOnumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryDemo.Core.Entities.Material", b =>
                {
                    b.Navigation("Record");
                });
#pragma warning restore 612, 618
        }
    }
}
