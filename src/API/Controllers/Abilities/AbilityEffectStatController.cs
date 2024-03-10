using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityEffectStatController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityEffectStatDto createAbilityEffectStatDto)
    {
        CreateAbilityEffectStatRequest request = new()
        {
            CreateAbilityEffectStatDto = createAbilityEffectStatDto
        };
        CreateAbilityEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityEffectStatDto changeStatusAbilityEffectStatDto)
    {
        ChangeStatusAbilityEffectStatRequest request = new()
        {
            ChangeStatusAbilityEffectStatDto = changeStatusAbilityEffectStatDto
        };
        ChangeStatusAbilityEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityEffectStatDto deleteAbilityEffectStatDto)
    {
        DeleteAbilityEffectStatRequest request = new()
        {
            DeleteAbilityEffectStatDto = deleteAbilityEffectStatDto
        };
        DeleteAbilityEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityEffectStatDto undoDeleteAbilityEffectStatDto)
    {
        UndoDeleteAbilityEffectStatRequest request = new()
        {
            UndoDeleteAbilityEffectStatDto = undoDeleteAbilityEffectStatDto
        };
        UndoDeleteAbilityEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityEffectStatDto updateAbilityEffectStatDto)
    {
        UpdateAbilityEffectStatRequest request = new()
        {
            UpdateAbilityEffectStatDto = updateAbilityEffectStatDto
        };
        UpdateAbilityEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityEffectStatDto removeAbilityEffectStatDto)
    {
        RemoveAbilityEffectStatRequest request = new()
        {
            RemoveAbilityEffectStatDto = removeAbilityEffectStatDto
        };
        RemoveAbilityEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityEffectStatDto getByIdAbilityEffectStatDto)
    {
        GetByIdAbilityEffectStatRequest request = new()
        {
            GetByIdAbilityEffectStatDto = getByIdAbilityEffectStatDto
        };
        GetByIdAbilityEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetByActiveListAbilityEffectStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetByActiveListAbilityEffectStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityEffectStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityEffectStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
