using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Infrastructure.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-7184-a2a8-765486bd4857",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 45, 38, 671, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-71e9-a488-1b8db232e984",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 45, 38, 671, DateTimeKind.Utc).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-72bb-a3a9-7e102ec2be31",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 45, 38, 671, DateTimeKind.Utc).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-75a5-a1f4-a7aa10e421ed",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 45, 38, 671, DateTimeKind.Utc).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-9999-a1b2-123456789abc",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 45, 38, 671, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c201593",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 1, 45, 38, 655, DateTimeKind.Utc).AddTicks(4659), "AQAAAAIAAYagAAAAEPGoqBn/iSIA9ZmGMU/Gni4LRxCIXYmAa20WODA5kYc2U5G2P+RsnE2s5t+nKvJvxg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 1, 45, 38, 671, DateTimeKind.Utc).AddTicks(1297), "AQAAAAIAAYagAAAAEPGoqBn/iSIA9ZmGMU/Gni4LRxCIXYmAa20WODA5kYc2U5G2P+RsnE2s5t+nKvJvxg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 1, 45, 38, 671, DateTimeKind.Utc).AddTicks(2365), "AQAAAAIAAYagAAAAEPGoqBn/iSIA9ZmGMU/Gni4LRxCIXYmAa20WODA5kYc2U5G2P+RsnE2s5t+nKvJvxg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 1, 45, 38, 671, DateTimeKind.Utc).AddTicks(3316), "AQAAAAIAAYagAAAAEPGoqBn/iSIA9ZmGMU/Gni4LRxCIXYmAa20WODA5kYc2U5G2P+RsnE2s5t+nKvJvxg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId1",
                table: "Appointments",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId1",
                table: "Appointments",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId1",
                table: "Appointments",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-7184-a2a8-765486bd4857",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 11, 19, 733, DateTimeKind.Utc).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-71e9-a488-1b8db232e984",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 11, 19, 733, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-72bb-a3a9-7e102ec2be31",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 11, 19, 733, DateTimeKind.Utc).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-75a5-a1f4-a7aa10e421ed",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 11, 19, 733, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-9999-a1b2-123456789abc",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 1, 11, 19, 733, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c201593",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 1, 11, 19, 717, DateTimeKind.Utc).AddTicks(7137), "AQAAAAIAAYagAAAAEFoGwKFsJy6RLV6HCG8LIoEOEebAT76kvmScLDIpyPF4vnLR7wtofrtLSK4huN7JOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 1, 11, 19, 733, DateTimeKind.Utc).AddTicks(305), "AQAAAAIAAYagAAAAEFoGwKFsJy6RLV6HCG8LIoEOEebAT76kvmScLDIpyPF4vnLR7wtofrtLSK4huN7JOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 1, 11, 19, 733, DateTimeKind.Utc).AddTicks(1265), "AQAAAAIAAYagAAAAEFoGwKFsJy6RLV6HCG8LIoEOEebAT76kvmScLDIpyPF4vnLR7wtofrtLSK4huN7JOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 1, 11, 19, 733, DateTimeKind.Utc).AddTicks(2172), "AQAAAAIAAYagAAAAEFoGwKFsJy6RLV6HCG8LIoEOEebAT76kvmScLDIpyPF4vnLR7wtofrtLSK4huN7JOQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
