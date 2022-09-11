﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooWebShopAPI.Persistence.DbContexts;

#nullable disable

namespace ZooWebShopAPI.Migrations
{
    [DbContext(typeof(CommandDbContext))]
    [Migration("20220811155019_UserAndRoles")]
    partial class UserAndRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ZooWebShopAPI.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1220),
                            Name = "Dog food"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1266),
                            Name = "Cat food"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1270),
                            Name = "Rabbit food"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1272),
                            Name = "Bird food"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1275),
                            Name = "Fish food"
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1279),
                            Name = "Dog toys"
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1282),
                            Name = "Cat toys"
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1284),
                            Name = "Rabbit cages"
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1287),
                            Name = "Transport"
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(2022, 8, 11, 17, 50, 18, 681, DateTimeKind.Local).AddTicks(1290),
                            Name = "Bird cage"
                        });
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("MainPhotoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.Photo", b =>
                {
                    b.HasOne("ZooWebShopAPI.Entities.Product", "Product")
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.ProductCategory", b =>
                {
                    b.HasOne("ZooWebShopAPI.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooWebShopAPI.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.User", b =>
                {
                    b.HasOne("ZooWebShopAPI.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("ZooWebShopAPI.Entities.Product", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
