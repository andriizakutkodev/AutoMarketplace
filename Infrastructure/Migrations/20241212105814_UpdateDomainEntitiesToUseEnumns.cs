#nullable disable

namespace Infrastructure.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class UpdateDomainEntitiesToUseEnumns : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_VehicleModels_EngineTypes_EngineTypeId",
            table: "VehicleModels");

        migrationBuilder.DropForeignKey(
            name: "FK_VehicleModels_FuelTypes_FuelTypeId",
            table: "VehicleModels");

        migrationBuilder.DropForeignKey(
            name: "FK_VehicleModels_VehicleMakes_MakeId",
            table: "VehicleModels");

        migrationBuilder.DropTable(
            name: "EngineTypes");

        migrationBuilder.DropTable(
            name: "FuelTypes");

        migrationBuilder.DropTable(
            name: "VehicleMakes");

        migrationBuilder.DropTable(
            name: "VehicleTypes");

        migrationBuilder.DropIndex(
            name: "IX_VehicleModels_EngineTypeId",
            table: "VehicleModels");

        migrationBuilder.DropIndex(
            name: "IX_VehicleModels_FuelTypeId",
            table: "VehicleModels");

        migrationBuilder.DropIndex(
            name: "IX_VehicleModels_MakeId",
            table: "VehicleModels");

        migrationBuilder.DropColumn(
            name: "EngineTypeId",
            table: "VehicleModels");

        migrationBuilder.DropColumn(
            name: "FuelTypeId",
            table: "VehicleModels");

        migrationBuilder.DropColumn(
            name: "MakeId",
            table: "VehicleModels");

        migrationBuilder.AddColumn<int>(
            name: "EngineType",
            table: "VehicleModels",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "FuelType",
            table: "VehicleModels",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "Make",
            table: "VehicleModels",
            type: "integer",
            nullable: false,
            defaultValue: 0);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "EngineType",
            table: "VehicleModels");

        migrationBuilder.DropColumn(
            name: "FuelType",
            table: "VehicleModels");

        migrationBuilder.DropColumn(
            name: "Make",
            table: "VehicleModels");

        migrationBuilder.AddColumn<Guid>(
            name: "EngineTypeId",
            table: "VehicleModels",
            type: "uuid",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "FuelTypeId",
            table: "VehicleModels",
            type: "uuid",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "MakeId",
            table: "VehicleModels",
            type: "uuid",
            nullable: true);

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
                TypeId = table.Column<Guid>(type: "uuid", nullable: true),
                Name = table.Column<string>(type: "text", nullable: true),
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

        migrationBuilder.CreateIndex(
            name: "IX_VehicleMakes_TypeId",
            table: "VehicleMakes",
            column: "TypeId");

        migrationBuilder.AddForeignKey(
            name: "FK_VehicleModels_EngineTypes_EngineTypeId",
            table: "VehicleModels",
            column: "EngineTypeId",
            principalTable: "EngineTypes",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_VehicleModels_FuelTypes_FuelTypeId",
            table: "VehicleModels",
            column: "FuelTypeId",
            principalTable: "FuelTypes",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_VehicleModels_VehicleMakes_MakeId",
            table: "VehicleModels",
            column: "MakeId",
            principalTable: "VehicleMakes",
            principalColumn: "Id");
    }
}
