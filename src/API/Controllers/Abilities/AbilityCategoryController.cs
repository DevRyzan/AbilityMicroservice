using Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCategory.Dto;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityCategoryController : BaseController
{
    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] AbilityCategoryChangeStatusDto abilityCategoryChangeStatusDto)
    {
        ChangeStatusAbilityCategoryCommandRequest request = new()
        {
            AbilityCategoryChangeStatusDto = abilityCategoryChangeStatusDto
        };
        ChangeStatusAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] AbilityCategoryCreateDto abilityCategoryCreateDto)
    {
        CreateAbilityCategoryCommandRequest request = new()
        {
            AbilityCategoryCreateDto = abilityCategoryCreateDto
        };
        CreatedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] AbilityCategoryDeleteDto abilityCategoryDeleteDto)
    {
        DeleteAbilityCategoryCommandRequest request = new()
        {
            AbilityCategoryDeleteDto = abilityCategoryDeleteDto
        };

        DeletedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] AbilityCategoryRemoveDto abilityCategoryRemoveDto)
    {
        RemoveAbilityCategoryCommandRequest request = new()
        {
            AbilityCategoryRemoveDto = abilityCategoryRemoveDto
        };
        RemovedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] AbilityCategoryUpdateDto abilityCategoryUpdateDto)
    {
        UpdateAbilityCategoryCommandRequest request = new()
        {
            AbilityCategoryUpdateDto = abilityCategoryUpdateDto
        };
        UpdatedAbilityCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] AbilityCategoryGetByIdDto abilityCategoryGetByIdDto)
    {
        GetByIdAbilityCategoryQueryRequest request = new()
        {
            AbilityCategoryGetByIdDto = abilityCategoryGetByIdDto
        };
        GetByIdAbilityCategoryQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityCategoryQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityCategoryQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityCategoryQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityCategoryQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
