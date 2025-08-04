using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Patient_Vital_Signs_Monitoring.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitialDataToVitalSigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"));

            migrationBuilder.DeleteData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"));

            migrationBuilder.DeleteData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"));

            migrationBuilder.InsertData(
                table: "VitalSigns",
                columns: new[] { "VitalSignsId", "BloodPressure", "HeartRate", "OxygenSaturation", "PatientId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "120/80", 72, 98, new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 7, 30, 22, 47, 23, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "130/85", 80, 97, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 7, 30, 22, 47, 23, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "110/75", 65, 100, new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 7, 30, 22, 47, 23, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.InsertData(
                table: "VitalSigns",
                columns: new[] { "VitalSignsId", "BloodPressure", "HeartRate", "OxygenSaturation", "PatientId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"), "120/80", 72, 98, new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 7, 30, 22, 47, 23, 0, DateTimeKind.Utc) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"), "130/85", 80, 97, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 7, 30, 22, 47, 23, 0, DateTimeKind.Utc) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"), "110/75", 65, 100, new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 7, 30, 22, 47, 23, 0, DateTimeKind.Utc) }
                });
        }
    }
}
