using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;

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

    [HttpPost("start-conversation")]
    public async Task<IActionResult> StartConversation(Conversation conversation)
    {
        var animation = AnimationService.CreateNewAnimation(conversation.UserDescription);
        return Ok(animation);
    }

}
