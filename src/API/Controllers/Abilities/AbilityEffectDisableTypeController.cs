using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityEffectDisableTypeController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityEffectDisableTypeDto createAbilityEffectDisableTypeDto)
    {
        CreateAbilityEffectDisableTypeRequest request = new()
        {
            CreateAbilityEffectDisableTypeDto = createAbilityEffectDisableTypeDto
        };
        CreateAbilityEffectDisableTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityEffectDisableTypeDto updateAbilityEffectDisableTypeDto)
    {
        UpdateAbilityEffectDisableTypeRequest request = new()
        {
            UpdateAbilityEffectDisableTypeDto = updateAbilityEffectDisableTypeDto
        };
        UpdateAbilityEffectDisableTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityEffectDisableTypeDto deleteAbilityEffectDisableTypeDto)
    {
        DeleteAbilityEffectDisableTypeRequest request = new()
        {
            DeleteAbilityEffectDisableTypeDto = deleteAbilityEffectDisableTypeDto
        };

        DeleteAbilityEffectDisableTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityEffectDisableTypeDto undoDeleteAbilityEffectDisableTypeDto)
    {
        UndoDeleteAbilityEffectDisableTypeRequest request = new()
        {
            UndoDeleteAbilityEffectDisableTypeDto = undoDeleteAbilityEffectDisableTypeDto
        };
        UndoDeleteAbilityEffectDisableTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityEffectDisableTypeDto changeStatusAbilityEffectDisableTypeDto)
    {
        ChangeStatusAbilityEffectDisableTypeRequest request = new()
        {
            ChangeStatusAbilityEffectDisableTypeDto = changeStatusAbilityEffectDisableTypeDto
        };
        ChangeStatusAbilityEffectDisableTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityEffectDisableTypeDto removeAbilityEffectDisableTypeDto)
    {
        RemoveAbilityEffectDisableTypeRequest request = new()
        {
            RemoveAbilityEffectDisableTypeDto = removeAbilityEffectDisableTypeDto
        };
        RemoveAbilityEffectDisableTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityEffectDisableTypeDto getByIdAbilityEffectDisableTypeDto)
    {
        GetByIdAbilityEffectDisableTypeRequest request = new()
        {
            GetByIdAbilityEffectDisableTypeDto = getByIdAbilityEffectDisableTypeDto
        };
        GetByIdAbilityEffectDisableTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityEffectDisableTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityEffectDisableTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityEffectDisableTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityEffectDisableTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
