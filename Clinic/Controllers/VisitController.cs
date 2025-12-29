using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Core.Application.Abstraction.Visit;
using Clinic.Core.Application.Abstraction.Visit.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Infrastructure.Presistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VisitController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;
    //---------------------------------------------------------------------------------
    [HttpGet("GetAllVisits")]
    public async Task<ActionResult<IEnumerable<VisitDTO>>> GetAllVisits()
    {
        var visits = await _serviceManager.VisitService.GetAllVisitsAsync();
        return Ok(visits);
    }
    //---------------------------------------------------------------------------------
    [HttpGet("GetVisitsForPatient")]
    public async Task<ActionResult<IEnumerable<VisitDTO>>> GetVisitsForPatient(string patientId)
    {
        var visits = await _serviceManager.VisitService.GetPatientVisitsAsync(patientId);
        return Ok(visits);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("GetPatientVisitsIncludingDeleted")]
    public async Task<ActionResult<IEnumerable<VisitDTO>>> GetPatientVisitsIncludingDeleted(string patientId)
    {
        var visits = await _serviceManager.VisitService.GetPatientVisitsIncludingDeletedAsync(patientId);
        return Ok(visits);
    }
    //---------------------------------------------------------------------------------
    [HttpGet("GetVisitById")]
    public async Task<ActionResult<VisitDTO>> GetVisitById(int visitId)
    {
        var visit = await _serviceManager.VisitService.GetVisitByIdAsync(visitId);
        if(visit == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        return Ok(visit);
    }
    //---------------------------------------------------------------------------------
    [HttpPost("CreateVisitForAppointment")]
    public async Task<ActionResult> CreateVisitForAppointment(int appointmentId)
    {
        await _serviceManager.VisitService.CreateVisitForAppointmentAsync(appointmentId);
        return Ok(new ResponseAPI(StatusCodes.Status201Created));
    }
    //---------------------------------------------------------------------------------
    [HttpPut("UpdateVisit")]
    public async Task<ActionResult> UpdateVisit([FromBody] UpdateVisitDTO dto)
    {
        if(dto == null)
        {
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"Visit cannot be null"));
        }
        var updatedVisit = await _serviceManager.VisitService.UpdateVisitAsync(dto);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //---------------------------------------------------------------------------------
    [HttpDelete("SoftDeleteVisit")]
    public async Task<ActionResult> SoftDeleteVisit(int id)
    {
        await _serviceManager.VisitService.SoftDeleteVisitAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //---------------------------------------------------------------------------------
    [HttpDelete("HardDeleteVisit")]
    public async Task<ActionResult> HardDeleteVisit(int id)
    {
        await _serviceManager.VisitService.HardDeleteVisitAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //---------------------------------------------------------------------------------
    [HttpPut("RestoreVisit")]
    public async Task<IActionResult> RestoreVisit(int id)
    {
        await _serviceManager.VisitService.RestoreVisitAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //---------------------------------------------------------------------------------
}
