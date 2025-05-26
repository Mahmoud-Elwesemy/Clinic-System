using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Auth.Model;
public record LoginResponseDTO
(
        string ID,
        string Email,
        string FullName,
        string Token,
        int ExpiresIn
);
