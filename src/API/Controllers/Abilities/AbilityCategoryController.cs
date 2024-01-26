using Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityCategoryController : BaseController
{
    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityCategoryCommandRequest request)
    {
        ChangeStatusAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityCategoryCommandRequest request)
    {
        CreatedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> ChangeStatus([FromBody] DeleteAbilityCategoryCommandRequest request)
    {
        DeletedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityCategoryCommandRequest request)
    {
        RemovedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityCategoryCommandRequest request)
    {
        UpdatedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityCategoryQueryRequest request)
    {
        GetByIdAbilityCategoryQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

}
