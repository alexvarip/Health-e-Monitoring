using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient_Vital_Signs_Monitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestampToVitalSigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "VitalSigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "VitalSigns");
        }
    }
}
