using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityEnemyEffectStatController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityEnemyEffectStatDto createAbilityEnemyEffectStatDto)
    {
        CreateAbilityEnemyEffectStatRequest request = new()
        {
            CreateAbilityEnemyEffectStatDto = createAbilityEnemyEffectStatDto
        };
        CreateAbilityEnemyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityEnemyEffectStatDto changeStatusAbilityEnemyEffectStatDto)
    {
        ChangeStatusAbilityEnemyEffectStatRequest request = new()
        {
            ChangeStatusAbilityEnemyEffectStatDto = changeStatusAbilityEnemyEffectStatDto
        };
        ChangeStatusAbilityEnemyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityEnemyEffectStatDto deleteAbilityEnemyEffectStatDto)
    {
        DeleteAbilityEnemyEffectStatRequest request = new()
        {
            DeleteAbilityEnemyEffectStatDto = deleteAbilityEnemyEffectStatDto
        };
        DeleteAbilityEnemyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityEnemyEffectStatDto undoDeleteAbilityEnemyEffectStatDto)
    {
        UndoDeleteAbilityEnemyEffectStatRequest request = new()
        {
            UndoDeleteAbilityEnemyEffectStatDto = undoDeleteAbilityEnemyEffectStatDto
        };
        UndoDeleteAbilityEnemyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityEnemyEffectStatDto updateAbilityEnemyEffectStatDto)
    {
        UpdateAbilityEnemyEffectStatRequest request = new()
        {
            UpdateAbilityEnemyEffectStatDto = updateAbilityEnemyEffectStatDto
        };
        UpdateAbilityEnemyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityEnemyEffectStatDto removeAbilityEnemyEffectStatDto)
    {
        RemoveAbilityEnemyEffectStatRequest request = new()
        {
            RemoveAbilityEnemyEffectStatDto = removeAbilityEnemyEffectStatDto
        };
        RemoveAbilityEnemyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityEnemyEffectStatDto getByIdAbilityEnemyEffectStatDto)
    {
        GetByIdAbilityEnemyEffectStatRequest request = new()
        {
            GetByIdAbilityEnemyEffectStatDto = getByIdAbilityEnemyEffectStatDto
        };
        GetByIdAbilityEnemyEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityEnemyEffectStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityEnemyEffectStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityEnemyEffectStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityEnemyEffectStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
