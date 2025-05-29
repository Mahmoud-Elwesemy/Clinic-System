using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities.Users;
using Clinic.Core.Domin.Entities_Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Presistence.Data;
public class ApplicationContext(DbContextOptions<ApplicationContext> options):IdentityDbContext<ApplicationUser,ApplicationRole,string>(options)
{

    #region Data Set
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Pharmacist> Pharmacists { get; set; }
    public DbSet<LabTechnician> LabTechnicians { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Diagnosis> Diagnoses { get; set; }
    public DbSet<LabTest> LabTests { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<TreatmentMedicine> TreatmentMedicines { get; set; }
    public DbSet<AvailableLabTest> AvailableLabTests { get; set; }
    public DbSet<WorkingDay> WorkingDays { get; set; }
    public DbSet<UserNotification> UserNotifications { get; set; }

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLazyLoadingProxies()
            .ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
         builder.Entity<Appointment>()
        .HasOne(a => a.Visit)
        .WithOne(v => v.Appointment)
        .HasForeignKey<Visit>(v => v.AppointmentId);

        #region Seed Data
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        var hashedPassword = passwordHasher.HashPassword(null!,DefaultUser.DoctorPassword);

        // Doctor
        builder.Entity<Doctor>()
             .HasData(new Doctor
             {
                 Id = DefaultUser.DoctorId,
                 FullName = "Weso Admin",
                 UserName = DefaultUser.DoctorEmail,
                 NormalizedUserName = DefaultUser.DoctorEmail.ToUpper(),
                 Email = DefaultUser.DoctorEmail,
                 EmailConfirmed = true,
                 NormalizedEmail = DefaultUser.DoctorEmail.ToUpper(),
                 SecurityStamp = DefaultUser.DoctorSecurityStamp,
                 ConcurrencyStamp = DefaultUser.DoctorConcurrencyStamp,
                 PasswordHash = hashedPassword,
                 Specialization = "General",
                 Degree = MedicalDegree.Bachelor,
                 PhoneNumber = "01032500077"
             });

        // Pharmacist
        builder.Entity<Pharmacist>().HasData(new Pharmacist
        {
            Id = DefaultUser.PharmacistId,
            FullName = "Pharma User",
            UserName = DefaultUser.PharmacistEmail,
            NormalizedUserName = DefaultUser.PharmacistEmail.ToUpper(),
            Email = DefaultUser.PharmacistEmail,
            EmailConfirmed = true,
            NormalizedEmail = DefaultUser.PharmacistEmail.ToUpper(),
            SecurityStamp = DefaultUser.PharmacistSecurityStamp,
            ConcurrencyStamp = DefaultUser.PharmacistConcurrencyStamp,
            PasswordHash = hashedPassword,
            PhoneNumber = "01000000001"
        });

        // Lab Technician
        builder.Entity<LabTechnician>().HasData(new LabTechnician
        {
            Id = DefaultUser.LabTechnicianId,
            FullName = "Lab User",
            UserName = DefaultUser.LabTechnicianEmail,
            NormalizedUserName = DefaultUser.LabTechnicianEmail.ToUpper(),
            Email = DefaultUser.LabTechnicianEmail,
            EmailConfirmed = true,
            NormalizedEmail = DefaultUser.LabTechnicianEmail.ToUpper(),
            SecurityStamp = DefaultUser.LabTechnicianSecurityStamp,
            ConcurrencyStamp = DefaultUser.LabTechnicianConcurrencyStamp,
            PasswordHash = hashedPassword,
            PhoneNumber = "01000000002"
        });

        // Receptionist
        builder.Entity<Receptionist>().HasData(new Receptionist
        {
            Id = DefaultUser.ReceptionistId,
            FullName = "Reception User",
            UserName = DefaultUser.ReceptionistEmail,
            NormalizedUserName = DefaultUser.ReceptionistEmail.ToUpper(),
            Email = DefaultUser.ReceptionistEmail,
            EmailConfirmed = true,
            NormalizedEmail = DefaultUser.ReceptionistEmail.ToUpper(),
            SecurityStamp = DefaultUser.ReceptionistSecurityStamp,
            ConcurrencyStamp = DefaultUser.ReceptionistConcurrencyStamp,
            PasswordHash = hashedPassword,
            PhoneNumber = "01000000003"
        }); 
        #endregion

        #region Create Roles
        // Roles
        builder.Entity<ApplicationRole>()
            .HasData(
                new ApplicationRole
                {
                    Id = DefaultRole.DoctorRoleId,
                    Name = DefaultRole.Doctor,
                    NormalizedName = DefaultRole.Doctor.ToUpper(),
                    ConcurrencyStamp = DefaultRole.DoctorRoleConcurrencyStamp
                },
                new ApplicationRole
                {
                    Id = DefaultRole.PharmacistRoleId,
                    Name = DefaultRole.Pharmacist,
                    NormalizedName = DefaultRole.Pharmacist.ToUpper(),
                    ConcurrencyStamp = DefaultRole.PharmacistRoleConcurrencyStamp
                },
                new ApplicationRole
                {
                    Id = DefaultRole.LabTechnicianRoleId,
                    Name = DefaultRole.LabTechnician,
                    NormalizedName = DefaultRole.LabTechnician.ToUpper(),
                    ConcurrencyStamp = DefaultRole.LabTechnicianRoleConcurrencyStamp
                },
                new ApplicationRole
                {
                    Id = DefaultRole.ReceptionistRoleId,
                    Name = DefaultRole.Receptionist,
                    NormalizedName = DefaultRole.Receptionist.ToUpper(),
                    ConcurrencyStamp = DefaultRole.ReceptionistRoleConcurrencyStamp
                },
                new ApplicationRole
                {
                    Id = DefaultRole.PatientRoleId,
                    Name = DefaultRole.Patient,
                    NormalizedName = DefaultRole.Patient.ToUpper(),
                    ConcurrencyStamp = DefaultRole.PatientRoleConcurrencyStamp
                }

            );
        #endregion

        #region Assign Roles
        // Assign Roles
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = DefaultUser.DoctorId,RoleId = DefaultRole.DoctorRoleId },
            new IdentityUserRole<string> { UserId = DefaultUser.PharmacistId,RoleId = DefaultRole.PharmacistRoleId },
            new IdentityUserRole<string> { UserId = DefaultUser.LabTechnicianId,RoleId = DefaultRole.LabTechnicianRoleId },
            new IdentityUserRole<string> { UserId = DefaultUser.ReceptionistId,RoleId = DefaultRole.ReceptionistRoleId }
        ); 
        #endregion

