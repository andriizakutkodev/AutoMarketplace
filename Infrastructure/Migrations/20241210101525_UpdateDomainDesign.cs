#nullable disable

namespace Infrastructure.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class UpdateDomainDesign : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Posts_Vehicles_VehicleId",
            table: "Posts");

        migrationBuilder.DropTable(
            name: "Vehicles");

        migrationBuilder.AddColumn<short>(
            name: "Mileage",
            table: "Posts",
            type: "smallint",
            nullable: false,
            defaultValue: (short)0);

        migrationBuilder.CreateTable(
            name: "EngineTypes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EngineTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "FuelTypes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FuelTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "VehicleTypes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_VehicleTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "VehicleMakes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: true),
                TypeId = table.Column<Guid>(type: "uuid", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_VehicleMakes", x => x.Id);
                table.ForeignKey(
                    name: "FK_VehicleMakes_VehicleTypes_TypeId",
                    column: x => x.TypeId,
                    principalTable: "VehicleTypes",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "VehicleModels",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: true),
                EngineCapacity = table.Column<int>(type: "integer", nullable: false),
                ReleaseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                MakeId = table.Column<Guid>(type: "uuid", nullable: true),
                EngineTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                FuelTypeId = table.Column<Guid>(type: "uuid", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_VehicleModels", x => x.Id);
                table.ForeignKey(
                    name: "FK_VehicleModels_EngineTypes_EngineTypeId",
                    column: x => x.EngineTypeId,
                    principalTable: "EngineTypes",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_VehicleModels_FuelTypes_FuelTypeId",
                    column: x => x.FuelTypeId,
                    principalTable: "FuelTypes",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_VehicleModels_VehicleMakes_MakeId",
                    column: x => x.MakeId,
                    principalTable: "VehicleMakes",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_VehicleMakes_TypeId",
            table: "VehicleMakes",
            column: "TypeId");

        migrationBuilder.CreateIndex(
            name: "IX_VehicleModels_EngineTypeId",
            table: "VehicleModels",
            column: "EngineTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_VehicleModels_FuelTypeId",
            table: "VehicleModels",
            column: "FuelTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_VehicleModels_MakeId",
            table: "VehicleModels",
            column: "MakeId");

        migrationBuilder.AddForeignKey(
            name: "FK_Posts_VehicleModels_VehicleId",
            table: "Posts",
            column: "VehicleId",
            principalTable: "VehicleModels",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Posts_VehicleModels_VehicleId",
            table: "Posts");

        migrationBuilder.DropTable(
            name: "VehicleModels");

        migrationBuilder.DropTable(
            name: "EngineTypes");

        migrationBuilder.DropTable(
            name: "FuelTypes");

        migrationBuilder.DropTable(
            name: "VehicleMakes");

        migrationBuilder.DropTable(
            name: "VehicleTypes");

        migrationBuilder.DropColumn(
            name: "Mileage",
            table: "Posts");

        migrationBuilder.CreateTable(
            name: "Vehicles",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EngineCapacityInfo = table.Column<string>(type: "text", nullable: true),
                EngineType = table.Column<string>(type: "text", nullable: true),
                FuelType = table.Column<string>(type: "text", nullable: true),
                Make = table.Column<string>(type: "text", nullable: true),
                Mileage = table.Column<short>(type: "smallint", nullable: false),
                Model = table.Column<string>(type: "text", nullable: true),
                ReleaseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Type = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Vehicles", x => x.Id);
            });

        migrationBuilder.AddForeignKey(
            name: "FK_Posts_Vehicles_VehicleId",
            table: "Posts",
            column: "VehicleId",
            principalTable: "Vehicles",
            principalColumn: "Id");
    }
}
