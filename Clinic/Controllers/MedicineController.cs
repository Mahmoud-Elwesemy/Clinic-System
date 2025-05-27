using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MedicineController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;

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
            return NotFound();
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
            return BadRequest("Medicine cannot be null");
        }
        await _serviceManager.MedicineService.AddMedicineAsync(medicine);
        return Ok();
    }
    [HttpPut("UpdateMedicine")]
    public async Task<ActionResult> UpdateMedicine([FromBody] UpdateMedicineDTO medicine)
    {
        if(medicine == null)
        {
            return BadRequest("Medicine cannot be null");
        }
        await _serviceManager.MedicineService.UpdateMedicineAsync(medicine);
        return Ok();
    }
    [HttpDelete("HardDeleteMedicine")]
    public async Task<ActionResult> HardDeleteMedicine(int id)
    {
        var medicine = await _serviceManager.MedicineService.GetMedicineByIdAsync(id);
        if(medicine == null)
        {
            return NotFound();
        }
        await _serviceManager.MedicineService.HardDeleteMedicineAsync(id);
        return Ok();
    }
    [HttpDelete("SoftDeleteMedicine")]
    public async Task<ActionResult> SoftDeleteMedicine(int id)
    {
        var medicine = await _serviceManager.MedicineService.GetMedicineByIdAsync(id);
        if(medicine == null)
        {
            return NotFound();
        }
        await _serviceManager.MedicineService.SoftDeleteMedicineAsync(id);
        return Ok();
    }
    [HttpPut("RestoreMedicine")]
    public async Task<ActionResult> RestoreMedicine(int id)
    {
        var medicine = await _serviceManager.MedicineService.GetMedicineByIdAsync(id);
        if(medicine == null)
        {
            return NotFound();
        }
        await _serviceManager.MedicineService.RestoreMedicineAsync(id);
        return Ok();
    }

}
