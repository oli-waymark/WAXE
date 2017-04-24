using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WAXE.Entity.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumEntity_Artists_ArtistEntityId",
                table: "AlbumEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordLabelEntity_Artists_ArtistEntityId",
                table: "RecordLabelEntity");

            migrationBuilder.DropTable(
                name: "TracksEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordLabelEntity",
                table: "RecordLabelEntity");

            migrationBuilder.DropIndex(
                name: "IX_RecordLabelEntity_ArtistEntityId",
                table: "RecordLabelEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumEntity",
                table: "AlbumEntity");

            migrationBuilder.DropColumn(
                name: "ArtistEntityId",
                table: "RecordLabelEntity");

            migrationBuilder.RenameTable(
                name: "RecordLabelEntity",
                newName: "RecordLabels");

            migrationBuilder.RenameTable(
                name: "AlbumEntity",
                newName: "Albums");

            migrationBuilder.RenameColumn(
                name: "ArtistEntityId",
                table: "Albums",
                newName: "ImageDataId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumEntity_ArtistEntityId",
                table: "Albums",
                newName: "IX_Albums_ImageDataId");

            migrationBuilder.AddColumn<Guid>(
                name: "RecordLabelId",
                table: "Albums",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ReleaseDate",
                table: "Albums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordLabels",
                table: "RecordLabels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ArtistAlbumEntity",
                columns: table => new
                {
                    AlbumId = table.Column<Guid>(nullable: false),
                    ArtistId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistAlbumEntity", x => new { x.AlbumId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_ArtistAlbumEntity_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistAlbumEntity_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistRecordLabelEntity",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    RecordLabelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistRecordLabelEntity", x => new { x.ArtistId, x.RecordLabelId });
                    table.ForeignKey(
                        name: "FK_ArtistRecordLabelEntity_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistRecordLabelEntity_RecordLabels_RecordLabelId",
                        column: x => x.RecordLabelId,
                        principalTable: "RecordLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    ImageBytes = table.Column<byte[]>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    SmallImageBytes = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AlbumId = table.Column<Guid>(nullable: true),
                    BPM = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlbumGenreEntity",
                columns: table => new
                {
                    AlbumEntityId = table.Column<Guid>(nullable: false),
                    GenreEntityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumGenreEntity", x => new { x.AlbumEntityId, x.GenreEntityId });
                    table.ForeignKey(
                        name: "FK_AlbumGenreEntity_Albums_AlbumEntityId",
                        column: x => x.AlbumEntityId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumGenreEntity_Genres_GenreEntityId",
                        column: x => x.GenreEntityId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistTrackEntity",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    TrackId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistTrackEntity", x => new { x.ArtistId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_ArtistTrackEntity_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistTrackEntity_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackGenreEntity",
                columns: table => new
                {
                    TracksId = table.Column<Guid>(nullable: false),
                    GenreId = table.Column<Guid>(nullable: false),
                    TrackId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackGenreEntity", x => new { x.TracksId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_TrackGenreEntity_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackGenreEntity_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_RecordLabelId",
                table: "Albums",
                column: "RecordLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumGenreEntity_GenreEntityId",
                table: "AlbumGenreEntity",
                column: "GenreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistAlbumEntity_ArtistId",
                table: "ArtistAlbumEntity",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistRecordLabelEntity_RecordLabelId",
                table: "ArtistRecordLabelEntity",
                column: "RecordLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTrackEntity_TrackId",
                table: "ArtistTrackEntity",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackGenreEntity_GenreId",
                table: "TrackGenreEntity",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackGenreEntity_TrackId",
                table: "TrackGenreEntity",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_ImageData_ImageDataId",
                table: "Albums",
                column: "ImageDataId",
                principalTable: "ImageData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_RecordLabels_RecordLabelId",
                table: "Albums",
                column: "RecordLabelId",
                principalTable: "RecordLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_ImageData_ImageDataId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_RecordLabels_RecordLabelId",
                table: "Albums");

            migrationBuilder.DropTable(
                name: "AlbumGenreEntity");

            migrationBuilder.DropTable(
                name: "ArtistAlbumEntity");

            migrationBuilder.DropTable(
                name: "ArtistRecordLabelEntity");

            migrationBuilder.DropTable(
                name: "ArtistTrackEntity");

            migrationBuilder.DropTable(
                name: "ImageData");

            migrationBuilder.DropTable(
                name: "TrackGenreEntity");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordLabels",
                table: "RecordLabels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_RecordLabelId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "RecordLabelId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "RecordLabels",
                newName: "RecordLabelEntity");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "AlbumEntity");

            migrationBuilder.RenameColumn(
                name: "ImageDataId",
                table: "AlbumEntity",
                newName: "ArtistEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_ImageDataId",
                table: "AlbumEntity",
                newName: "IX_AlbumEntity_ArtistEntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtistEntityId",
                table: "RecordLabelEntity",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordLabelEntity",
                table: "RecordLabelEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumEntity",
                table: "AlbumEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TracksEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AlbumId = table.Column<Guid>(nullable: true),
                    ArtistEntityId = table.Column<Guid>(nullable: true),
                    BPM = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TracksEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TracksEntity_AlbumEntity_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "AlbumEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TracksEntity_Artists_ArtistEntityId",
                        column: x => x.ArtistEntityId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordLabelEntity_ArtistEntityId",
                table: "RecordLabelEntity",
                column: "ArtistEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TracksEntity_AlbumId",
                table: "TracksEntity",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_TracksEntity_ArtistEntityId",
                table: "TracksEntity",
                column: "ArtistEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumEntity_Artists_ArtistEntityId",
                table: "AlbumEntity",
                column: "ArtistEntityId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordLabelEntity_Artists_ArtistEntityId",
                table: "RecordLabelEntity",
                column: "ArtistEntityId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