        #region Assign Permissions
        // Assign Permissions
        string[] ReceptionistPermissions = {
                Permissions.AddAppointments,
                Permissions.ViewAppointments,
                Permissions.UpdateAppointments,
                Permissions.DeleteAppointments,
                Permissions.ViewUserNotifications,
                Permissions.DeleteUserNotifications,
        };
        string[] PharmacistPermissions = {
                Permissions.AddMedicines,
                Permissions.ViewMedicines,
                Permissions.UpdateMedicines,
                Permissions.DeleteMedicines,
                Permissions.ViewTreatments,
                Permissions.ViewUserNotifications,
                Permissions.DeleteUserNotifications,
        };
        string[] LabTechnicianPermissions = {
                Permissions.AddAvailableLabTests,
                Permissions.UpdateAvailableLabTests,
                Permissions.DeleteAvailableLabTests,
                Permissions.ViewAvailableLabTests,
                Permissions.ViewLabTests,
                Permissions.UpdateLabTests,
                Permissions.ViewUserNotifications,
                Permissions.DeleteUserNotifications,
        };
        string[] PatientPermissions = {
                Permissions.ViewAppointments,
                Permissions.AddAppointments,
                Permissions.ViewVisits,
                Permissions.ViewWorkingDays,
                Permissions.ViewLabTests,
                Permissions.ViewTreatments,
                Permissions.ViewDiagnoses,
                Permissions.ViewUserNotifications,
                Permissions.DeleteUserNotifications,
        };


        int claimId = 1;
        var permissions = Permissions.GetAllPermissions();

        var DoctorClaims = permissions
            .Select(permission => new IdentityRoleClaim<string>
            {
                Id = claimId++,
                RoleId = DefaultRole.DoctorRoleId,
                ClaimType = Permissions.Type,
                ClaimValue = permission
            })
            .ToList();

        var ReceptionistClaims = ReceptionistPermissions
            .Select(permission => new IdentityRoleClaim<string>
            {
                Id = claimId++,
                RoleId = DefaultRole.ReceptionistRoleId,
                ClaimType = Permissions.Type,
                ClaimValue = permission
            })
            .ToList();

        var PharmacistClaims = PharmacistPermissions
            .Select(permission => new IdentityRoleClaim<string>
            {
                Id = claimId++,
                RoleId = DefaultRole.PharmacistRoleId,
                ClaimType = Permissions.Type,
                ClaimValue = permission
            })
            .ToList();

        var LabTechnicianClaims = LabTechnicianPermissions
            .Select(permission => new IdentityRoleClaim<string>
            {
                Id = claimId++,
                RoleId = DefaultRole.LabTechnicianRoleId,
                ClaimType = Permissions.Type,
                ClaimValue = permission
            })
            .ToList();

        var PatientClaims = PatientPermissions
            .Select(permission => new IdentityRoleClaim<string>
            {
                Id = claimId++,
                RoleId = DefaultRole.PatientRoleId,
                ClaimType = Permissions.Type,
                ClaimValue = permission
            })
            .ToList();


        var allClaims = DoctorClaims
            .Concat(ReceptionistClaims)
            .Concat(PharmacistClaims)
            .Concat(LabTechnicianClaims)
            .Concat(PatientClaims)
            .ToList();
        builder.Entity<IdentityRoleClaim<string>>().HasData(allClaims); 
        #endregion

        base.OnModelCreating(builder);
    }    

}