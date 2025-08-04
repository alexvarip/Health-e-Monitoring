using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Patient_Vital_Signs_Monitoring.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContextInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"));

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Age", "Name", "PatientModelPatientId", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 45, "John Doe", null, 101 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 32, "Jane Smith", null, 102 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 67, "Bob Johnson", null, 103 }
                });

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                column: "PatientId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"),
                column: "PatientId",
                value: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"),
                column: "PatientId",
                value: new Guid("00000000-0000-0000-0000-000000000003"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Age", "Name", "PatientModelPatientId", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"), 45, "John Doe", null, 101 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"), 32, "Jane Smith", null, 102 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"), 67, "Bob Johnson", null, 103 }
                });

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                column: "PatientId",
                value: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"));

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"),
                column: "PatientId",
                value: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"));

            migrationBuilder.UpdateData(
                table: "VitalSigns",
                keyColumn: "VitalSignsId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"),
                column: "PatientId",
                value: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"));
        }
    }
}
