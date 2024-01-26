using Application.Feature.AbilityFeatures.Ability.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityController : BaseController
{

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityCommandRequest request)
    {
        CreateAbilityCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }
}
