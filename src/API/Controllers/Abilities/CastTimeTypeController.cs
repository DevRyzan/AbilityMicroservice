using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Create;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;


[Route("api/[controller]")]
[ApiController]
public class CastTimeTypeController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateCastTimeTypeDto createCastTimeTypeDto)
    {
        CreateCastTimeTypeCommandRequest request = new()
        {
            CreateCastTimeTypeDto = createCastTimeTypeDto
        };
        CreateCastTimeTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }




}
