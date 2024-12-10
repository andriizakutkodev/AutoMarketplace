#nullable disable

namespace Infrastructure.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class ExtendPostAndUserEntities : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Posts_Vehicles_VehicleId",
            table: "Posts");

        migrationBuilder.AlterColumn<string>(
            name: "Type",
            table: "Vehicles",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "Model",
            table: "Vehicles",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "Make",
            table: "Vehicles",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "FuelType",
            table: "Vehicles",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "EngineType",
            table: "Vehicles",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "EngineCapacityInfo",
            table: "Vehicles",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "Surname",
            table: "Users",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<byte[]>(
            name: "Salt",
            table: "Users",
            type: "bytea",
            nullable: true,
            oldClrType: typeof(byte[]),
            oldType: "bytea");

        migrationBuilder.AlterColumn<string>(
            name: "PhoneNumber",
            table: "Users",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "Password",
            table: "Users",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Users",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "ImgUrl",
            table: "Users",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "Email",
            table: "Users",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<Guid>(
            name: "VehicleId",
            table: "Posts",
            type: "uuid",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<string>(
            name: "Status",
            table: "Posts",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AddColumn<Guid>(
            name: "OwnerId",
            table: "Posts",
            type: "uuid",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Posts_OwnerId",
            table: "Posts",
            column: "OwnerId");

        migrationBuilder.AddForeignKey(
            name: "FK_Posts_Users_OwnerId",
            table: "Posts",
            column: "OwnerId",
            principalTable: "Users",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Posts_Vehicles_VehicleId",
            table: "Posts",
            column: "VehicleId",
            principalTable: "Vehicles",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Posts_Users_OwnerId",
            table: "Posts");

        migrationBuilder.DropForeignKey(
            name: "FK_Posts_Vehicles_VehicleId",
            table: "Posts");

        migrationBuilder.DropIndex(
            name: "IX_Posts_OwnerId",
            table: "Posts");

        migrationBuilder.DropColumn(
            name: "OwnerId",
            table: "Posts");

        migrationBuilder.AlterColumn<string>(
            name: "Type",
            table: "Vehicles",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Model",
            table: "Vehicles",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Make",
            table: "Vehicles",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "FuelType",
            table: "Vehicles",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "EngineType",
            table: "Vehicles",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "EngineCapacityInfo",
            table: "Vehicles",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Surname",
            table: "Users",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<byte[]>(
            name: "Salt",
            table: "Users",
            type: "bytea",
            nullable: false,
            defaultValue: new byte[0],
            oldClrType: typeof(byte[]),
            oldType: "bytea",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "PhoneNumber",
            table: "Users",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Password",
            table: "Users",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Users",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ImgUrl",
            table: "Users",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Email",
            table: "Users",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<Guid>(
            name: "VehicleId",
            table: "Posts",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Status",
            table: "Posts",
            type: "text",
            nullable: false,
            defaultValue: string.Empty,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Posts_Vehicles_VehicleId",
            table: "Posts",
            column: "VehicleId",
            principalTable: "Vehicles",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
