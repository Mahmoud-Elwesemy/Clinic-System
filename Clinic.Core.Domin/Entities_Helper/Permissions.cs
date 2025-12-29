namespace Clinic.Core.Domin.Entities_Helper;
public static class Permissions
{
    public static string Type { get; } = "permissions";

    // ----------- Appointments ---------------------------------
    public const string ViewAppointments = "Appointments:ViewAppointments";
    public const string AddAppointments = "Appointments:AddAppointments";
    public const string UpdateAppointments = "Appointments:UpdateAppointments";
    public const string DeleteAppointments = "Appointments:DeleteAppointments";

    // ----------- Visits ---------------------------------
    public const string ViewVisits = "Visits:ViewVisits";
    public const string AddVisits = "Visits:AddVisits";
    public const string UpdateVisits = "Visits:UpdateVisits";
    public const string DeleteVisits = "Visits:DeleteVisits";

    // ----------- Patients ---------------------------------
    public const string ViewPatients = "Patients:ViewPatients";
    public const string AddPatients = "Patients:AddPatients";
    public const string UpdatePatients = "Patients:UpdatePatients";
    public const string DeletePatients = "Patients:DeletePatients";

    // ----------- Doctors ---------------------------------
    public const string ViewDoctors = "Doctors:ViewDoctors";
    public const string AddDoctors = "Doctors:AddDoctors";
    public const string UpdateDoctors = "Doctors:UpdateDoctors";
    public const string DeleteDoctors = "Doctors:DeleteDoctors";

    // ----------- Receptionists ---------------------------------
    public const string ViewReceptionists = "Receptionists:ViewReceptionists";
    public const string AddReceptionists = "Receptionists:AddReceptionists";
    public const string UpdateReceptionists = "Receptionists:UpdateReceptionists";
    public const string DeleteReceptionists = "Receptionists:DeleteReceptionists";

    // ----------- Pharmacists ---------------------------------
    public const string ViewPharmacists = "Pharmacists:ViewPharmacists";
    public const string AddPharmacists = "Pharmacists:AddPharmacists";
    public const string UpdatePharmacists = "Pharmacists:UpdatePharmacists";
    public const string DeletePharmacists = "Pharmacists:DeletePharmacists";

    // ----------- LabTechnicians ---------------------------------
    public const string ViewLabTechnicians = "LabTechnicians:ViewLabTechnicians";
    public const string AddLabTechnicians = "LabTechnicians:AddLabTechnicians";
    public const string UpdateLabTechnicians = "LabTechnicians:UpdateLabTechnicians";
    public const string DeleteLabTechnicians = "LabTechnicians:DeleteLabTechnicians";

    // ----------- Diagnoses ---------------------------------
    public const string ViewDiagnoses = "Diagnoses:ViewDiagnoses";
    public const string AddDiagnoses = "Diagnoses:AddDiagnoses";
    public const string UpdateDiagnoses = "Diagnoses:UpdateDiagnoses";
    public const string DeleteDiagnoses = "Diagnoses:DeleteDiagnoses";

    // ----------- Treatments ---------------------------------
    public const string ViewTreatments = "Treatments:ViewTreatments";
    public const string AddTreatments = "Treatments:AddTreatments";
    public const string UpdateTreatments = "Treatments:UpdateTreatments";
    public const string DeleteTreatments = "Treatments:DeleteTreatments";

    // ----------- Medicines ---------------------------------
    public const string ViewMedicines = "Medicines:ViewMedicines";
    public const string AddMedicines = "Medicines:AddMedicines";
    public const string UpdateMedicines = "Medicines:UpdateMedicines";
    public const string DeleteMedicines = "Medicines:DeleteMedicines";

    // ----------- LabTests ---------------------------------
    public const string ViewLabTests = "LabTests:ViewLabTests";
    public const string AddLabTests = "LabTests:AddLabTests";
    public const string UpdateLabTests = "LabTests:UpdateLabTests";
    public const string DeleteLabTests = "LabTests:DeleteLabTests";

    // ----------- WorkingDays ---------------------------------
    public const string ViewWorkingDays = "WorkingDays:ViewWorkingDays";
    public const string AddWorkingDays = "WorkingDays:AddWorkingDays";
    public const string UpdateWorkingDays = "WorkingDays:UpdateWorkingDays";
    public const string DeleteWorkingDays = "WorkingDays:DeleteWorkingDays";

    // ----------- AvailableLabTests ---------------------------------
    public const string ViewAvailableLabTests = "AvailableLabTest:ViewAvailableLabTests";
    public const string AddAvailableLabTests = "AvailableLabTest:AddAvailableLabTests";
    public const string UpdateAvailableLabTests = "AvailableLabTest:UpdateAvailableLabTests";
    public const string DeleteAvailableLabTests = "AvailableLabTest:DeleteAvailableLabTests";

    // ----------- UserNotifications ---------------------------------
    public const string ViewUserNotifications = "UserNotification:ViewUserNotifications";
    public const string DeleteUserNotifications = "UserNotification:DeleteUserNotifications";

    public static IList<string?> GetAllPermissions() =>
       typeof(Permissions).GetFields().Select(f => f.GetValue(f) as string).ToList();
}
