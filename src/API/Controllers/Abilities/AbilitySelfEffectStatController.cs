using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilitySelfEffectStatController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilitySelfEffectStatDto createAbilitySelfEffectStatDto)
    {
        CreateAbilitySelfEffectStatRequest request = new()
        {
            CreateAbilitySelfEffectStatDto = createAbilitySelfEffectStatDto
        };
        CreateAbilitySelfEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilitySelfEffectStatDto updateAbilitySelfEffectStatDto)
    {
        UpdateAbilitySelfEffectStatRequest request = new()
        {
            UpdateAbilitySelfEffectStatDto = updateAbilitySelfEffectStatDto
        };
        UpdateAbilitySelfEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilitySelfEffectStatDto deleteAbilitySelfEffectStatDto)
    {
        DeleteAbilitySelfEffectStatRequest request = new()
        {
            DeleteAbilitySelfEffectStatDto = deleteAbilitySelfEffectStatDto
        };

        DeleteAbilitySelfEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilitySelfEffectStatDto undoDeleteAbilitySelfEffectStatDto)
    {
        UndoDeleteAbilitySelfEffectStatRequest request = new()
        {
            UndoDeleteAbilitySelfEffectStatDto = undoDeleteAbilitySelfEffectStatDto
        };
        UndoDeleteAbilitySelfEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilitySelfEffectStatDto changeStatusAbilitySelfEffectStatDto)
    {
        ChangeStatusAbilitySelfEffectStatRequest request = new()
        {
            ChangeStatusAbilitySelfEffectStatDto = changeStatusAbilitySelfEffectStatDto
        };
        ChangeStatusAbilitySelfEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilitySelfEffectStatDto removeAbilitySelfEffectStatDto)
    {
        RemoveAbilitySelfEffectStatRequest request = new()
        {
            RemoveAbilitySelfEffectStatDto = removeAbilitySelfEffectStatDto
        };
        RemoveAbilitySelfEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilitySelfEffectStatDto getByIdAbilitySelfEffectStatDto)
    {
        GetByIdAbilitySelfEffectStatRequest request = new()
        {
            GetByIdAbilitySelfEffectStatDto = getByIdAbilitySelfEffectStatDto
        };
        GetByIdAbilitySelfEffectStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilitySelfEffectStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilitySelfEffectStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilitySelfEffectStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilitySelfEffectStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
