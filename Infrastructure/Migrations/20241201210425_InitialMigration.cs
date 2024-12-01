#nullable disable

namespace Infrastructure.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Vehicles",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Type = table.Column<string>(type: "text", nullable: false),
                Make = table.Column<string>(type: "text", nullable: false),
                Model = table.Column<string>(type: "text", nullable: false),
                ReleaseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                EngineType = table.Column<string>(type: "text", nullable: false),
                EngineCapacityInfo = table.Column<string>(type: "text", nullable: false),
                FuelType = table.Column<string>(type: "text", nullable: false),
                Mileage = table.Column<short>(type: "smallint", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Vehicles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Posts",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Price = table.Column<int>(type: "integer", nullable: false),
                IsActive = table.Column<bool>(type: "boolean", nullable: false),
                IsHot = table.Column<bool>(type: "boolean", nullable: false),
                Status = table.Column<string>(type: "text", nullable: false),
                PublishAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                ActiveTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Posts", x => x.Id);
                table.ForeignKey(
                    name: "FK_Posts_Vehicles_VehicleId",
                    column: x => x.VehicleId,
                    principalTable: "Vehicles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Posts_VehicleId",
            table: "Posts",
            column: "VehicleId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Posts");

        migrationBuilder.DropTable(
            name: "Vehicles");
    }
}
