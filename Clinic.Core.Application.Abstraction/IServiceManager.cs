using Clinic.Core.Application.Abstraction.Appointment;
using Clinic.Core.Application.Abstraction.Auth;
using Clinic.Core.Application.Abstraction.AvailableLabTest;
using Clinic.Core.Application.Abstraction.Diagnosis;
using Clinic.Core.Application.Abstraction.LabTest;
using Clinic.Core.Application.Abstraction.Medicine;
using Clinic.Core.Application.Abstraction.Visit;
using Clinic.Core.Application.Abstraction.WorkingDay;

namespace Clinic.Core.Application.Abstraction;
public interface IServiceManager
{
    //  Define all the services that the service manager will provide
    public IJWTProvider JWTProvider { get; }
    public IRoleService RoleService { get; }
    public IUserService UserService { get; }
    public IMedicineService MedicineService { get; }
    public IAppointmentService AppointmentService { get; }
    public IAvailableLabTestService availableLabTestService { get; }
    public IWorkingDayService WorkingDayService { get; }
    public IVisitService VisitService { get; }
    public IDiagnosisService DiagnosisService { get; }
    public ILabTestService LabTestService { get; }
}
