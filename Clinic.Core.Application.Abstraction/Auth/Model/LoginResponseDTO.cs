namespace Clinic.Core.Application.Abstraction.Auth.Model;
public record LoginResponseDTO
(
        string ID,
        string Email,
        string FullName,
        string Token,
        int ExpiresIn
);
