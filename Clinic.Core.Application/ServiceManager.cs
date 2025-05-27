using AutoMapper;
using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.Auth;
using Clinic.Core.Application.Abstraction.Medicine;
using Clinic.Core.Application.Services.AuthServices;
using Clinic.Core.Application.Services.MedicineServices;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;
using Clinic.Infrastructure.Presistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application;
public class ServiceManager:IServiceManager
{
    private readonly Lazy<IJWTProvider> _jwtProvider;
    private readonly Lazy<IRoleService> _roleService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IMedicineService> _medicineService;

    public ServiceManager
        (
        IUnitOfWork unitOfWork,IMapper mapper,UserManager<ApplicationUser> userManager,
        ApplicationContext Context ,RoleManager<ApplicationRole> roleManager,
        IOptions<JwtSettings> jwtOptions
        )
    {
        _jwtProvider = new Lazy<IJWTProvider>(() => new JWTProvider(jwtOptions));
        _roleService = new Lazy<IRoleService>(() => new RoleService(roleManager,Context));
        _userService = new Lazy<IUserService>(() => new UsersService(userManager,_jwtProvider.Value,mapper,Context));
        _medicineService = new Lazy<IMedicineService>(() => new MedicineService(unitOfWork,mapper));

    }

    //--------------------------------------------------------------------------------------------------------

    public IJWTProvider JWTProvider => _jwtProvider.Value;

    public IRoleService RoleService => _roleService.Value;

    public IUserService UserService => _userService.Value;

    public IMedicineService MedicineService => _medicineService.Value;
}
