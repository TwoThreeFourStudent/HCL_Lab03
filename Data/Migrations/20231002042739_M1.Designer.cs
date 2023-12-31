﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvinceAndCities.Data;

#nullable disable

namespace ProvinceAndCities.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231002042739_M1")]
    partial class M1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProvinceAndCities.Models.City", b =>
                {
                    b.Property<int?>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CityID"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Population")
                        .HasColumnType("int");

                    b.Property<string>("ProvinceCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CityID");

                    b.HasIndex("ProvinceCode");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            CityName = "Vancouver",
                            Population = 10,
                            ProvinceCode = "BC"
                        },
                        new
                        {
                            CityID = 2,
                            CityName = "Surrey",
                            Population = 9,
                            ProvinceCode = "BC"
                        },
                        new
                        {
                            CityID = 3,
                            CityName = "Calgary",
                            Population = 10,
                            ProvinceCode = "AB"
                        },
                        new
                        {
                            CityID = 4,
                            CityName = "Red Deer",
                            Population = 11,
                            ProvinceCode = "AB"
                        });
                });

            modelBuilder.Entity("ProvinceAndCities.Models.Province", b =>
                {
                    b.Property<string>("ProvinceCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProvinceName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProvinceCode");

                    b.ToTable("Province", (string)null);

                    b.HasData(
                        new
                        {
                            ProvinceCode = "BC",
                            ProvinceName = "British Columbia"
                        },
                        new
                        {
                            ProvinceCode = "AB",
                            ProvinceName = "Alberta"
                        });
                });

            modelBuilder.Entity("ProvinceAndCities.Models.City", b =>
                {
                    b.HasOne("ProvinceAndCities.Models.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceCode");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("ProvinceAndCities.Models.Province", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
