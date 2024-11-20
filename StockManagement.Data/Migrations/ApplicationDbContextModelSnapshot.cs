﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockManagement.Data;

#nullable disable

namespace StockManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockManagement.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A high-end smartphone with amazing features",
                            Name = "Smartphone XYZ",
                            Price = 799.00m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 2,
                            Category = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A premium leather jacket for winter",
                            Name = "Stylish Leather Jacket",
                            Price = 120.00m,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 3,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Noise-canceling wireless headphones",
                            Name = "Bluetooth Headphones",
                            Price = 150.00m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 4,
                            Category = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A cozy winter jacket to keep you warm",
                            Name = "Winter Jacket",
                            Price = 80.00m,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 5,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A smartwatch with fitness tracking and notifications",
                            Name = "Smart Watch",
                            Price = 200.00m,
                            Quantity = 75
                        },
                        new
                        {
                            Id = 6,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ultra HD LED TV with smart features",
                            Name = "LED TV",
                            Price = 500.00m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 7,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fast boiling electric kettle for quick tea or coffee",
                            Name = "Electric Kettle",
                            Price = 30.00m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 8,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Energy-efficient fridge with large capacity",
                            Name = "Refrigerator",
                            Price = 800.00m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 9,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Water-resistant portable Bluetooth speaker",
                            Name = "Portable Speaker",
                            Price = 90.00m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 10,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Healthy cooking with this modern air fryer",
                            Name = "Air Fryer",
                            Price = 150.00m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 11,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sonic electric toothbrush for cleaner teeth",
                            Name = "Electric Toothbrush",
                            Price = 60.00m,
                            Quantity = 80
                        },
                        new
                        {
                            Id = 12,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "High-quality digital camera for photography enthusiasts",
                            Name = "Digital Camera",
                            Price = 400.00m,
                            Quantity = 35
                        },
                        new
                        {
                            Id = 13,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ergonomic gaming mouse with customizable buttons",
                            Name = "Gaming Mouse",
                            Price = 50.00m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 14,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Adjustable desk lamp with LED lighting",
                            Name = "LED Desk Lamp",
                            Price = 40.00m,
                            Quantity = 150
                        },
                        new
                        {
                            Id = 15,
                            Category = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Magnetic phone mount for easy car navigation",
                            Name = "Car Phone Mount",
                            Price = 20.00m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 16,
                            Category = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Spacious 4-person camping tent with waterproof design",
                            Name = "Camping Tent",
                            Price = 120.00m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 17,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Wi-Fi enabled smart thermostat for energy savings",
                            Name = "Smart Thermostat",
                            Price = 250.00m,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 18,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "High-capacity portable power bank for smartphones",
                            Name = "Portable Charger",
                            Price = 40.00m,
                            Quantity = 150
                        },
                        new
                        {
                            Id = 19,
                            Category = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Durable and spacious backpack for laptops and accessories",
                            Name = "Laptop Backpack",
                            Price = 40.00m,
                            Quantity = 80
                        },
                        new
                        {
                            Id = 20,
                            Category = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sleek modern wall clock with a minimal design",
                            Name = "Wall Clock",
                            Price = 25.00m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 21,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Professional blow dryer with multiple heat settings",
                            Name = "Hair Dryer",
                            Price = 70.00m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 22,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Blend your smoothies on the go with this portable blender",
                            Name = "Portable Blender",
                            Price = 45.00m,
                            Quantity = 75
                        },
                        new
                        {
                            Id = 23,
                            Category = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Portable camping stove for outdoor cooking",
                            Name = "Camping Stove",
                            Price = 70.00m,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 24,
                            Category = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Wearable fitness tracker to monitor daily activities",
                            Name = "Fitness Tracker",
                            Price = 130.00m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 25,
                            Category = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ergonomic gaming chair with adjustable armrests",
                            Name = "Gaming Chair",
                            Price = 180.00m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 26,
                            Category = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Eco-friendly solar charger for your devices",
                            Name = "Solar Charger",
                            Price = 35.00m,
                            Quantity = 110
                        },
                        new
                        {
                            Id = 27,
                            Category = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Home air purifier with HEPA filter for cleaner air",
                            Name = "Air Purifier",
                            Price = 150.00m,
                            Quantity = 25
                        });
                });

            modelBuilder.Entity("StockManagement.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin123",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "user123",
                            Role = "User",
                            Username = "user"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
