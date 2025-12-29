namespace Clinic.Core.Application.Abstraction.Auth.Model;
public record RoleDetailsResponseDTO
(
        string RoleId,
        string RoleName,
        string CreatedAt,
        IEnumerable<string> Permissions
);

