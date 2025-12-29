using Clinic.Core.Application.Abstraction.Auth.Model;

namespace Clinic.Core.Application.Abstraction.Auth;
public interface IUserService
{
    Task<string> RegisterPatientAsync(RegisterPatientDTO dto,CancellationToken cancellationToken = default);
    Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto,CancellationToken cancellationToken = default);
    Task<AccountProfileDTO?> GetAccountProfileAsync(string userId,CancellationToken cancellationToken = default);
}
