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
    //---------------------------------------------------------------------------------

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointments()
    {
        var appointments = await _serviceManager.AppointmentService.GetAllAppointmentAsync();
        return Ok(appointments);
    }

    [HttpGet("GetAppointmentById")]
    public async Task<ActionResult<AppointmentDto>> GetAppointmentById(int id)
    {
        var appointment = await _serviceManager.AppointmentService.GetAppointmentByIdAsync(id);
        if(appointment == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        return Ok(appointment);
    }

    [HttpGet("GetAllSoftDeletAppointment")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllSoftDeletAppointment()
    {
        var appointments = await _serviceManager.AppointmentService.GetDeletedOnlyAsync();
        return Ok(appointments);
    }

    [HttpGet("GetAllAppointmentIncludingDeleted")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointmentIncludingDeleted()
    {
        var appointments = await _serviceManager.AppointmentService.GetAllIncludingDeletedAsync();
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

    [HttpPut("UpdateAppointment")]
    public async Task<ActionResult> UpdateAppointment(UpdateAppointmentDto appointment)
    {
        if(appointment == null)
        {
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"Appointment cannot be null"));
        }
        await _serviceManager.AppointmentService.UpdateAppointmentAsync(appointment);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }

    [HttpDelete("HardDeleteAppointment/{id}")]
    public async Task<ActionResult> HardDeleteAppointment(int id)
    {
        await _serviceManager.AppointmentService.HardDeleteAppointmentAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }

    [HttpDelete("SoftDeleteAppointment/{id}")]
    public async Task<ActionResult> SoftDeleteAppointment(int id)
    {
        await _serviceManager.AppointmentService.SoftDeleteAppointmentAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }

    [HttpPost("RestoreAppointment")]
    public async Task<ActionResult> RestoreAppointment(int id)
    {
        var appointment = await _serviceManager.AppointmentService.GetAppointmentByIdAsync(id);
        if(appointment == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        await _serviceManager.AppointmentService.RestoreAppointmentAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }


}
