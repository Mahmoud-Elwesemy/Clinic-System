using Clinic.Core.Application.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProfileController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;

    [HttpGet("")]
    public async Task<ActionResult> GetAccountProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(string.IsNullOrWhiteSpace(userId))
            return Unauthorized("User is not authenticated.");
        var accountProfile = await _serviceManager.UserService.GetAccountProfileAsync(userId!);
        if(accountProfile == null)
            return NotFound("User not found.");
        return Ok(accountProfile);
    }
}
