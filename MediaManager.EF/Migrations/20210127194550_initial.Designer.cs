﻿// <auto-generated />
using System;
using MediaManager.EF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediaManager.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210127194550_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11");

            modelBuilder.Entity("MediaManager.Domains.Models.Demographic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AllowedAge")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Demographics");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.Media", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AltTitle")
                        .HasColumnType("TEXT");

                    b.Property<double>("AverageRating")
                        .HasColumnType("REAL");

                    b.Property<int?>("DemographicID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LanguageID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Synopsis")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Thumbnail")
                        .HasColumnType("BLOB");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("DemographicID");

                    b.HasIndex("LanguageID");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.MediaDirectory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DriveName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFile")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MediaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<double>("Size")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("MediaID");

                    b.ToTable("MediaDirectories");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.MediaGenre", b =>
                {
                    b.Property<int>("MediaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MediaID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("MediaGenre");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MediaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Source")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("MediaID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.Media", b =>
                {
                    b.HasOne("MediaManager.Domains.Models.Demographic", "Demographic")
                        .WithMany("MediaEntities")
                        .HasForeignKey("DemographicID");

                    b.HasOne("MediaManager.Domains.Models.Language", "Language")
                        .WithMany("MediaEntities")
                        .HasForeignKey("LanguageID");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.MediaDirectory", b =>
                {
                    b.HasOne("MediaManager.Domains.Models.Media", null)
                        .WithMany("MediaDirectories")
                        .HasForeignKey("MediaID");
                });

            modelBuilder.Entity("MediaManager.Domains.Models.MediaGenre", b =>
                {
                    b.HasOne("MediaManager.Domains.Models.Genre", "Genre")
                        .WithMany("MediaGenre")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaManager.Domains.Models.Media", "Media")
                        .WithMany("MediaGenres")
                        .HasForeignKey("MediaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MediaManager.Domains.Models.Rating", b =>
                {
                    b.HasOne("MediaManager.Domains.Models.Media", null)
                        .WithMany("Ratings")
                        .HasForeignKey("MediaID");
                });
#pragma warning restore 612, 618
        }
    }
}
