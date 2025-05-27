using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Presistence.Helper;
public class ApiExceptions:ResponseAPI
{
    public string Details { get; set; }

    public ApiExceptions(int statusCode,string? message = null,string details = null!) : base(statusCode,message)
    {
        Details = details;
    }
}
