using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clinic.Infrastructure.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    WhatsAppNumber = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<int>(type: "int", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<int>(type: "int", maxLength: 14, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodType = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    workShift = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    appointmentType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvailableLabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LabTechnicianId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableLabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableLabTests_AspNetUsers_LabTechnicianId",
                        column: x => x.LabTechnicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PharmacistId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_AspNetUsers_PharmacistId",
                        column: x => x.PharmacistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PharmacistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LabTechnicianId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceptionistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_LabTechnicianId",
                        column: x => x.LabTechnicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_PharmacistId",
                        column: x => x.PharmacistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PharmacistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LabTechnicianId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingDays_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkingDays_AspNetUsers_LabTechnicianId",
                        column: x => x.LabTechnicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkingDays_AspNetUsers_PharmacistId",
                        column: x => x.PharmacistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosisText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VisitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    AvailableLabTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTests_AvailableLabTests_AvailableLabTestId",
                        column: x => x.AvailableLabTestId,
                        principalTable: "AvailableLabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabTests_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrescriptionStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VisitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentMedicines_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01961d25-b4da-7184-a2a8-765486bd4857", "EAE00686-2608-4516-AD1B-F96CD87C475E", new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(681), false, "Doctor", "DOCTOR" },
                    { "01961d25-b4da-71e9-a488-1b8db232e984", "1420D50C-F54D-4503-88E8-A2EFA3BD7137", new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(3356), false, "LabTechnician", "LABTECHNICIAN" },
                    { "01961d25-b4da-72bb-a3a9-7e102ec2be31", "CC350D3E-101D-4AA1-B2C9-5D92D13FD38E", new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(3370), false, "Receptionist", "RECEPTIONIST" },
                    { "01961d25-b4da-75a5-a1f4-a7aa10e421ed", "386C6E14-D0FD-40FF-80D0-74B419360EF0", new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(3320), false, "Pharmacist", "PHARMACIST" },
                    { "01961d25-b4da-9999-a1b2-123456789abc", "A3C5D9C2-7F54-4A2C-8456-9E6C7E8B1E2A", new DateTime(2025, 5, 22, 0, 7, 49, 928, DateTimeKind.Utc).AddTicks(3379), false, "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "CreatedAt", "Degree", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "Specialization", "TwoFactorEnabled", "UserName", "WhatsAppNumber" },
                values: new object[] { "0195d439-9ca1-7873-9c14-a4bc1c201593", 0, "", "0195d43b-a808-757b-9c3e-bf90c6091133", new DateTime(2025, 5, 22, 0, 7, 49, 912, DateTimeKind.Utc).AddTicks(6955), 1, "Doctor", "Weso430@gmail.com", true, "Weso Admin", 0, false, false, null, "WESO430@GMAIL.COM", "WESO430@GMAIL.COM", "AQAAAAIAAYagAAAAEEXd4PRu3eBCN73lCYta1EGJX9E+rjszNkChDH5O57oTWvjQtKL+siiMcoeCUaUjGg==", "01032500077", false, null, "0195d43be3f271878cc37be7dfc34361", "General", false, "Weso430@gmail.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "WhatsAppNumber" },
                values: new object[,]
                {
                    { "0195d439-9ca1-7873-9c14-a4bc1c202222", 0, "0195d43bpharma-conc", new DateTime(2025, 5, 22, 0, 7, 49, 927, DateTimeKind.Utc).AddTicks(7496), "Pharmacist", "pharmacist@clinic.com", true, "Pharma User", 0, false, false, null, "PHARMACIST@CLINIC.COM", "PHARMACIST@CLINIC.COM", "AQAAAAIAAYagAAAAEEXd4PRu3eBCN73lCYta1EGJX9E+rjszNkChDH5O57oTWvjQtKL+siiMcoeCUaUjGg==", "01000000001", false, null, "0195d43bpharma-sec", false, "pharmacist@clinic.com", null },
                    { "0195d439-9ca1-7873-9c14-a4bc1c203333", 0, "0195d43blab-conc", new DateTime(2025, 5, 22, 0, 7, 49, 927, DateTimeKind.Utc).AddTicks(8489), "LabTechnician", "lab@clinic.com", true, "Lab User", 0, false, false, null, "LAB@CLINIC.COM", "LAB@CLINIC.COM", "AQAAAAIAAYagAAAAEEXd4PRu3eBCN73lCYta1EGJX9E+rjszNkChDH5O57oTWvjQtKL+siiMcoeCUaUjGg==", "01000000002", false, null, "0195d43blab-sec", false, "lab@clinic.com", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "WhatsAppNumber", "workShift" },
                values: new object[] { "0195d439-9ca1-7873-9c14-a4bc1c204444", 0, "0195d43brecep-conc", new DateTime(2025, 5, 22, 0, 7, 49, 927, DateTimeKind.Utc).AddTicks(9400), "Receptionist", "receptionist@clinic.com", true, "Reception User", 0, false, false, null, "RECEPTIONIST@CLINIC.COM", "RECEPTIONIST@CLINIC.COM", "AQAAAAIAAYagAAAAEEXd4PRu3eBCN73lCYta1EGJX9E+rjszNkChDH5O57oTWvjQtKL+siiMcoeCUaUjGg==", "01000000003", false, null, "0195d43brecep-sec", false, "receptionist@clinic.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "01961d25-b4da-7184-a2a8-765486bd4857", "0195d439-9ca1-7873-9c14-a4bc1c201593" },
                    { "01961d25-b4da-75a5-a1f4-a7aa10e421ed", "0195d439-9ca1-7873-9c14-a4bc1c202222" },
                    { "01961d25-b4da-71e9-a488-1b8db232e984", "0195d439-9ca1-7873-9c14-a4bc1c203333" },
                    { "01961d25-b4da-72bb-a3a9-7e102ec2be31", "0195d439-9ca1-7873-9c14-a4bc1c204444" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableLabTests_LabTechnicianId",
                table: "AvailableLabTests",
                column: "LabTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_VisitId",
                table: "Diagnoses",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_AvailableLabTestId",
                table: "LabTests",
                column: "AvailableLabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_VisitId",
                table: "LabTests",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_PharmacistId",
                table: "Medicines",
                column: "PharmacistId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMedicines_MedicineId",
                table: "TreatmentMedicines",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMedicines_TreatmentId",
                table: "TreatmentMedicines",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_VisitId",
                table: "Treatments",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_DoctorId",
                table: "UserNotifications",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_LabTechnicianId",
                table: "UserNotifications",
                column: "LabTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_PatientId",
                table: "UserNotifications",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_PharmacistId",
                table: "UserNotifications",
                column: "PharmacistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_ReceptionistId",
                table: "UserNotifications",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_AppointmentId",
                table: "Visits",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_DoctorId",
                table: "WorkingDays",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_LabTechnicianId",
                table: "WorkingDays",
                column: "LabTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_PharmacistId",
                table: "WorkingDays",
                column: "PharmacistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "TreatmentMedicines");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "WorkingDays");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AvailableLabTests");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
