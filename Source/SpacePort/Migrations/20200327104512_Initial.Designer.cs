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
    [Migration("20200327104512_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpacePort.ParkingSpaceDbModel", b =>
                {
                    b.Property<int>("ParkingSpaceDbModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SpaceshipDbModelId")
                        .HasColumnType("int");

                    b.HasKey("ParkingSpaceDbModelId");

                    b.HasIndex("SpaceshipDbModelId")
                        .IsUnique()
                        .HasFilter("[SpaceshipDbModelId] IS NOT NULL");

                    b.ToTable("ParkingSpaceInfo");
                });

            modelBuilder.Entity("SpacePort.PersonDbModel", b =>
                {
                    b.Property<int>("PersonDbModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Wallet")
                        .HasColumnType("float");

                    b.HasKey("PersonDbModelId");

                    b.ToTable("PersonInfo");
                });

            modelBuilder.Entity("SpacePort.SpaceshipDbModel", b =>
                {
                    b.Property<int>("SpaceshipDbModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("PersonDbModelId")
                        .HasColumnType("int");

                    b.HasKey("SpaceshipDbModelId");

                    b.HasIndex("PersonDbModelId")
                        .IsUnique()
                        .HasFilter("[PersonDbModelId] IS NOT NULL");

                    b.ToTable("SpaceshipInfo");
                });

            modelBuilder.Entity("SpacePort.ParkingSpaceDbModel", b =>
                {
                    b.HasOne("SpacePort.SpaceshipDbModel", "SpaceshipDbModel")
                        .WithOne("ParkingSpaceDbModel")
                        .HasForeignKey("SpacePort.ParkingSpaceDbModel", "SpaceshipDbModelId");
                });

            modelBuilder.Entity("SpacePort.SpaceshipDbModel", b =>
                {
                    b.HasOne("SpacePort.PersonDbModel", "PersonDbModel")
                        .WithOne("SpaceshipDbModel")
                        .HasForeignKey("SpacePort.SpaceshipDbModel", "PersonDbModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
