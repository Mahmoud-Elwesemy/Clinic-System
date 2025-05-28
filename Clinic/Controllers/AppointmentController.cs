using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.Appointment.Models;
using Clinic.Infrastructure.Presistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AppointmentController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointments()
    {
        var appointments = await _serviceManager.AppointmentService.GetAllAppointmentAsync();
        return Ok(appointments);
    }
    [HttpPost("AddAppointment")]
    public async Task<ActionResult> AddAppointment(AddAppointmentDto appointment)
    {
        if(appointment == null)
        {
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"Appointment cannot be null"));
        }
        await _serviceManager.AppointmentService.AddAppointmentAsync(appointment);
        return Ok(new ResponseAPI(StatusCodes.Status201Created));
    }
}
