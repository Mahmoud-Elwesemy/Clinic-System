using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Infrastructure.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixWorkingDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_AspNetUsers_DoctorId",
                table: "WorkingDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_AspNetUsers_LabTechnicianId",
                table: "WorkingDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_AspNetUsers_PharmacistId",
                table: "WorkingDays");

            migrationBuilder.AlterColumn<string>(
                name: "PharmacistId",
                table: "WorkingDays",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LabTechnicianId",
                table: "WorkingDays",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "WorkingDays",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-7184-a2a8-765486bd4857",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 18, 8, 18, 544, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-71e9-a488-1b8db232e984",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 18, 8, 18, 544, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-72bb-a3a9-7e102ec2be31",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 18, 8, 18, 544, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-75a5-a1f4-a7aa10e421ed",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 18, 8, 18, 544, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-9999-a1b2-123456789abc",
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 18, 8, 18, 544, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c201593",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 18, 8, 18, 529, DateTimeKind.Utc).AddTicks(789), "AQAAAAIAAYagAAAAEM43QmJkxKs66+hBHOfjYFSj/wGY6jR00ZSDdz9+hspCA5Jjn64fUvCcm0TrTcyoCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 18, 8, 18, 543, DateTimeKind.Utc).AddTicks(9117), "AQAAAAIAAYagAAAAEM43QmJkxKs66+hBHOfjYFSj/wGY6jR00ZSDdz9+hspCA5Jjn64fUvCcm0TrTcyoCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 18, 8, 18, 544, DateTimeKind.Utc).AddTicks(66), "AQAAAAIAAYagAAAAEM43QmJkxKs66+hBHOfjYFSj/wGY6jR00ZSDdz9+hspCA5Jjn64fUvCcm0TrTcyoCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 6, 2, 18, 8, 18, 544, DateTimeKind.Utc).AddTicks(956), "AQAAAAIAAYagAAAAEM43QmJkxKs66+hBHOfjYFSj/wGY6jR00ZSDdz9+hspCA5Jjn64fUvCcm0TrTcyoCQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_AspNetUsers_DoctorId",
                table: "WorkingDays",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_AspNetUsers_LabTechnicianId",
                table: "WorkingDays",
                column: "LabTechnicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_AspNetUsers_PharmacistId",
                table: "WorkingDays",
                column: "PharmacistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_AspNetUsers_DoctorId",
                table: "WorkingDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_AspNetUsers_LabTechnicianId",
                table: "WorkingDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_AspNetUsers_PharmacistId",
                table: "WorkingDays");

            migrationBuilder.AlterColumn<string>(
                name: "PharmacistId",
                table: "WorkingDays",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LabTechnicianId",
                table: "WorkingDays",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "WorkingDays",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_AspNetUsers_DoctorId",
                table: "WorkingDays",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_AspNetUsers_LabTechnicianId",
                table: "WorkingDays",
                column: "LabTechnicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_AspNetUsers_PharmacistId",
                table: "WorkingDays",
                column: "PharmacistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
