using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities_Helper;
public static class DefaultRole
{
    public static string Doctor = nameof(Doctor);
    public static string DoctorRoleId = "01961d25-b4da-7184-a2a8-765486bd4857";
    public static string DoctorRoleConcurrencyStamp = "EAE00686-2608-4516-AD1B-F96CD87C475E";

    public static string Pharmacist = nameof(Pharmacist);
    public static string PharmacistRoleId = "01961d25-b4da-75a5-a1f4-a7aa10e421ed";
    public static string PharmacistRoleConcurrencyStamp = "386C6E14-D0FD-40FF-80D0-74B419360EF0";

    public static string LabTechnician = nameof(LabTechnician);
    public static string LabTechnicianRoleId = "01961d25-b4da-71e9-a488-1b8db232e984";
    public static string LabTechnicianRoleConcurrencyStamp = "1420D50C-F54D-4503-88E8-A2EFA3BD7137";

    public static string Receptionist = nameof(Receptionist);
    public static string ReceptionistRoleId = "01961d25-b4da-72bb-a3a9-7e102ec2be31";
    public static string ReceptionistRoleConcurrencyStamp = "CC350D3E-101D-4AA1-B2C9-5D92D13FD38E";

    public static string Patient = nameof(Patient);
    public static string PatientRoleId = "01961d25-b4da-9999-a1b2-123456789abc";
    public static string PatientRoleConcurrencyStamp = "A3C5D9C2-7F54-4A2C-8456-9E6C7E8B1E2A";


}
