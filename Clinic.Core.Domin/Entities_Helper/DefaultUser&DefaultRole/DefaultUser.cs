using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities_Helper;
public static class DefaultUser
{
    public static string DoctorId = "0195d439-9ca1-7873-9c14-a4bc1c201593";
    public static string DoctorEmail = "Weso430@gmail.com";
    public static string DoctorPassword = "Weso430@";
    public static string DoctorSecurityStamp = "0195d43be3f271878cc37be7dfc34361";
    public static string DoctorConcurrencyStamp = "0195d43b-a808-757b-9c3e-bf90c6091133";

    public static string PharmacistId = "0195d439-9ca1-7873-9c14-a4bc1c202222";
    public static string PharmacistEmail = "pharmacist@clinic.com";
    public static string PharmacistSecurityStamp = "0195d43bpharma-sec";
    public static string PharmacistConcurrencyStamp = "0195d43bpharma-conc";

    public static string LabTechnicianId = "0195d439-9ca1-7873-9c14-a4bc1c203333";
    public static string LabTechnicianEmail = "lab@clinic.com";
    public static string LabTechnicianSecurityStamp = "0195d43blab-sec";
    public static string LabTechnicianConcurrencyStamp = "0195d43blab-conc";

    public static string ReceptionistId = "0195d439-9ca1-7873-9c14-a4bc1c204444";
    public static string ReceptionistEmail = "receptionist@clinic.com";
    public static string ReceptionistSecurityStamp = "0195d43brecep-sec";
    public static string ReceptionistConcurrencyStamp = "0195d43brecep-conc";
}
