using Clinic.Core.Application.Abstraction.Auth;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Clinic.Core.Application.Services.AuthServices;
internal class JWTProvider:IJWTProvider
{
    private readonly JwtSettings _jwtSettings;
    //------------------------------------------------------------------------------------------
    public JWTProvider(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }
    //------------------------------------------------------------------------------------------
    public (string token, int expiresIn) GenerateJwtToken(ApplicationUser user,IEnumerable<string> roles,IEnumerable<string> permissions)
    {
        Claim[] claims = [
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email!),
                new Claim(JwtRegisteredClaimNames.Name,user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.CreateVersion7().ToString()),
                new Claim(nameof(roles), JsonSerializer.Serialize(roles), JsonClaimValueTypes.JsonArray),
                new Claim(nameof(permissions), JsonSerializer.Serialize(permissions), JsonClaimValueTypes.JsonArray),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            ];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddDays(_jwtSettings.ExpiresInDays);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expiration,
            signingCredentials: creds
        );
        return (new JwtSecurityTokenHandler().WriteToken(token), _jwtSettings.ExpiresInDays * 24 * 60);
    }
    //------------------------------------------------------------------------------------------
}
