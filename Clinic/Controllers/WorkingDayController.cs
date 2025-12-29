using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.WorkingDay.Models;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Infrastructure.Presistence.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkingDayController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;

    //---------------------------------------------------------------------------------
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<WorkingDayDTO>>> GetAllWorkingDay()
    //{
    //    var WorkingDays = await _serviceManager.WorkingDayService.GetGetAllWorkingDay();
    //    return Ok(WorkingDays);
    //}
    //--------------------------------------------------------------------------------------
    [HttpGet("GetAllWorkingDay")]
    public async Task<ActionResult<IEnumerable<WorkingDayDTO>>> GetAllWorkingDay(WorkingDayType? type = null)
    {
        var WorkingDays = await _serviceManager.WorkingDayService.GetMyWorkingDaysOrByTypeAsync(type);
        return Ok(WorkingDays);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("GetWorkingDayById")]
    public async Task<ActionResult<WorkingDayDTO>> GetWorkingDayById(int id)
    {
        var WorkingDay = await _serviceManager.WorkingDayService.GetWorkingDayByIdAsync(id);
        if(WorkingDay == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        return Ok(WorkingDay);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("GetAllSoftDeletWorkingDay")]
    public async Task<ActionResult<IEnumerable<WorkingDayDTO>>> GetAllSoftDeletWorkingDay()
    {
        var WorkingDays = await _serviceManager.WorkingDayService.GetAllSoftDeletedAsync();
        return Ok(WorkingDays);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("GetAllWorkingDayIncludingDeleted")]
    public async Task<ActionResult<IEnumerable<WorkingDayDTO>>> GetAllWorkingDayIncludingDeleted()
    {
        var WorkingDays = await _serviceManager.WorkingDayService.GetAllIncludingDeletedAsync();
        return Ok(WorkingDays);
    }
    //--------------------------------------------------------------------------------------
    [HttpPost("AddWorkingDay")]
    public async Task<ActionResult> AddWorkingDay(AddWorkingDayDTO DTO)
    {
        if (DTO == null)
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"WorkingDay cannot be null"));
        await _serviceManager.WorkingDayService.AddWorkingDayAsync(DTO);
        return Ok(new ResponseAPI(StatusCodes.Status201Created));
    }
    //--------------------------------------------------------------------------------------
    [HttpPut("UpdateWorkingDay")]
    public async Task<ActionResult> UpdateWorkingDay (UpdateWorkingDayDTO DTO)
    {
        if(DTO == null)
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"WorkingDay cannot be null"));
        await _serviceManager.WorkingDayService.UpdateWorkingDayAsync(DTO);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //--------------------------------------------------------------------------------------
    [HttpDelete("HardDeleteWorkingDay")]
    public async Task<ActionResult> HardDeleteWorkingDay(int id)
    {
        await _serviceManager.WorkingDayService.HardDeleteWorkingDayAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //--------------------------------------------------------------------------------------
    [HttpDelete("SoftDeleteWorkingDay")]
    public async Task<ActionResult> SoftDeleteWorkingDay(int id)
    {
        await _serviceManager.WorkingDayService.SoftDeleteWorkingDayAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //--------------------------------------------------------------------------------------
    [HttpPut("RestoreWorkingDay")]
    public async Task<ActionResult> RestoreWorkingDay(int id)
    {
        var WorkingDay = await _serviceManager.WorkingDayService.GetWorkingDayByIdAsync(id);
        if(WorkingDay == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        await _serviceManager.WorkingDayService.RestoreWorkingDayAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //--------------------------------------------------------------------------------------
}
