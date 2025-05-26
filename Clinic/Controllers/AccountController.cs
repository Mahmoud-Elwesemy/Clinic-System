using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application.Abstraction.Auth;
using Clinic.Core.Application.Abstraction.Auth.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController(IServiceManager serviceManager):ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;    
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody]LoginDTO LoginRequest,CancellationToken cancellationToken)
    {
        var response = await _serviceManager.UserService.LoginAsync(LoginRequest,cancellationToken);
        if(response == null)
        {
            return Unauthorized("Invalid email or password.");
        }
        return Ok(response);
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register([FromBody] RegisterPatientDTO  registerRequest,CancellationToken cancellationToken)
    {
        var response = await _serviceManager.UserService.RegisterPatientAsync(registerRequest,cancellationToken);
        if(response == null)
        {
            return BadRequest("Registration failed.");
        }
        return Ok(response);
    }

}
