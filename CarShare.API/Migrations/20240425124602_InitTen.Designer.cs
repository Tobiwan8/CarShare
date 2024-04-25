﻿// <auto-generated />
using System;
using CarShare.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarShare.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240425124602_InitTen")]
    partial class InitTen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarModelPersonModel", b =>
                {
                    b.Property<int>("CarPersonsID")
                        .HasColumnType("int");

                    b.Property<int>("PersonCarsID")
                        .HasColumnType("int");

                    b.HasKey("CarPersonsID", "PersonCarsID");

                    b.HasIndex("PersonCarsID");

                    b.ToTable("CarModelPersonModel");
                });

            modelBuilder.Entity("CarShare.Repository.Models.BookingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarID");

                    b.HasIndex("PersonID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CarShare.Repository.Models.CarModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LicensePlate")
                        .IsUnique()
                        .HasFilter("[LicensePlate] IS NOT NULL");

                    b.HasIndex("OwnerID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarShare.Repository.Models.OwnerModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonID")
                        .IsUnique();

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("CarShare.Repository.Models.PersonModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CarShare.Repository.Models.UserModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarModelPersonModel", b =>
                {
                    b.HasOne("CarShare.Repository.Models.PersonModel", null)
                        .WithMany()
                        .HasForeignKey("CarPersonsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarShare.Repository.Models.CarModel", null)
                        .WithMany()
                        .HasForeignKey("PersonCarsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarShare.Repository.Models.BookingModel", b =>
                {
                    b.HasOne("CarShare.Repository.Models.CarModel", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarShare.Repository.Models.PersonModel", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CarShare.Repository.Models.CarModel", b =>
                {
                    b.HasOne("CarShare.Repository.Models.OwnerModel", "Owner")
                        .WithMany("Car")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarShare.Repository.Models.OwnerModel", b =>
                {
                    b.HasOne("CarShare.Repository.Models.PersonModel", "Person")
                        .WithOne()
                        .HasForeignKey("CarShare.Repository.Models.OwnerModel", "PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CarShare.Repository.Models.PersonModel", b =>
                {
                    b.HasOne("CarShare.Repository.Models.UserModel", "User")
                        .WithOne()
                        .HasForeignKey("CarShare.Repository.Models.PersonModel", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarShare.Repository.Models.OwnerModel", b =>
                {
                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
