using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityAllyEffectStatController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityAllyEffectStatDto createAbilityAllyEffectStatDto)
    {
        CreateAbilityAllyEffectStatRequest request = new()
        {
            CreateAbilityAllyEffectStatDto = createAbilityAllyEffectStatDto
        };
        CreateAbilityAllyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityAllyEffectStatDto changeStatusAbilityAllyEffectStatDto)
    {
        ChangeStatusAbilityAllyEffectStatRequest request = new()
        {
            ChangeStatusAbilityAllyEffectStatDto = changeStatusAbilityAllyEffectStatDto
        };
        ChangeStatusAbilityAllyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityAllyEffectStatDto deleteAbilityAllyEffectStatDto)
    {
        DeleteAbilityAllyEffectStatRequest request = new()
        {
            DeleteAbilityAllyEffectStatDto = deleteAbilityAllyEffectStatDto
        };

        DeleteAbilityAllyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityAllyEffectStatDto undoDeleteAbilityAllyEffectStatDto)
    {
        UndoDeleteAbilityAllyEffectStatRequest request = new()
        {
            UndoDeleteAbilityAllyEffectStatDto = undoDeleteAbilityAllyEffectStatDto
        };
        UndoDeleteAbilityAllyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityAllyEffectStatDto updateAbilityAllyEffectStatDto)
    {
        UpdateAbilityAllyEffectStatRequest request = new()
        {
            UpdateAbilityAllyEffectStatDto = updateAbilityAllyEffectStatDto
        };
        UpdateAbilityAllyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityAllyEffectStatDto removeAbilityAllyEffectStatDto)
    {
        RemoveAbilityAllyEffectStatRequest request = new()
        {
            RemoveAbilityAllyEffectStatDto = removeAbilityAllyEffectStatDto
        };
        RemoveAbilityAllyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityAllyEffectStatDto getByIdAbilityAllyEffectStatDto)
    {
        GetByIdAbilityAllyEffectStatRequest request = new()
        {
            GetByIdAbilityAllyEffectStatDto = getByIdAbilityAllyEffectStatDto
        };
        GetByIdAbilityAllyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityAllyEffectStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityAllyEffectStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityAllyEffectStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityAllyEffectStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
