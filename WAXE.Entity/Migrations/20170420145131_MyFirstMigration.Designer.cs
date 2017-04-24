using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WAXE.Entity.Entities.Base;

namespace WAXE.Entity.Migrations
{
    [DbContext(typeof(DomainContext))]
    [Migration("20170420145131_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("WAXE.Entity.Entities.AlbumEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("ImageDataId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.Property<Guid>("RecordLabelId");

                    b.Property<int>("ReleaseDate");

                    b.HasKey("Id");

                    b.HasIndex("ImageDataId");

                    b.HasIndex("RecordLabelId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.AlbumGenreEntity", b =>
                {
                    b.Property<Guid>("AlbumEntityId");

                    b.Property<Guid>("GenreEntityId");

                    b.HasKey("AlbumEntityId", "GenreEntityId");

                    b.HasIndex("GenreEntityId");

                    b.ToTable("AlbumGenreEntity");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.ArtistAlbumEntity", b =>
                {
                    b.Property<Guid>("AlbumId");

                    b.Property<Guid>("ArtistId");

                    b.HasKey("AlbumId", "ArtistId");

                    b.HasIndex("ArtistId");

                    b.ToTable("ArtistAlbumEntity");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.ArtistEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.ArtistRecordLabelEntity", b =>
                {
                    b.Property<Guid>("ArtistId");

                    b.Property<Guid>("RecordLabelId");

                    b.HasKey("ArtistId", "RecordLabelId");

                    b.HasIndex("RecordLabelId");

                    b.ToTable("ArtistRecordLabelEntity");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.ArtistTrackEntity", b =>
                {
                    b.Property<Guid>("ArtistId");

                    b.Property<Guid>("TrackId");

                    b.HasKey("ArtistId", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("ArtistTrackEntity");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.GenreEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.ImageData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Extension");

                    b.Property<byte[]>("ImageBytes");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<byte[]>("SmallImageBytes");

                    b.HasKey("Id");

                    b.ToTable("ImageData");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.RecordLabelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RecordLabels");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.TrackEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AlbumId");

                    b.Property<decimal>("BPM");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.TrackGenreEntity", b =>
                {
                    b.Property<Guid>("TracksId");

                    b.Property<Guid>("GenreId");

                    b.Property<Guid?>("TrackId");

                    b.HasKey("TracksId", "GenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("TrackId");

                    b.ToTable("TrackGenreEntity");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.AlbumEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.ImageData", "ImageData")
                        .WithMany()
                        .HasForeignKey("ImageDataId");

                    b.HasOne("WAXE.Entity.Entities.RecordLabelEntity", "RecordLabel")
                        .WithMany("Albums")
                        .HasForeignKey("RecordLabelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WAXE.Entity.Entities.AlbumGenreEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.AlbumEntity", "Album")
                        .WithMany("AlbumGenre")
                        .HasForeignKey("AlbumEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WAXE.Entity.Entities.GenreEntity", "Genre")
                        .WithMany("AlbumGenre")
                        .HasForeignKey("GenreEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WAXE.Entity.Entities.ArtistAlbumEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.AlbumEntity", "Album")
                        .WithMany("Artists")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WAXE.Entity.Entities.ArtistEntity", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WAXE.Entity.Entities.ArtistRecordLabelEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.ArtistEntity", "Artist")
                        .WithMany("RecordLabels")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WAXE.Entity.Entities.RecordLabelEntity", "RecordLabel")
                        .WithMany("Artists")
                        .HasForeignKey("RecordLabelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WAXE.Entity.Entities.ArtistTrackEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.ArtistEntity", "Artist")
                        .WithMany("Tracks")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WAXE.Entity.Entities.TrackEntity", "Track")
                        .WithMany("Artist")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WAXE.Entity.Entities.TrackEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.AlbumEntity", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.TrackGenreEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.GenreEntity", "Genre")
                        .WithMany("TrackGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WAXE.Entity.Entities.TrackEntity", "Track")
                        .WithMany("Genre")
                        .HasForeignKey("TrackId");
                });
        }
    }
}
