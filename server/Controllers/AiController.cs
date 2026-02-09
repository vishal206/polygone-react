using Microsoft.AspNetCore.Mvc;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class AiController : ControllerBase
{
    [HttpGet("demo-code")]
    public async Task<IActionResult> GetDemoCode()
    {
        var animation = AnimationService.GetDemoAnimation();
        return Ok(animation);
    }
}
