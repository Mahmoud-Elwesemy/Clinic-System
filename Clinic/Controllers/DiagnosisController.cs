using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.Appointment.Models;
using Clinic.Core.Application.Abstraction.Diagnosis.Models;
using Clinic.Infrastructure.Presistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DiagnosisController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;

    //-----------------------------------------------------------------------------
    //[HttpGet("GetAllSoftDeletDiagnosis")]
    //public async Task<ActionResult<IEnumerable<DiagnosisDTO>>> GetAllSoftDeletDiagnosis()
    //{
    //    var appointments = await _serviceManager.DiagnosisService.GetOnlyDeletedDiagnosisAsync();
    //    return Ok(appointments);
    //}
    //-----------------------------------------------------------------------------
    [HttpPost("CreateDiagnosis")]
    public async Task<ActionResult> CreateDiagnosis([FromBody]AddDiagnosisDTO DTO)
    {
        if(DTO == null)
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"Diagnosis cannot be null"));
        await _serviceManager.DiagnosisService.CreateDiagnosisAsync(DTO);
        return Ok(new ResponseAPI(StatusCodes.Status201Created));
    }
    //-----------------------------------------------------------------------------
    [HttpPut("UpdateDiagnosis")]
    public async Task<ActionResult<UpdateDiagnosisDTO>> UpdateDiagnosis([FromBody]UpdateDiagnosisDTO DTO)
    {
        if(DTO == null)
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"Diagnosis cannot be null"));
        await _serviceManager.DiagnosisService.UpdateDiagnosisAsync(DTO);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //-----------------------------------------------------------------------------
    [HttpDelete("HardDeleteDiagnosis")]
    public async Task<ActionResult> HardDeleteDiagnosis(int id)
    {
        await _serviceManager.DiagnosisService.HardDeleteDiagnosisAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //-----------------------------------------------------------------------------
    //[HttpDelete("SoftDeleteDiagnosis")]
    //public async Task<ActionResult> SoftDeleteDiagnosis(int id)
    //{
    //    await _serviceManager.DiagnosisService.SoftDeleteDiagnosisAsync(id);
    //    return Ok(new ResponseAPI(StatusCodes.Status200OK));
    //}
    //-----------------------------------------------------------------------------
    //[HttpPut("RestoreDiagnosis")]
    //public async Task<ActionResult> RestoreDiagnosis(int id)
    //{

    //    await _serviceManager.DiagnosisService.RestoreDiagnosisAsync(id);
    //    return Ok(new ResponseAPI(StatusCodes.Status200OK));
    //}
    //-----------------------------------------------------------------------------

}
