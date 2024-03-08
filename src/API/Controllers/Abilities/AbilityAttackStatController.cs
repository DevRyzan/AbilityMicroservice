using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;


[Route("api/[controller]")]
[ApiController]
public class AbilityAttackStatController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityAttackStatDto createAbilityAttackStatDto)
    {
        CreateAbilityAttackStatRequest request = new()
        {
            CreateAbilityAttackStatDto = createAbilityAttackStatDto
        };
        CreateAbilityAttackStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityAttackStatDto changeStatusAbilityAttackStatDto)
    {
        ChangeStatusAbilityAttackStatRequest request = new()
        {
            ChangeStatusAbilityAttackStatDto = changeStatusAbilityAttackStatDto
        };
        ChangeStatusAbilityAttackStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityAttackStatDto deleteAbilityAttackStatDto)
    {
        DeleteAbilityAttackStatRequest request = new()
        {
            DeleteAbilityAttackStatDto = deleteAbilityAttackStatDto
        };

        DeleteAbilityAttackStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityAttackStatDto undoDeleteAbilityAttackStatDto)
    {
        UndoDeleteAbilityAttackStatRequest request = new()
        {
            UndoDeleteAbilityAttackStatDto = undoDeleteAbilityAttackStatDto
        };
        UndoDeleteAbilityAttackStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityAttackStatDto updateAbilityAttackStatDto)
    {
        UpdateAbilityAttackStatRequest request = new()
        {
            UpdateAbilityAttackStatDto = updateAbilityAttackStatDto
        };
        UpdateAbilityAttackStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityAttackStatDto removeAbilityAttackStatDto)
    {
        RemoveAbilityAttackStatRequest request = new()
        {
            RemoveAbilityAttackStatDto = removeAbilityAttackStatDto
        };
        RemoveAbilityAttackStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityAttackStatDto getByIdAbilityAttackStatDto)
    {
        GetByIdAbilityAttackStatRequest request = new()
        {
            GetByIdAbilityAttackStatDto = getByIdAbilityAttackStatDto
        };
        GetByIdAbilityAttackStatResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityAttackStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityAttackStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityAttackStatRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityAttackStatResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
