using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WAXE.Entity.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
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
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlbumEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArtistEntityId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumEntity_Artists_ArtistEntityId",
                        column: x => x.ArtistEntityId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecordLabelEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArtistEntityId = table.Column<Guid>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordLabelEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordLabelEntity_Artists_ArtistEntityId",
                        column: x => x.ArtistEntityId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_AlbumEntity_ArtistEntityId",
                table: "AlbumEntity",
                column: "ArtistEntityId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordLabelEntity");

            migrationBuilder.DropTable(
                name: "TracksEntity");

            migrationBuilder.DropTable(
                name: "AlbumEntity");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
