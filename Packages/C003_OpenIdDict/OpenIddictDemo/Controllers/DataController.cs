using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenIddictDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get() => Ok("✅ Protected data from Web API");
}
