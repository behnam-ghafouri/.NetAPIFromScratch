﻿// <auto-generated />
using System;
using Behnam_BehnamAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BehnamBehnamAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230106225706_seedDutyTable")]
    partial class seedDutyTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Behnam_BehnamAPI.Model.Duty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Duties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 1, 7, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(931),
                            ImageUrl = "https://something",
                            Name = "test1",
                            Rate = "5",
                            Sqft = 100
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 1, 8, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(974),
                            ImageUrl = "https://something",
                            Name = "test2",
                            Rate = "5",
                            Sqft = 100
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 1, 9, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(976),
                            ImageUrl = "https://something",
                            Name = "test3",
                            Rate = "5",
                            Sqft = 100
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 1, 10, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(978),
                            ImageUrl = "https://something",
                            Name = "test4",
                            Rate = "5",
                            Sqft = 100
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 1, 11, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(980),
                            ImageUrl = "https://something",
                            Name = "test5",
                            Rate = "5",
                            Sqft = 100
                        });
                });
#pragma warning restore 612, 618
        }
    }
}