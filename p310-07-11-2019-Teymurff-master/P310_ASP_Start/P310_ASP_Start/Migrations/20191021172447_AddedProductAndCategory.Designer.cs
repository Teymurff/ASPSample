﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P310_ASP_Start.DAL;

namespace P310_ASP_Start.Migrations
{
    [DbContext(typeof(EliteContext))]
    [Migration("20191021172447_AddedProductAndCategory")]
    partial class AddedProductAndCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P310_ASP_Start.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Men's" },
                        new { Id = 2, Name = "Women's" },
                        new { Id = 3, Name = "Bags" },
                        new { Id = 4, Name = "Footwear" }
                    );
                });

            modelBuilder.Entity("P310_ASP_Start.Models.NewArrival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("NewArrivals");

                    b.HasData(
                        new { Id = 1, Image = "bottom1.jpg", Title = "<span>f</span>all ahead" },
                        new { Id = 2, Image = "bottom2.jpg", Title = "<span>f</span>all ahead" }
                    );
                });

            modelBuilder.Entity("P310_ASP_Start.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<decimal>("DiscountedPrice");

                    b.Property<bool>("HasDiscount");

                    b.Property<string>("Image")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, CategoryId = 1, CreatedAt = new DateTime(2019, 10, 21, 21, 24, 46, 721, DateTimeKind.Local), DiscountedPrice = 0m, HasDiscount = false, Image = "w1.jpg", Name = "T-short 1", Price = 100m },
                        new { Id = 2, CategoryId = 2, CreatedAt = new DateTime(2019, 10, 21, 21, 24, 46, 723, DateTimeKind.Local), DiscountedPrice = 0m, HasDiscount = false, Image = "w2.jpg", Name = "Bluse 1", Price = 120m },
                        new { Id = 3, CategoryId = 2, CreatedAt = new DateTime(2019, 10, 21, 21, 24, 46, 723, DateTimeKind.Local), DiscountedPrice = 0m, HasDiscount = false, Image = "w3.jpg", Name = "Shoes 2", Price = 150m },
                        new { Id = 4, CategoryId = 3, CreatedAt = new DateTime(2019, 10, 21, 21, 24, 46, 723, DateTimeKind.Local), DiscountedPrice = 0m, HasDiscount = false, Image = "w4.jpg", Name = "Short 3", Price = 155m }
                    );
                });

            modelBuilder.Entity("P310_ASP_Start.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasMaxLength(255);

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Sliders");

                    b.HasData(
                        new { Id = 1, Image = "banner1.jpg", SubTitle = "Special for today", Title = "The Biggest <span>Sale</span> " },
                        new { Id = 2, Image = "banner2.jpg", SubTitle = "New Arrivals On Sale", Title = "SUMMER <span>COLLECTION </span> " },
                        new { Id = 3, Image = "banner3.jpg", SubTitle = "Special for Kamran", Title = "The Biggest <span>Sale</span> " },
                        new { Id = 4, Image = "banner4.jpg", SubTitle = "Special for Ruslan", Title = "The Biggest <span>Perviz ever</span> " }
                    );
                });

            modelBuilder.Entity("P310_ASP_Start.Models.Product", b =>
                {
                    b.HasOne("P310_ASP_Start.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}