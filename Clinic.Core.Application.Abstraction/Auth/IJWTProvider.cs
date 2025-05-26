using Clinic.Core.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Auth;
public interface IJWTProvider
{
    (string token, int expiresIn) GenerateJwtToken(ApplicationUser user,IEnumerable<string> roles,IEnumerable<string> permissions);
}
