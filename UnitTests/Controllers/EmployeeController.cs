using Microsoft.AspNetCore.Mvc;
using UnitTests.Dtos;
using UnitTests.Models;
using UnitTests.Services;

namespace UnitTests.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRegistrationService _service;

    public EmployeeController(IEmployeeRegistrationService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterEmployeeRequest request)
    {
        // Fake logged user (for now)
        var user = new User
        {
            Id = 1,
            Username = "john",
            EmployeeId = request.TargetEmployeeId,
            IsActive = true
        };

        try
        {
            _service.Register(user, request);

            return Ok(new { message = "Registration completed." });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}