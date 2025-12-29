using Clinic.Infrastructure.Presistence.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("errors/{statusCode}")]
[ApiController]
public class ErrorController:ControllerBase
{
    [HttpGet]
    public IActionResult Error(int statusCode)
    {
        if(statusCode >= 200 && statusCode < 300)
        {
            return NoContent(); 
        }
        var response = statusCode switch
        {
            400 => new ResponseAPI(400,"الطلب غير صحيح."),
            401 => new ResponseAPI(401,"غير مصرح لك بالدخول."),
            403 => new ResponseAPI(403,"ليس لديك صلاحية الوصول."),
            404 => new ResponseAPI(404,"العنصر المطلوب غير موجود."),
            500 => new ResponseAPI(500,"خطأ داخلي في الخادم."),
            _ => new ResponseAPI(statusCode,"حدث خطأ غير متوقع.")
        };

        return new ObjectResult(response) { StatusCode = statusCode };
    }
    //--------------------------------------------------------------------------------------
}
