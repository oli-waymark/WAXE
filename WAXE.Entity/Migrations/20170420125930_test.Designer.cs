using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WAXE.Entity.Entities.Base;

namespace WAXE.Entity.Migrations
{
    [DbContext(typeof(DomainContext))]
    [Migration("20170420125930_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("WAXE.Entity.Entities.AlbumEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ArtistEntityId");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ArtistEntityId");

                    b.ToTable("AlbumEntity");
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

            modelBuilder.Entity("WAXE.Entity.Entities.RecordLabelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ArtistEntityId");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ArtistEntityId");

                    b.ToTable("RecordLabelEntity");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.TracksEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AlbumId");

                    b.Property<Guid?>("ArtistEntityId");

                    b.Property<decimal>("BPM");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistEntityId");

                    b.ToTable("TracksEntity");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.AlbumEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.ArtistEntity")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistEntityId");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.RecordLabelEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.ArtistEntity")
                        .WithMany("RecordLabels")
                        .HasForeignKey("ArtistEntityId");
                });

            modelBuilder.Entity("WAXE.Entity.Entities.TracksEntity", b =>
                {
                    b.HasOne("WAXE.Entity.Entities.AlbumEntity", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId");

                    b.HasOne("WAXE.Entity.Entities.ArtistEntity")
                        .WithMany("Tracks")
                        .HasForeignKey("ArtistEntityId");
                });
        }
    }
}
