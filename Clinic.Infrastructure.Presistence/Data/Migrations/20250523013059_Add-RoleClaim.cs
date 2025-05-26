using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clinic.Infrastructure.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "Appointments:ViewAppointments", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 2, "permissions", "Appointments:AddAppointments", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 3, "permissions", "Appointments:UpdateAppointments", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 4, "permissions", "Appointments:DeleteAppointments", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 5, "permissions", "Visits:ViewVisits", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 6, "permissions", "Visits:AddVisits", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 7, "permissions", "Visits:UpdateVisits", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 8, "permissions", "Visits:DeleteVisits", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 9, "permissions", "Patients:ViewPatients", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 10, "permissions", "Patients:AddPatients", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 11, "permissions", "Patients:UpdatePatients", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 12, "permissions", "Patients:DeletePatients", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 13, "permissions", "Doctors:ViewDoctors", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 14, "permissions", "Doctors:AddDoctors", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 15, "permissions", "Doctors:UpdateDoctors", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 16, "permissions", "Doctors:DeleteDoctors", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 17, "permissions", "Receptionists:ViewReceptionists", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 18, "permissions", "Receptionists:AddReceptionists", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 19, "permissions", "Receptionists:UpdateReceptionists", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 20, "permissions", "Receptionists:DeleteReceptionists", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 21, "permissions", "Pharmacists:ViewPharmacists", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 22, "permissions", "Pharmacists:AddPharmacists", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 23, "permissions", "Pharmacists:UpdatePharmacists", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 24, "permissions", "Pharmacists:DeletePharmacists", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 25, "permissions", "LabTechnicians:ViewLabTechnicians", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 26, "permissions", "LabTechnicians:AddLabTechnicians", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 27, "permissions", "LabTechnicians:UpdateLabTechnicians", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 28, "permissions", "LabTechnicians:DeleteLabTechnicians", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 29, "permissions", "Diagnoses:ViewDiagnoses", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 30, "permissions", "Diagnoses:AddDiagnoses", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 31, "permissions", "Diagnoses:UpdateDiagnoses", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 32, "permissions", "Diagnoses:DeleteDiagnoses", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 33, "permissions", "Treatments:ViewTreatments", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 34, "permissions", "Treatments:AddTreatments", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 35, "permissions", "Treatments:UpdateTreatments", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 36, "permissions", "Treatments:DeleteTreatments", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 37, "permissions", "Medicines:ViewMedicines", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 38, "permissions", "Medicines:AddMedicines", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 39, "permissions", "Medicines:UpdateMedicines", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 40, "permissions", "Medicines:DeleteMedicines", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 41, "permissions", "LabTests:ViewLabTests", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 42, "permissions", "LabTests:AddLabTests", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 43, "permissions", "LabTests:UpdateLabTests", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 44, "permissions", "LabTests:DeleteLabTests", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 45, "permissions", "WorkingDays:ViewWorkingDays", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 46, "permissions", "WorkingDays:AddWorkingDays", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 47, "permissions", "WorkingDays:UpdateWorkingDays", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 48, "permissions", "WorkingDays:DeleteWorkingDays", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 49, "permissions", "AvailableLabTest:ViewAvailableLabTests", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 50, "permissions", "AvailableLabTest:AddAvailableLabTests", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 51, "permissions", "AvailableLabTest:UpdateAvailableLabTests", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 52, "permissions", "AvailableLabTest:DeleteAvailableLabTests", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 53, "permissions", "UserNotification:ViewUserNotifications", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 54, "permissions", "UserNotification:DeleteUserNotifications", "01961d25-b4da-7184-a2a8-765486bd4857" },
                    { 55, "permissions", "Appointments:AddAppointments", "01961d25-b4da-72bb-a3a9-7e102ec2be31" },
                    { 56, "permissions", "Appointments:ViewAppointments", "01961d25-b4da-72bb-a3a9-7e102ec2be31" },
                    { 57, "permissions", "Appointments:UpdateAppointments", "01961d25-b4da-72bb-a3a9-7e102ec2be31" },
                    { 58, "permissions", "Appointments:DeleteAppointments", "01961d25-b4da-72bb-a3a9-7e102ec2be31" },
                    { 59, "permissions", "Medicines:AddMedicines", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" },
                    { 60, "permissions", "Medicines:ViewMedicines", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" },
                    { 61, "permissions", "Medicines:UpdateMedicines", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" },
                    { 62, "permissions", "Medicines:DeleteMedicines", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" },
                    { 63, "permissions", "Treatments:ViewTreatments", "01961d25-b4da-75a5-a1f4-a7aa10e421ed" },
                    { 64, "permissions", "AvailableLabTest:AddAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" },
                    { 65, "permissions", "AvailableLabTest:UpdateAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" },
                    { 66, "permissions", "AvailableLabTest:DeleteAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" },
                    { 67, "permissions", "AvailableLabTest:ViewAvailableLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" },
                    { 68, "permissions", "LabTests:ViewLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" },
                    { 69, "permissions", "LabTests:UpdateLabTests", "01961d25-b4da-71e9-a488-1b8db232e984" },
                    { 70, "permissions", "Appointments:ViewAppointments", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 71, "permissions", "Appointments:AddAppointments", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 72, "permissions", "Visits:ViewVisits", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 73, "permissions", "WorkingDays:ViewWorkingDays", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 74, "permissions", "LabTests:ViewLabTests", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 75, "permissions", "Treatments:ViewTreatments", "01961d25-b4da-9999-a1b2-123456789abc" },
                    { 76, "permissions", "Diagnoses:ViewDiagnoses", "01961d25-b4da-9999-a1b2-123456789abc" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-7184-a2a8-765486bd4857",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-71e9-a488-1b8db232e984",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-72bb-a3a9-7e102ec2be31",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-75a5-a1f4-a7aa10e421ed",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01961d25-b4da-9999-a1b2-123456789abc",
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c201593",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 22, 0, 7, 49, 912, DateTimeKind.Utc).AddTicks(6955), "AQAAAAIAAYagAAAAEEXd4PRu3eBCN73lCYta1EGJX9E+rjszNkChDH5O57oTWvjQtKL+siiMcoeCUaUjGg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c202222",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 22, 0, 7, 49, 927, DateTimeKind.Utc).AddTicks(7496), "AQAAAAIAAYagAAAAEEXd4PRu3eBCN73lCYta1EGJX9E+rjszNkChDH5O57oTWvjQtKL+siiMcoeCUaUjGg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c203333",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 22, 0, 7, 49, 927, DateTimeKind.Utc).AddTicks(8489), "AQAAAAIAAYagAAAAEEXd4PRu3eBCN73lCYta1EGJX9E+rjszNkChDH5O57oTWvjQtKL+siiMcoeCUaUjGg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195d439-9ca1-7873-9c14-a4bc1c204444",
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 5, 22, 0, 7, 49, 927, DateTimeKind.Utc).AddTicks(9400), "AQAAAAIAAYagAAAAEEXd4PRu3eBCN73lCYta1EGJX9E+rjszNkChDH5O57oTWvjQtKL+siiMcoeCUaUjGg==" });
        }
    }
}
