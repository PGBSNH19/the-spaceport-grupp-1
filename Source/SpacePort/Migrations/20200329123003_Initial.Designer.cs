﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpacePort;

namespace SpacePort.Migrations
{
    [DbContext(typeof(SpaceParkContext))]
    [Migration("20200329123003_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpacePort.InvoiceModel", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SpaceshipID")
                        .HasColumnType("int");

                    b.HasKey("InvoiceID");

                    b.HasIndex("PersonID");

                    b.HasIndex("SpaceshipID");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("SpacePort.ParkingSpaceModel", b =>
                {
                    b.Property<int>("ParkingSpaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SpaceshipID")
                        .HasColumnType("int");

                    b.HasKey("ParkingSpaceID");

                    b.HasIndex("SpaceshipID")
                        .IsUnique()
                        .HasFilter("[SpaceshipID] IS NOT NULL");

                    b.ToTable("Parkingspace");
                });

            modelBuilder.Entity("SpacePort.PersonModel", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Wallet")
                        .HasColumnType("float");

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SpacePort.SpaceshipModel", b =>
                {
                    b.Property<int>("SpaceshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("PersonDID")
                        .HasColumnType("int");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("SpaceshipID");

                    b.HasIndex("PersonDID")
                        .IsUnique()
                        .HasFilter("[PersonDID] IS NOT NULL");

                    b.ToTable("Spaceship");
                });

            modelBuilder.Entity("SpacePort.InvoiceModel", b =>
                {
                    b.HasOne("SpacePort.PersonModel", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID");

                    b.HasOne("SpacePort.SpaceshipModel", "Spaceship")
                        .WithMany()
                        .HasForeignKey("SpaceshipID");
                });

            modelBuilder.Entity("SpacePort.ParkingSpaceModel", b =>
                {
                    b.HasOne("SpacePort.SpaceshipModel", "Spaceship")
                        .WithOne("ParkingSpaceModel")
                        .HasForeignKey("SpacePort.ParkingSpaceModel", "SpaceshipID");
                });

            modelBuilder.Entity("SpacePort.SpaceshipModel", b =>
                {
                    b.HasOne("SpacePort.PersonModel", "Person")
                        .WithOne("Spaceship")
                        .HasForeignKey("SpacePort.SpaceshipModel", "PersonDID");
                });
#pragma warning restore 612, 618
        }
    }
}