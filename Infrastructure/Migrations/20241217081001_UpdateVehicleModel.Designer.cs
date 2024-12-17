﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241217081001_UpdateVehicleModel")]
    partial class UpdateVehicleModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AnnouncementImage", b =>
                {
                    b.Property<Guid>("AnnouncementsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImagesId")
                        .HasColumnType("uuid");

                    b.HasKey("AnnouncementsId", "ImagesId");

                    b.HasIndex("ImagesId");

                    b.ToTable("AnnouncementImage");
                });

            modelBuilder.Entity("Domain.Entities.Announcement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsHot")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<short>("Mileage")
                        .HasColumnType("smallint");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<DateTimeOffset?>("PublishAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<string>("PublicId")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("bytea");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.VehicleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("EngineCapacity")
                        .HasColumnType("integer");

                    b.Property<int>("EngineType")
                        .HasColumnType("integer");

                    b.Property<int>("Make")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("VehicleType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("AnnouncementImage", b =>
                {
                    b.HasOne("Domain.Entities.Announcement", null)
                        .WithMany()
                        .HasForeignKey("AnnouncementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Announcement", b =>
                {
                    b.HasOne("Domain.Entities.User", "Owner")
                        .WithMany("Announcements")
                        .HasForeignKey("OwnerId");

                    b.HasOne("Domain.Entities.VehicleModel", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Owner");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Announcements");
                });
#pragma warning restore 612, 618
        }
    }
}
