using Clinic.Core.Domin.Entities;

namespace Clinic.Core.Application.Abstraction.Auth;
public interface IJWTProvider
{
    (string token, int expiresIn) GenerateJwtToken(ApplicationUser user,IEnumerable<string> roles,IEnumerable<string> permissions);
}
