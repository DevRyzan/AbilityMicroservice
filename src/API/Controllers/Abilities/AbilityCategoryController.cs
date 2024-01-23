using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityCategoryController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityCategoryCommandRequest request)
    {
        CreatedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

}
