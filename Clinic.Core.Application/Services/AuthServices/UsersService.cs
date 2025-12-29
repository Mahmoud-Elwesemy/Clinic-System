using AutoMapper;
using Clinic.Core.Application.Abstraction.Auth;
using Clinic.Core.Application.Abstraction.Auth.Model;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities.Users;
using Clinic.Infrastructure.Presistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Core.Application.Services.AuthServices;
internal class UsersService(UserManager<ApplicationUser> userManager,IJWTProvider jWTProvider,IMapper mapper,ApplicationContext context):IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJWTProvider _jWTProvider = jWTProvider;
    private readonly IMapper _mapper = mapper;
    private readonly ApplicationContext _context = context;
    //-------------------------------------------------------------------------------------------------------
    public async Task<string> RegisterPatientAsync(RegisterPatientDTO DTO,CancellationToken cancellationToken = default)
    {
        if(await _userManager.Users.AnyAsync(u => u.Email == DTO.Email))
            return "Another user with the same Email is already exist";
        if(await _userManager.Users.AnyAsync(u => u.PhoneNumber == DTO.PhoneNumber))
            return "Another user with the same PhoneNumber is already exist";
        var user = _mapper.Map<Patient>(DTO);
        var result = await _userManager.CreateAsync(user,DTO.Password);
        if(!result.Succeeded)
            return string.Join(",",result.Errors.Select(e => e.Description));
        await _userManager.AddToRoleAsync(user,DTO.RoleName);
        return string.Empty;
    }
    //-------------------------------------------------------------------------------------------------------
    public async Task<LoginResponseDTO> LoginAsync(LoginDTO DTO,CancellationToken cancellationToken = default)
    {
        if(await _userManager.FindByEmailAsync(DTO.Email) is not { } user)
            return null;
        if(!await _userManager.CheckPasswordAsync(user,DTO.Password))
            return null;
        var userRoles = await _userManager.GetRolesAsync(user);
        var userPermissions = await _context.Roles
           .Join(_context.RoleClaims,
               role => role.Id,
               roleClaim => roleClaim.RoleId,
               (role,roleClaim) => new
               {
                   role,
                   roleClaim
               })
               .Where(r => userRoles.Contains(r.role.Name))
                    .Select(r => r.roleClaim.ClaimValue)
                    .Distinct()
                    .ToListAsync(cancellationToken);
        var (token, expiresIn) = _jWTProvider.GenerateJwtToken(user,userRoles,userPermissions);
        return new LoginResponseDTO
        (
            user.Id,
            user.Email!,
            user.FullName,
            token,
            expiresIn
        );
    }
    //-------------------------------------------------------------------------------------------------------
    public async Task<AccountProfileDTO?> GetAccountProfileAsync(string userId,CancellationToken cancellationToken = default)
    {
        //var accountDetails = await _userManager.Users.FirstAsync(u => u.Id == userId);
        //return _mapper.Map<AccountProfileDTO>(accountDetails);
        var accountDetails = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId,cancellationToken);
        if(accountDetails == null)
            return null;

        return _mapper.Map<AccountProfileDTO>(accountDetails);
    }
    //------------------------------------------------------------------------------------------
}
