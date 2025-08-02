using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient_Vital_Signs_Monitoring.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCreatedAtFromVitalSigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VitalSigns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "VitalSigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
