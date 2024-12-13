#nullable disable

namespace Infrastructure.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddImageEntity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ImgUrl",
            table: "Users");

        migrationBuilder.AddColumn<Guid>(
            name: "ImageId",
            table: "Users",
            type: "uuid",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "Images",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                IsMain = table.Column<bool>(type: "boolean", nullable: false),
                Url = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Images", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AnnouncementImage",
            columns: table => new
            {
                AnnouncementsId = table.Column<Guid>(type: "uuid", nullable: false),
                ImagesId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AnnouncementImage", x => new { x.AnnouncementsId, x.ImagesId });
                table.ForeignKey(
                    name: "FK_AnnouncementImage_Announcements_AnnouncementsId",
                    column: x => x.AnnouncementsId,
                    principalTable: "Announcements",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AnnouncementImage_Images_ImagesId",
                    column: x => x.ImagesId,
                    principalTable: "Images",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Users_ImageId",
            table: "Users",
            column: "ImageId");

        migrationBuilder.CreateIndex(
            name: "IX_AnnouncementImage_ImagesId",
            table: "AnnouncementImage",
            column: "ImagesId");

        migrationBuilder.AddForeignKey(
            name: "FK_Users_Images_ImageId",
            table: "Users",
            column: "ImageId",
            principalTable: "Images",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Users_Images_ImageId",
            table: "Users");

        migrationBuilder.DropTable(
            name: "AnnouncementImage");

        migrationBuilder.DropTable(
            name: "Images");

        migrationBuilder.DropIndex(
            name: "IX_Users_ImageId",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "ImageId",
            table: "Users");

        migrationBuilder.AddColumn<string>(
            name: "ImgUrl",
            table: "Users",
            type: "text",
            nullable: true);
    }
}
