using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clinic.Infrastructure.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRoleClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "UserNotification:ViewUserNotifications", "01961d25-b4da-72bb-a3a9-7e102ec2be31" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "UserNotification:DeleteUserNotifications", "01961d25-b4da-72bb-a3a9-7e102ec2be31" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "ClaimValue",
                value: "Medicines:AddMedicines");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "ClaimValue",
                value: "Medicines:ViewMedicines");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "ClaimValue",
                value: "Medicines:UpdateMedicines");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Medicines:DeleteMedicines", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Treatments:ViewTreatments", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "UserNotification:ViewUserNotifications", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "UserNotification:DeleteUserNotifications", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "ClaimValue",
                value: "AvailableLabTest:AddAvailableLabTests");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 69,
                column: "ClaimValue",
                value: "AvailableLabTest:UpdateAvailableLabTests");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "AvailableLabTest:DeleteAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "AvailableLabTest:ViewAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "LabTests:ViewLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "LabTests:UpdateLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "UserNotification:ViewUserNotifications", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "UserNotification:DeleteUserNotifications", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "ClaimValue",
                value: "Appointments:ViewAppointments");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 77, "permissions", "Appointments:AddAppointments", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 78, "permissions", "Visits:ViewVisits", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 79, "permissions", "WorkingDays:ViewWorkingDays", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 80, "permissions", "LabTests:ViewLabTests", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 81, "permissions", "Treatments:ViewTreatments", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 82, "permissions", "Diagnoses:ViewDiagnoses", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 83, "permissions", "UserNotification:ViewUserNotifications", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 84, "permissions", "UserNotification:DeleteUserNotifications", "01961d25-b4da-9999-a1b2-123456789abc" }
                });

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
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 5, 53, 889, DateTimeKind.Utc).AddTicks(3307), "AQAAAAIAAYagAAAAELWS/29z2ve/7yKmyQVly477zajIVOVEwcMoK2YGF9XAJDsvRLHqLepLcmfZtiQCQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(982), "AQAAAAIAAYagAAAAELWS/29z2ve/7yKmyQVly477zajIVOVEwcMoK2YGF9XAJDsvRLHqLepLcmfZtiQCQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(1969), "AQAAAAIAAYagAAAAELWS/29z2ve/7yKmyQVly477zajIVOVEwcMoK2YGF9XAJDsvRLHqLepLcmfZtiQCQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 5, 53, 904, DateTimeKind.Utc).AddTicks(2864), "AQAAAAIAAYagAAAAELWS/29z2ve/7yKmyQVly477zajIVOVEwcMoK2YGF9XAJDsvRLHqLepLcmfZtiQCQQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Medicines:AddMedicines", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Medicines:ViewMedicines", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "ClaimValue",
                value: "Medicines:UpdateMedicines");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "ClaimValue",
                value: "Medicines:DeleteMedicines");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "ClaimValue",
                value: "Treatments:ViewTreatments");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "AvailableLabTest:AddAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "AvailableLabTest:UpdateAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "AvailableLabTest:DeleteAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "AvailableLabTest:ViewAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "ClaimValue",
                value: "LabTests:ViewLabTests");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 69,
                column: "ClaimValue",
                value: "LabTests:UpdateLabTests");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Appointments:ViewAppointments", "01961d25-b4da-9999-a1b2-123456789abc" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Appointments:AddAppointments", "01961d25-b4da-9999-a1b2-123456789abc" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Visits:ViewVisits", "01961d25-b4da-9999-a1b2-123456789abc" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "WorkingDays:ViewWorkingDays", "01961d25-b4da-9999-a1b2-123456789abc" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "LabTests:ViewLabTests", "01961d25-b4da-9999-a1b2-123456789abc" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Treatments:ViewTreatments", "01961d25-b4da-9999-a1b2-123456789abc" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "ClaimValue",
                value: "Diagnoses:ViewDiagnoses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-7184-a2a8-765486bd4857",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 1, 30, 58, 71, DateTimeKind.Utc).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-71e9-a488-1b8db232e984",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 1, 30, 58, 72, DateTimeKind.Utc).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-72bb-a3a9-7e102ec2be31",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 1, 30, 58, 72, DateTimeKind.Utc).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-75a5-a1f4-a7aa10e421ed",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 1, 30, 58, 72, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-9999-a1b2-123456789abc",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 1, 30, 58, 72, DateTimeKind.Utc).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c201593",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 23, 1, 30, 58, 55, DateTimeKind.Utc).AddTicks(9239), "AQAAAAIAAYagAAAAEEbWGqPWaOVO/pCTYHDHTIrp4q5JF0gY0t9UWP5AcXvrgCy7uYlVhFQzOxGWyKUAgg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 23, 1, 30, 58, 71, DateTimeKind.Utc).AddTicks(4696), "AQAAAAIAAYagAAAAEEbWGqPWaOVO/pCTYHDHTIrp4q5JF0gY0t9UWP5AcXvrgCy7uYlVhFQzOxGWyKUAgg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 23, 1, 30, 58, 71, DateTimeKind.Utc).AddTicks(5691), "AQAAAAIAAYagAAAAEEbWGqPWaOVO/pCTYHDHTIrp4q5JF0gY0t9UWP5AcXvrgCy7uYlVhFQzOxGWyKUAgg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 23, 1, 30, 58, 71, DateTimeKind.Utc).AddTicks(6602), "AQAAAAIAAYagAAAAEEbWGqPWaOVO/pCTYHDHTIrp4q5JF0gY0t9UWP5AcXvrgCy7uYlVhFQzOxGWyKUAgg==" });
        }
    }
}
