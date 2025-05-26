using Clinic.Core.Application.Abstraction.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Auth;
public interface IUserService
{
    Task<string> RegisterPatientAsync(RegisterPatientDTO dto,CancellationToken cancellationToken = default);
    Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto,CancellationToken cancellationToken = default);
    Task<AccountProfileDTO?> GetAccountProfileAsync(string userId,CancellationToken cancellationToken = default);
}
