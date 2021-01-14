﻿// <auto-generated />
using System;
using Ganjeh.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ganjeh.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210114131854_lat_lng_modified")]
    partial class lat_lng_modified
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Ganjeh.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Lat")
                        .HasColumnType("decimal(10,6)");

                    b.Property<decimal>("Lng")
                        .HasColumnType("decimal(10,6)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegionCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionCityId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RecordType")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RecordType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VideoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PostCategoryId");

                    b.HasIndex("VideoId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.PostCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.RegionCity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegionStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionStateId");

                    b.ToTable("RegionCities");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.RegionCountry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasFilter("[Title] IS NOT NULL");

                    b.ToTable("RegionCountries");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.RegionState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegionCountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionCountryId");

                    b.ToTable("RegionStates");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.Address", b =>
                {
                    b.HasOne("Ganjeh.Domain.Entities.RegionCity", "RegionCity")
                        .WithMany()
                        .HasForeignKey("RegionCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegionCity");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.File", b =>
                {
                    b.HasOne("Ganjeh.Domain.Entities.Post", null)
                        .WithMany("Images")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.Phone", b =>
                {
                    b.HasOne("Ganjeh.Domain.Entities.Post", null)
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.Post", b =>
                {
                    b.HasOne("Ganjeh.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ganjeh.Domain.Entities.PostCategory", "PostCategory")
                        .WithMany("Posts")
                        .HasForeignKey("PostCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ganjeh.Domain.Entities.File", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("PostCategory");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.RegionCity", b =>
                {
                    b.HasOne("Ganjeh.Domain.Entities.RegionState", "RegionState")
                        .WithMany("RegionCities")
                        .HasForeignKey("RegionStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegionState");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.RegionState", b =>
                {
                    b.HasOne("Ganjeh.Domain.Entities.RegionCountry", "RegionCountry")
                        .WithMany("RegionState")
                        .HasForeignKey("RegionCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegionCountry");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.Post", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.PostCategory", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.RegionCountry", b =>
                {
                    b.Navigation("RegionState");
                });

            modelBuilder.Entity("Ganjeh.Domain.Entities.RegionState", b =>
                {
                    b.Navigation("RegionCities");
                });
#pragma warning restore 612, 618
        }
    }
}
