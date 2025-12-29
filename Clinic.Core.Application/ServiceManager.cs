using AutoMapper;
using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.Appointment;
using Clinic.Core.Application.Abstraction.Auth;
using Clinic.Core.Application.Abstraction.AvailableLabTest;
using Clinic.Core.Application.Abstraction.Diagnosis;
using Clinic.Core.Application.Abstraction.LabTest;
using Clinic.Core.Application.Abstraction.Medicine;
using Clinic.Core.Application.Abstraction.Visit;
using Clinic.Core.Application.Abstraction.WorkingDay;
using Clinic.Core.Application.LabTestServices;
using Clinic.Core.Application.Services.AppointmentServices;
using Clinic.Core.Application.Services.AuthServices;
using Clinic.Core.Application.Services.AvailableLabTestServices;
using Clinic.Core.Application.Services.DiagnosisServices;
using Clinic.Core.Application.Services.MedicineServices;
using Clinic.Core.Application.Services.VisitServices;
using Clinic.Core.Application.Services.WorkingDayServices;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;
using Clinic.Infrastructure.Presistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Clinic.Core.Application;
public class ServiceManager:IServiceManager
{
    private readonly Lazy<IJWTProvider> _jwtProvider;
    private readonly Lazy<IRoleService> _roleService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IMedicineService> _medicineService;
    private readonly Lazy<IAppointmentService> _appointmentService;
    private readonly Lazy<IAvailableLabTestService> _availableLabTestService;
    private readonly Lazy<IWorkingDayService> _workingDayService;
    private readonly Lazy<IVisitService> _visitService;
    private readonly Lazy<IDiagnosisService> _diagnosisService;
    private readonly Lazy<ILabTestService> _labTestService;
    //------------------------------------------------------------------------------------------
    public ServiceManager
        (
        IUnitOfWork unitOfWork,IMapper mapper,UserManager<ApplicationUser> userManager,
        ApplicationContext Context ,RoleManager<ApplicationRole> roleManager,
        IOptions<JwtSettings> jwtOptions ,IHttpContextAccessor httpContextAccessor
        )
    {
        _jwtProvider = new Lazy<IJWTProvider>(() => new JWTProvider(jwtOptions));
        _roleService = new Lazy<IRoleService>(() => new RoleService(roleManager,Context));
        _userService = new Lazy<IUserService>(() => new UsersService(userManager,_jwtProvider.Value,mapper,Context));
        _medicineService = new Lazy<IMedicineService>(() => new MedicineService(unitOfWork,mapper));
        _appointmentService = new Lazy<IAppointmentService>(() => new AppointmentService(unitOfWork,mapper ,httpContextAccessor));
        _availableLabTestService = new Lazy<IAvailableLabTestService>(() =>new AvailableLabTestService(unitOfWork,mapper));
        _workingDayService = new Lazy<IWorkingDayService>(() => new WorkingDayService(unitOfWork,mapper ,httpContextAccessor));
        _visitService = new Lazy<IVisitService>(() => new VisitService(unitOfWork,mapper));
        _diagnosisService = new Lazy<IDiagnosisService>(() => new DiagnosisService(unitOfWork,mapper));
        _labTestService = new Lazy<ILabTestService>(() => new LabTestService(unitOfWork));
    }
    //--------------------------------------------------------------------------------------------------------
    public IJWTProvider JWTProvider => _jwtProvider.Value;
    public IRoleService RoleService => _roleService.Value;
    public IUserService UserService => _userService.Value;
    public IMedicineService MedicineService => _medicineService.Value;
    public IAppointmentService AppointmentService => _appointmentService.Value;
    public IAvailableLabTestService availableLabTestService => _availableLabTestService.Value;
    public IWorkingDayService WorkingDayService => _workingDayService.Value;
    public IVisitService VisitService => _visitService.Value;
    public IDiagnosisService DiagnosisService => _diagnosisService.Value;

    public ILabTestService LabTestService => _labTestService.Value;
}
