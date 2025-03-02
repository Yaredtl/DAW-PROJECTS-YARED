﻿// <auto-generated />
using System;
using Discografia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Discografia.Migrations
{
    [DbContext(typeof(ChinookContext))]
    partial class ChinookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Discografia.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.HasKey("AlbumId");

                    b.HasIndex(new[] { "ArtistId" }, "IFK_AlbumArtistId");

                    b.ToTable("Album", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Discografia.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Discografia.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 212,
                            Description = "Re loco el concierto",
                            Points = 4,
                            Title = "Ta bueno"
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 155,
                            Description = "Decepcionante",
                            Points = 1,
                            Title = "Conierto"
                        });
                });

            modelBuilder.Entity("Discografia.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("Bytes")
                        .HasColumnType("int");

                    b.Property<string>("Composer")
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Milliseconds")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric(10, 2)");

                    b.HasKey("TrackId");

                    b.HasIndex(new[] { "AlbumId" }, "IFK_TrackAlbumId");

                    b.HasIndex(new[] { "GenreId" }, "IFK_TrackGenreId");

                    b.HasIndex(new[] { "MediaTypeId" }, "IFK_TrackMediaTypeId");

                    b.ToTable("Track", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Discografia.Models.Album", b =>
                {
                    b.HasOne("Discografia.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AlbumArtistId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Discografia.Models.Review", b =>
                {
                    b.HasOne("Discografia.Models.Artist", "Artist")
                        .WithMany("Reviews")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Discografia.Models.Track", b =>
                {
                    b.HasOne("Discografia.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TrackAlbumId");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Discografia.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Discografia.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
