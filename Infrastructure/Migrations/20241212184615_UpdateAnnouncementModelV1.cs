#nullable disable

namespace Infrastructure.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class UpdateAnnouncementModelV1 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "VerificationStatus",
            table: "Announcements");

        migrationBuilder.AddColumn<bool>(
            name: "IsVerified",
            table: "Announcements",
            type: "boolean",
            nullable: false,
            defaultValue: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "IsVerified",
            table: "Announcements");

        migrationBuilder.AddColumn<int>(
            name: "VerificationStatus",
            table: "Announcements",
            type: "integer",
            nullable: false,
            defaultValue: 0);
    }
}