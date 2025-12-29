namespace Clinic.Core.Application.Abstraction.Auth.Model;
public record CreateRoleRequestDTO
(
        string RoleName,
        IEnumerable<string> Permissions
);
