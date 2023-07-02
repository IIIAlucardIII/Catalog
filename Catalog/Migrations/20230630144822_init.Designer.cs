﻿// <auto-generated />
using System;
using Catalog.DB_Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Migrations
{
    [DbContext(typeof(FolderDbContext))]
    [Migration("20230630144822_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catalog.Models.FolderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Creating Digital Images",
                            Path = "Creating Digital Images"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Resources",
                            ParentId = 1,
                            Path = "Creating Digital Images/Resources"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Primary Sources",
                            ParentId = 2,
                            Path = "Creating Digital Images/Resources/Primary Sources"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Secondary Sources",
                            ParentId = 2,
                            Path = "Creating Digital Images/Resources/Secondary Sources"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Evidence",
                            ParentId = 1,
                            Path = "Creating Digital Images/Evidence"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Graphic Products",
                            ParentId = 1,
                            Path = "Creating Digital Images/Graphic Products"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Process",
                            ParentId = 4,
                            Path = "Creating Digital Images/Graphic Products/Process"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Final Product",
                            ParentId = 4,
                            Path = "Creating Digital Images/Graphic Products/Final Product"
                        });
                });

            modelBuilder.Entity("Catalog.Models.FolderModel", b =>
                {
                    b.HasOne("Catalog.Models.FolderModel", null)
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Catalog.Models.FolderModel", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
