﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockManagement.Data;

#nullable disable

namespace StockManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241126085112_Inial")]
    partial class Inial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockManagement.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "admin",
                            Name = "Clothes"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "admin",
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "admin",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "admin",
                            Name = "Kitchen"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "admin",
                            Name = "Cars"
                        });
                });

            modelBuilder.Entity("StockManagement.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("IssuedFor")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SerialNumber")
                        .IsUnique()
                        .HasFilter("[SerialNumber] IS NOT NULL");

                    b.HasIndex("StoreId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "A high-end smartphone with amazing features",
                            Name = "Smartphone XYZ",
                            Price = 799.00m,
                            SerialNumber = "f37d9670-31e3-4f0b-ad73-8796dfb88196",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedBy = "admin",
                            Description = "A premium leather jacket for winter",
                            Name = "Stylish Leather Jacket",
                            Price = 120.00m,
                            SerialNumber = "3bd2b3f9-76d0-4a10-ac87-cbe96cf2e36e",
                            Status = 2,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "Noise-canceling wireless headphones",
                            Name = "Bluetooth Headphones",
                            Price = 150.00m,
                            SerialNumber = "22ff2eac-91b6-4b8c-a914-1b4d67f25e90",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedBy = "admin",
                            Description = "A cozy winter jacket to keep you warm",
                            Name = "Winter Jacket",
                            Price = 80.00m,
                            SerialNumber = "c826f33b-832c-4cd3-a39a-c91869a5fcd2",
                            Status = 4,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "A smartwatch with fitness tracking and notifications",
                            Name = "Smart Watch",
                            Price = 200.00m,
                            SerialNumber = "b47c50f1-6b59-4079-a6f0-5344ba4b9661",
                            Status = 1,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "Ultra HD LED TV with smart features",
                            Name = "LED TV",
                            Price = 500.00m,
                            SerialNumber = "4833dbe7-e8f1-4b73-be35-dd096c2176d8",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Fast boiling electric kettle for quick tea or coffee",
                            Name = "Electric Kettle",
                            Price = 30.00m,
                            SerialNumber = "ce388e1d-a804-48fd-a5b2-2991cba84cad",
                            Status = 4,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Energy-efficient fridge with large capacity",
                            Name = "Refrigerator",
                            Price = 800.00m,
                            SerialNumber = "0cf895a8-e50b-47ee-9230-5276a8434ef6",
                            Status = 1,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "Water-resistant portable Bluetooth speaker",
                            Name = "Portable Speaker",
                            Price = 90.00m,
                            SerialNumber = "774904a8-9b46-484f-87bc-d77a5df82381",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Healthy cooking with this modern air fryer",
                            Name = "Air Fryer",
                            Price = 150.00m,
                            SerialNumber = "651271e9-0f22-42d3-b640-c399407eb233",
                            Status = 2,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Sonic electric toothbrush for cleaner teeth",
                            Name = "Electric Toothbrush",
                            Price = 60.00m,
                            SerialNumber = "07a3d514-a39f-4eb3-903a-8eac2e4c1aca",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "High-quality digital camera for photography enthusiasts",
                            Name = "Digital Camera",
                            Price = 400.00m,
                            SerialNumber = "266e73ac-d6ac-405b-93f1-f8314a30684d",
                            Status = 1,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "Ergonomic gaming mouse with customizable buttons",
                            IssuedFor = "user",
                            Name = "Gaming Mouse",
                            Price = 50.00m,
                            SerialNumber = "dbfff037-2dd6-4984-88d6-b2fae59d2797",
                            Status = 3,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Adjustable desk lamp with LED lighting",
                            Name = "LED Desk Lamp",
                            Price = 40.00m,
                            SerialNumber = "8a30c1a3-d4f5-4b7c-98d0-441e845a61ba",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 5,
                            CreatedBy = "admin",
                            Description = "Magnetic phone mount for easy car navigation",
                            Name = "Car Phone Mount",
                            Price = 20.00m,
                            SerialNumber = "d73beb2a-7e51-488e-9c16-3e50bc9f9b5d",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 5,
                            CreatedBy = "admin",
                            Description = "Spacious 4-person camping tent with waterproof design",
                            Name = "Camping Tent",
                            Price = 120.00m,
                            SerialNumber = "d51cec3a-2a8f-4181-9800-58064a997339",
                            Status = 4,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Wi-Fi enabled smart thermostat for energy savings",
                            Name = "Smart Thermostat",
                            Price = 250.00m,
                            SerialNumber = "4b15db37-9f21-424b-9524-21f7b5a4ba7a",
                            Status = 4,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "High-capacity portable power bank for smartphones",
                            Name = "Portable Charger",
                            Price = 40.00m,
                            SerialNumber = "58fa5abf-4ca2-4a38-ba50-14548992ed67",
                            Status = 2,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 1,
                            CreatedBy = "admin",
                            Description = "Durable and spacious backpack for laptops and accessories",
                            IssuedFor = "user",
                            Name = "Laptop Backpack",
                            Price = 40.00m,
                            SerialNumber = "538fa706-0499-4134-af2d-f7c528b40981",
                            Status = 3,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 1,
                            CreatedBy = "admin",
                            Description = "Sleek modern wall clock with a minimal design",
                            Name = "Wall Clock",
                            Price = 25.00m,
                            SerialNumber = "76b80998-d196-48c9-ab63-b5369b0bc78a",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Professional blow dryer with multiple heat settings",
                            Name = "Hair Dryer",
                            Price = 70.00m,
                            SerialNumber = "77157404-8e16-4ec3-945d-95968641b57e",
                            Status = 1,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Blend your smoothies on the go with this portable blender",
                            IssuedFor = "user",
                            Name = "Portable Blender",
                            Price = 45.00m,
                            SerialNumber = "f840d7c8-66ab-40e5-a77b-acc17df90430",
                            Status = 3,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 5,
                            CreatedBy = "admin",
                            Description = "Portable camping stove for outdoor cooking",
                            Name = "Camping Stove",
                            Price = 70.00m,
                            SerialNumber = "05ac159d-200b-4293-a40d-3e74b8e800f3",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 3,
                            CreatedBy = "admin",
                            Description = "Wearable fitness tracker to monitor daily activities",
                            Name = "Fitness Tracker",
                            Price = 130.00m,
                            SerialNumber = "6c902155-b74b-4e80-9405-4514d79a62eb",
                            Status = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 1,
                            CreatedBy = "admin",
                            Description = "Ergonomic gaming chair with adjustable armrests",
                            IssuedFor = "user",
                            Name = "Gaming Chair",
                            Price = 180.00m,
                            SerialNumber = "2f946330-3999-47f6-817e-8d9d840c9e10",
                            Status = 3,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 5,
                            CreatedBy = "admin",
                            Description = "Eco-friendly solar charger for your devices",
                            Name = "Solar Charger",
                            Price = 35.00m,
                            SerialNumber = "de1b3592-c371-4d1c-8570-bd7c6078faec",
                            Status = 1,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 4,
                            CreatedBy = "admin",
                            Description = "Home air purifier with HEPA filter for cleaner air",
                            Name = "Air Purifier",
                            Price = 150.00m,
                            SerialNumber = "3131938f-c4b3-4a85-b5f9-357eb3c4eb39",
                            Status = 1,
                            StoreId = 1
                        });
                });

            modelBuilder.Entity("StockManagement.Domain.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StoreKeeperId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreKeeperId")
                        .IsUnique();

                    b.ToTable("Stores", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "admin",
                            Name = "Store 1",
                            StoreKeeperId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "admin",
                            Name = "Store 2",
                            StoreKeeperId = 2
                        });
                });

            modelBuilder.Entity("StockManagement.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsFirstLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Role")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "admin",
                            FirstName = "admin",
                            IsFirstLogin = false,
                            LastName = "admin",
                            Password = "AQAAAAIAAYagAAAAEBmmQlp0o9/PqVQcEjJ5oNpr1RxHPVpnOyGBscpUHbSXCl7kzQEVegBMjXDTFM/Ydg==",
                            Role = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "admin",
                            FirstName = "user",
                            IsFirstLogin = false,
                            LastName = "user",
                            Password = "AQAAAAIAAYagAAAAEGdZtz5RkGhUDdGEeKNmKCJDPTinAGa973qimlZil+OrKHz9o0J/f7c5wgLcsjmOFA==",
                            Role = 2,
                            Username = "user"
                        });
                });

            modelBuilder.Entity("StockManagement.Domain.Entities.Product", b =>
                {
                    b.HasOne("StockManagement.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockManagement.Domain.Entities.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("StockManagement.Domain.Entities.Store", b =>
                {
                    b.HasOne("StockManagement.Domain.Entities.User", "StoreKeeper")
                        .WithOne()
                        .HasForeignKey("StockManagement.Domain.Entities.Store", "StoreKeeperId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StoreKeeper");
                });

            modelBuilder.Entity("StockManagement.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StockManagement.Domain.Entities.Store", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
