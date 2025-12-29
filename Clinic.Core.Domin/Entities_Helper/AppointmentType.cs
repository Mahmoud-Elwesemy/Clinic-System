using System.ComponentModel.DataAnnotations;

namespace Clinic.Core.Domin.Entities_Helper;
public enum AppointmentType
{
    [Display(Name = "كشف عادي")]
    Regular = 0,

    [Display(Name = "كشف مستعجل")]
    Urgent = 1,

    [Display(Name = "إعادة كشف")]
    FollowUp = 2
}
