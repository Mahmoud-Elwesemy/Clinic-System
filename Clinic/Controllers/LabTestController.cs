using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.LabTest.Models;
using Clinic.Infrastructure.Presistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LabTestController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;
    //-------------------------------------------------------------------------------
    [HttpPost("CreateLabTest")]
    public async Task<ActionResult> CreateLabTest(AddLabTestsDTO DTO)
    {
        if(DTO == null)
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"LabTest cannot be null"));
        await _serviceManager.LabTestService.CreateLabTestAsync(DTO);
        return Ok(new ResponseAPI(StatusCodes.Status201Created));
    }
    //-------------------------------------------------------------------------------
    [HttpPut("UpdateLabTest")]
    public async Task<ActionResult<UpdateLabTestsDTO>> UpdateLabTest([FromBody] UpdateLabTestsDTO DTO)
    {
        if(DTO == null)
            return BadRequest(new ResponseAPI(StatusCodes.Status400BadRequest,"LabTest cannot be null"));
        await _serviceManager.LabTestService.UpdateLabTestAsync(DTO);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
    //-------------------------------------------------------------------------------
    [HttpDelete("HardDeleteLabTest")]
    public async Task<ActionResult> HardDeleteLabTest(int id)
    {
        await _serviceManager.LabTestService.HardDeleteLabTestAsync(id);
        return Ok(new ResponseAPI(StatusCodes.Status200OK));
    }
}
