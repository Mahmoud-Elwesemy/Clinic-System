using Clinic.Core.Domin.Entities_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Auth.Model;
public class RegisterPatientDTO
{
   public string Email { get; set; } = string.Empty;
   public string Password { get; set; } = string.Empty;
   public string FullName { get; set; } = string.Empty;
   public string PhoneNumber { get; set; } = string.Empty;

   [JsonIgnore]
   public string RoleName { get; set; } = DefaultRole.Patient;

   public string? WhatsAppNumber { get; set; }
};
