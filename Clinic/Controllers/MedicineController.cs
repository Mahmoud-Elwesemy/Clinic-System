using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Infrastructure.Presistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MedicineController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;
    //---------------------------------------------------------------------------------

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetAllMedicines()
    {
        var medicines = await _serviceManager.MedicineService.GetMedicinesAsync();
        return Ok(medicines);
    }

    [HttpGet("GetMedicineById")]
    public async Task<ActionResult<MedicineDTO>> GetMedicineById(int id)
    {
        var medicine = await _serviceManager.MedicineService.GetMedicineByIdAsync(id);
        if(medicine == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        return Ok(medicine);
    }

    [HttpGet("GetAllSoftDeletMedicen")]
    public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetAllSoftDeletMedicen()
    {
        var medicines = await _serviceManager.MedicineService.GetDeletedOnlyAsync();
        return Ok(medicines);
    }

    [HttpGet("GetAllMedicinesIncludingDeleted")]
    public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetAllMedicinesIncludingDeleted()
    {
        var medicines = await _serviceManager.MedicineService.GetAllIncludingDeletedAsync();
        return Ok(medicines);
    }

    [HttpPost("AddMedicine")]
    public async Task<ActionResult> AddMedicine([FromBody] AddMedicineDTO medicine)
    {
        if(medicine == null)
        {
            return BadRequest(new ResponseAPI( StatusCodes.Status400BadRequest,"Medicine cannot be null"));
        }
        await _serviceManager.MedicineService.AddMedicineAsync(medicine);
        return Ok(new ResponseAPI(StatusCodes.Status201Created));
    }

    [HttpPut("UpdateMedicine")]
    public async Task<ActionResult> UpdateMedicine([FromBody] UpdateMedicineDTO medicine)
    {
        if(medicine == null)
        {
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"Medicine cannot be null"));
        }
        await _serviceManager.MedicineService.UpdateMedicineAsync(medicine);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }

    [HttpDelete("HardDeleteMedicine")]
    public async Task<ActionResult> HardDeleteMedicine(int id)
    {
        var medicine = await _serviceManager.MedicineService.GetMedicineByIdAsync(id);
        if(medicine == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        await _serviceManager.MedicineService.HardDeleteMedicineAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    [HttpDelete("SoftDeleteMedicine")]
    public async Task<ActionResult> SoftDeleteMedicine(int id)
    {
        var medicine = await _serviceManager.MedicineService.GetMedicineByIdAsync(id);
        if(medicine == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        await _serviceManager.MedicineService.SoftDeleteMedicineAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    [HttpPut("RestoreMedicine")]
    public async Task<ActionResult> RestoreMedicine(int id)
    {
        var medicine = await _serviceManager.MedicineService.GetMedicineByIdAsync(id);
        if(medicine == null)
        {
            return NotFound(new ResponseAPI(StatusCodes.Status404NotFound));
        }
        await _serviceManager.MedicineService.RestoreMedicineAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }

}
