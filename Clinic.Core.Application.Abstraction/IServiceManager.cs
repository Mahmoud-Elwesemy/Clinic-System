using Clinic.Core.Application.Abstraction.Auth;
using Clinic.Core.Application.Abstraction.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction;
public interface IServiceManager
{
    //  Define all the services that the service manager will provide
    public IJWTProvider JWTProvider { get; }
    public IRoleService RoleService { get; }
    public IUserService UserService { get; }
    public IMedicineService MedicineService { get; }
}
