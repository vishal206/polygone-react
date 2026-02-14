using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class AiController(IAnimationService animationService) : ControllerBase
{
    private readonly IAnimationService _animationService = animationService;

    [HttpGet("demo-code")]
    public async Task<IActionResult> GetDemoCode()
    {
        var animation = AnimationService.GetDemoAnimation();
        return Ok(animation);
    }

    [HttpPost("start-animation")]
    public async Task<IActionResult> StartConversation(Conversation conversation)
    {
        var animation = await _animationService.CreateNewAnimation(conversation.UserDescription);
        return Ok(animation);
    }

}
