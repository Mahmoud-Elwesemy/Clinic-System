using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.AvailableLabTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AvailableLabTestController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;
    //--------------------------------------------------------------------------------------
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AvailableLabTestDTO>>> GetAllAvailableLabTest()
    {
        var availableLabTests = await _serviceManager.availableLabTestService.GetAllAvailableLabTestAsync();
        return Ok(availableLabTests);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("GetAvailableLabTestById")]
    public async Task<ActionResult<AvailableLabTestDTO>> GetAvailableLabTestById(int id)
    {
        var availableLabTest = await _serviceManager.availableLabTestService.GetAvailableLabTestByIdAsync(id);
        if(availableLabTest == null)
        {
            return NotFound();
        }
        return Ok(availableLabTest);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("GetAllSoftDeletAvailableLabTest")]
    public async Task<ActionResult<IEnumerable<AvailableLabTestDTO>>> GetAllSoftDeletAvailableLabTest()
    {
        var availableLabTests = await _serviceManager.availableLabTestService.GetDeletedOnlyAsync();
        return Ok(availableLabTests);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("GetAllAvailableLabTestIncludingDeleted")]
    public async Task<ActionResult<IEnumerable<AvailableLabTestDTO>>> GetAllAvailableLabTestIncludingDeleted()
    {
        var availableLabTests = await _serviceManager.availableLabTestService.GetAllIncludingDeletedAsync();
        return Ok(availableLabTests);
    }
    //--------------------------------------------------------------------------------------
    [HttpPost("AddAvailableLabTest")]
    public async Task<ActionResult> AddAvailableLabTest([FromBody] AddAvailableLabTestDTO availableLabTest)
    {
        if(availableLabTest == null)
        {
            return BadRequest("Available LabTest cannot be null");
        }
        await _serviceManager.availableLabTestService.AddAvailableLabTestAsync(availableLabTest);
        return Ok();
    }
    //--------------------------------------------------------------------------------------
    [HttpPut("UpdateAvailableLabTest")]
    public async Task<ActionResult> UpdateAvailableLabTest([FromBody] UpdateAvailableLabTestDTO availableLabTest)
    {
        if(availableLabTest == null)
        {
            return BadRequest("Available LabTest cannot be null");
        }
        await _serviceManager.availableLabTestService.UpdateAvailableLabTestAsync(availableLabTest);
        return Ok();
    }
    //--------------------------------------------------------------------------------------
    [HttpDelete("HardDeleteAvailableLabTest")]
    public async Task<ActionResult> HardDeleteAvailableLabTest(int id)
    {
        var availableLabTest = await _serviceManager.availableLabTestService.GetAvailableLabTestByIdAsync(id);
        if(availableLabTest == null)
        {
            return NotFound();
        }
        await _serviceManager.availableLabTestService.HardDeleteAvailableLabTestAsync(id);
        return Ok();
    }
    //--------------------------------------------------------------------------------------
    [HttpDelete("SoftDeleteAvailableLabTest")]
    public async Task<ActionResult> SoftDeleteAvailableLabTest(int id)
    {
        var availableLabTest = await _serviceManager.availableLabTestService.GetAvailableLabTestByIdAsync(id);
        if(availableLabTest == null)
        {
            return NotFound();
        }
        await _serviceManager.availableLabTestService.SoftDeleteAvailableLabTestAsync(id);
        return Ok();
    }
    //--------------------------------------------------------------------------------------
    [HttpPut("RestoreAvailableLabTest")]
    public async Task<ActionResult> RestoreAvailableLabTest(int id)
    {
        var availableLabTest = await _serviceManager.availableLabTestService.GetAvailableLabTestByIdAsync(id);
        if(availableLabTest == null)
        {
            return NotFound();
        }
        await _serviceManager.availableLabTestService.RestoreAvailableLabTestAsync(id);
        return Ok();
    }
    //--------------------------------------------------------------------------------------
}
