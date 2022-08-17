﻿// <auto-generated />
using System;
using IAZBackend.Models.ApsEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IAZBackend.Models.ApsEntities.Migrations
{
    [DbContext(typeof(IAZ_ApsContext))]
    partial class IAZ_ApsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.Dataset", b =>
                {
                    b.Property<int>("DatasetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DatasetId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DatasetId");

                    b.ToTable("Orders_Dataset", (string)null);
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("DatasetId")
                        .HasColumnType("int");

                    b.Property<double>("BatchTime")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsMilitary")
                        .HasColumnType("bit");

                    b.Property<double>("MidBatchQuantity")
                        .HasColumnType("float");

                    b.Property<int>("OpNo")
                        .HasColumnType("int");

                    b.Property<double>("OpTimePerItem")
                        .HasColumnType("float");

                    b.Property<string>("OperationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcessTimeType")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int?>("ResourceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WorkGroup")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "DatasetId");

                    b.HasIndex("DatasetId");

                    b.HasIndex("ResourceId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.OrderLink", b =>
                {
                    b.Property<int>("DatasetId")
                        .HasColumnType("int");

                    b.Property<int?>("FromOrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ToOrderId")
                        .HasColumnType("int");

                    b.HasKey("DatasetId", "FromOrderId", "ToOrderId");

                    b.HasIndex("FromOrderId", "DatasetId");

                    b.HasIndex("ToOrderId", "DatasetId");

                    b.ToTable("OrderLinks", (string)null);
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.OrderSecConstraint", b =>
                {
                    b.Property<int>("DatasetId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("SecConstraintId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("ConstraintQuantity")
                        .HasColumnType("float");

                    b.Property<int>("ConstraintUsage")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DatasetId", "OrderId", "SecConstraintId", "StartTime");

                    b.HasIndex("SecConstraintId");

                    b.HasIndex("OrderId", "DatasetId");

                    b.ToTable("OrderSecConstraints", (string)null);
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceId"), 1L, 1);

                    b.Property<int>("FiniteOrInfinite")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceId");

                    b.ToTable("Resources", (string)null);
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.SecConstraint", b =>
                {
                    b.Property<int>("SecConstraintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SecConstraintId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SecConstraintId");

                    b.ToTable("SecConstraints", (string)null);
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.Workgroup", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<bool>("IsServiceGroup")
                        .HasColumnType("bit");

                    b.HasKey("Number");

                    b.ToTable("Workgroups", (string)null);
                });

            modelBuilder.Entity("SecConstraintWorkgroup", b =>
                {
                    b.Property<int>("WorkersSecConstraintId")
                        .HasColumnType("int");

                    b.Property<int>("WorkgroupsNumber")
                        .HasColumnType("int");

                    b.HasKey("WorkersSecConstraintId", "WorkgroupsNumber");

                    b.HasIndex("WorkgroupsNumber");

                    b.ToTable("SecConstraintWorkgroup", (string)null);
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.Order", b =>
                {
                    b.HasOne("IAZBackend.Models.ApsEntities.Dataset", "Dataset")
                        .WithMany()
                        .HasForeignKey("DatasetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IAZBackend.Models.ApsEntities.Resource", "Resource")
                        .WithMany("Orders")
                        .HasForeignKey("ResourceId");

                    b.Navigation("Dataset");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.OrderLink", b =>
                {
                    b.HasOne("IAZBackend.Models.ApsEntities.Dataset", "Dataset")
                        .WithMany()
                        .HasForeignKey("DatasetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IAZBackend.Models.ApsEntities.Order", "FromOrder")
                        .WithMany("LinksFrom")
                        .HasForeignKey("FromOrderId", "DatasetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IAZBackend.Models.ApsEntities.Order", "ToOrder")
                        .WithMany("LinksTo")
                        .HasForeignKey("ToOrderId", "DatasetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dataset");

                    b.Navigation("FromOrder");

                    b.Navigation("ToOrder");
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.OrderSecConstraint", b =>
                {
                    b.HasOne("IAZBackend.Models.ApsEntities.Dataset", "Dataset")
                        .WithMany()
                        .HasForeignKey("DatasetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IAZBackend.Models.ApsEntities.SecConstraint", "SecConstraint")
                        .WithMany()
                        .HasForeignKey("SecConstraintId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IAZBackend.Models.ApsEntities.Order", "Order")
                        .WithMany("OrderSecConstraints")
                        .HasForeignKey("OrderId", "DatasetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dataset");

                    b.Navigation("Order");

                    b.Navigation("SecConstraint");
                });

            modelBuilder.Entity("SecConstraintWorkgroup", b =>
                {
                    b.HasOne("IAZBackend.Models.ApsEntities.SecConstraint", null)
                        .WithMany()
                        .HasForeignKey("WorkersSecConstraintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IAZBackend.Models.ApsEntities.Workgroup", null)
                        .WithMany()
                        .HasForeignKey("WorkgroupsNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.Order", b =>
                {
                    b.Navigation("LinksFrom");

                    b.Navigation("LinksTo");

                    b.Navigation("OrderSecConstraints");
                });

            modelBuilder.Entity("IAZBackend.Models.ApsEntities.Resource", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
