using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Infrastructure.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWhatsAppNumperColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
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
                columns: new[] { "CreatedAt", "PasswordHash", "WhatsAppNumber" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 59, 476, DateTimeKind.Utc).AddTicks(7216), "AQAAAAIAAYagAAAAEDT+/Um+bRkHpoMZ7s1PybsriQfS3vJFnY29Il8yhGITsbuGj5EBHHsP/2N76QtV7g==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash", "WhatsAppNumber" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 59, 491, DateTimeKind.Utc).AddTicks(4560), "AQAAAAIAAYagAAAAEDT+/Um+bRkHpoMZ7s1PybsriQfS3vJFnY29Il8yhGITsbuGj5EBHHsP/2N76QtV7g==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash", "WhatsAppNumber" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 59, 491, DateTimeKind.Utc).AddTicks(5469), "AQAAAAIAAYagAAAAEDT+/Um+bRkHpoMZ7s1PybsriQfS3vJFnY29Il8yhGITsbuGj5EBHHsP/2N76QtV7g==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash", "WhatsAppNumber" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 59, 491, DateTimeKind.Utc).AddTicks(6348), "AQAAAAIAAYagAAAAEDT+/Um+bRkHpoMZ7s1PybsriQfS3vJFnY29Il8yhGITsbuGj5EBHHsP/2N76QtV7g==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WhatsAppNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-7184-a2a8-765486bd4857",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-71e9-a488-1b8db232e984",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-72bb-a3a9-7e102ec2be31",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-75a5-a1f4-a7aa10e421ed",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-9999-a1b2-123456789abc",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c201593",
                columns: new[] { "CreatedAt", "PasswordHash", "WhatsAppNumber" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 5, 53, 889, DateTimeKind.Utc).AddTicks(3307), "AQAAAAIAAYagAAAAELWS/29z2ve/7yKmyQVly477zajIVOVEwcMoK2YGF9XAJDsvRLHqLepLcmfZtiQCQQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash", "WhatsAppNumber" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(982), "AQAAAAIAAYagAAAAELWS/29z2ve/7yKmyQVly477zajIVOVEwcMoK2YGF9XAJDsvRLHqLepLcmfZtiQCQQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash", "WhatsAppNumber" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(1969), "AQAAAAIAAYagAAAAELWS/29z2ve/7yKmyQVly477zajIVOVEwcMoK2YGF9XAJDsvRLHqLepLcmfZtiQCQQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash", "WhatsAppNumber" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(2864), "AQAAAAIAAYagAAAAELWS/29z2ve/7yKmyQVly477zajIVOVEwcMoK2YGF9XAJDsvRLHqLepLcmfZtiQCQQ==", null });
        }
    }
}
