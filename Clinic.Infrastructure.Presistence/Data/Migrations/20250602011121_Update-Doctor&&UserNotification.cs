using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Infrastructure.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDoctorUserNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_DoctorId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_LabTechnicianId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_PatientId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_PharmacistId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_ReceptionistId",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "TestName",
                table: "LabTests");

            migrationBuilder.AlterColumn<string>(
                name: "ReceptionistId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PharmacistId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LabTechnicianId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "AspNetUsers",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsultationDurationInMinutes",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FollowUpDurationInMinutes",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
                columns: new[] { "ConsultationDurationInMinutes", "CreatedAt", "FollowUpDurationInMinutes", "PasswordHash" },
                values: new object[] { 30, new DateTime(2025, 6, 2, 1, 11, 19, 717, DateTimeKind.Utc).AddTicks(7137), 15, "AQAAAAIAAYagAAAAEFoGwKFsJy6RLV6HCG8LIoEOEebAT76kvmScLDIpyPF4vnLR7wtofrtLSK4huN7JOQ==" });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_DoctorId",
                table: "UserNotifications",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_LabTechnicianId",
                table: "UserNotifications",
                column: "LabTechnicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_PatientId",
                table: "UserNotifications",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_PharmacistId",
                table: "UserNotifications",
                column: "PharmacistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_ReceptionistId",
                table: "UserNotifications",
                column: "ReceptionistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_UserId",
                table: "UserNotifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_DoctorId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_LabTechnicianId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_PatientId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_PharmacistId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_ReceptionistId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_UserId",
                table: "UserNotifications");

            migrationBuilder.DropIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "ConsultationDurationInMinutes",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FollowUpDurationInMinutes",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ReceptionistId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PharmacistId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LabTechnicianId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "UserNotifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestName",
                table: "LabTests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "NationalId",
                table: "AspNetUsers",
                type: "int",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-7184-a2a8-765486bd4857",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 13, 48, 59, 491, DateTimeKind.Utc).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-71e9-a488-1b8db232e984",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 13, 48, 59, 492, DateTimeKind.Utc).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-72bb-a3a9-7e102ec2be31",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 13, 48, 59, 492, DateTimeKind.Utc).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-75a5-a1f4-a7aa10e421ed",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 13, 48, 59, 492, DateTimeKind.Utc).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-9999-a1b2-123456789abc",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 13, 48, 59, 492, DateTimeKind.Utc).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c201593",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 59, 476, DateTimeKind.Utc).AddTicks(7216), "AQAAAAIAAYagAAAAEDT+/Um+bRkHpoMZ7s1PybsriQfS3vJFnY29Il8yhGITsbuGj5EBHHsP/2N76QtV7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 59, 491, DateTimeKind.Utc).AddTicks(4560), "AQAAAAIAAYagAAAAEDT+/Um+bRkHpoMZ7s1PybsriQfS3vJFnY29Il8yhGITsbuGj5EBHHsP/2N76QtV7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 59, 491, DateTimeKind.Utc).AddTicks(5469), "AQAAAAIAAYagAAAAEDT+/Um+bRkHpoMZ7s1PybsriQfS3vJFnY29Il8yhGITsbuGj5EBHHsP/2N76QtV7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 59, 491, DateTimeKind.Utc).AddTicks(6348), "AQAAAAIAAYagAAAAEDT+/Um+bRkHpoMZ7s1PybsriQfS3vJFnY29Il8yhGITsbuGj5EBHHsP/2N76QtV7g==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_DoctorId",
                table: "UserNotifications",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_LabTechnicianId",
                table: "UserNotifications",
                column: "LabTechnicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_PatientId",
                table: "UserNotifications",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_PharmacistId",
                table: "UserNotifications",
                column: "PharmacistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_ReceptionistId",
                table: "UserNotifications",
                column: "ReceptionistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
