﻿// <auto-generated />
using System;
using Lecture_5_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lecture_5_MVC.Migrations
{
    [DbContext(typeof(EcomContext))]
    [Migration("20231216220542_intiDB")]
    partial class intiDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lecture_5_MVC.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("imagepath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("unitprice")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Lecture_5_MVC.Models.ProductGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductGallerys");
                });

            modelBuilder.Entity("Lecture_5_MVC.Models.ProductGallery", b =>
                {
                    b.HasOne("Lecture_5_MVC.Models.Product", null)
                        .WithMany("imageGallery")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Lecture_5_MVC.Models.Product", b =>
                {
                    b.Navigation("imageGallery");
                });
#pragma warning restore 612, 618
        }
    }
}