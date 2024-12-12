#nullable disable

namespace Infrastructure.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class RenameAndUpdatePostToAnnouncementModel : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Posts");

        migrationBuilder.DropColumn(
            name: "FuelType",
            table: "VehicleModels");

        migrationBuilder.CreateTable(
            name: "Announcements",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Title = table.Column<string>(type: "text", nullable: true),
                Description = table.Column<string>(type: "text", nullable: true),
                Price = table.Column<double>(type: "double precision", nullable: false),
                Mileage = table.Column<short>(type: "smallint", nullable: false),
                IsHot = table.Column<bool>(type: "boolean", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: false),
                CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                PublishAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                VehicleId = table.Column<Guid>(type: "uuid", nullable: true),
                OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Announcements", x => x.Id);
                table.ForeignKey(
                    name: "FK_Announcements_Users_OwnerId",
                    column: x => x.OwnerId,
                    principalTable: "Users",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Announcements_VehicleModels_VehicleId",
                    column: x => x.VehicleId,
                    principalTable: "VehicleModels",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Announcements_OwnerId",
            table: "Announcements",
            column: "OwnerId");

        migrationBuilder.CreateIndex(
            name: "IX_Announcements_VehicleId",
            table: "Announcements",
            column: "VehicleId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Announcements");

        migrationBuilder.AddColumn<int>(
            name: "FuelType",
            table: "VehicleModels",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateTable(
            name: "Posts",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                VehicleId = table.Column<Guid>(type: "uuid", nullable: true),
                ActiveTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                IsActive = table.Column<bool>(type: "boolean", nullable: false),
                IsHot = table.Column<bool>(type: "boolean", nullable: false),
                Mileage = table.Column<short>(type: "smallint", nullable: false),
                Price = table.Column<int>(type: "integer", nullable: false),
                PublishAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Posts", x => x.Id);
                table.ForeignKey(
                    name: "FK_Posts_Users_OwnerId",
                    column: x => x.OwnerId,
                    principalTable: "Users",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Posts_VehicleModels_VehicleId",
                    column: x => x.VehicleId,
                    principalTable: "VehicleModels",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Posts_OwnerId",
            table: "Posts",
            column: "OwnerId");

        migrationBuilder.CreateIndex(
            name: "IX_Posts_VehicleId",
            table: "Posts",
            column: "VehicleId");
    }
}
