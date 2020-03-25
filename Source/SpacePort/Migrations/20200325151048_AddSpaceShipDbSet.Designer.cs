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
    [Migration("20200325151048_AddSpaceShipDbSet")]
    partial class AddSpaceShipDbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpacePort.PersonModel", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Wallet")
                        .HasColumnType("float");

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SpacePort.SpaceShipModel", b =>
                {
                    b.Property<int>("SpaceShipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerPersonID")
                        .HasColumnType("int");

                    b.HasKey("SpaceShipID");

                    b.HasIndex("OwnerPersonID");

                    b.ToTable("SpaceShip");
                });

            modelBuilder.Entity("SpacePort.SpaceShipModel", b =>
                {
                    b.HasOne("SpacePort.PersonModel", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerPersonID");
                });
#pragma warning restore 612, 618
        }
    }
}
