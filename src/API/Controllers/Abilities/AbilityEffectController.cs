using Application.Feature.AbilityFeatures.AbilityEffects.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityEffectController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityEffectDto createAbilityEffectDto)
    {
        CreateAbilityEffectRequest request = new()
        {
            CreateAbilityEffectDto = createAbilityEffectDto
        };
        CreateAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityEffectDto updateAbilityEffectDto)
    {
        UpdateAbilityEffectRequest request = new()
        {
            UpdateAbilityEffectDto = updateAbilityEffectDto
        };
        UpdateAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityEffectDto deleteAbilityEffectDto)
    {
        DeleteAbilityEffectRequest request = new()
        {
            DeleteAbilityEffectDto = deleteAbilityEffectDto
        };

        DeleteAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityEffectDto undoDeleteAbilityEffectDto)
    {
        UndoDeleteAbilityEffectRequest request = new()
        {
            UndoDeleteAbilityEffectDto = undoDeleteAbilityEffectDto
        };
        UndoDeleteAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityEffectDto changeStatusAbilityEffectDto)
    {
        ChangeStatusAbilityEffectRequest request = new()
        {
            ChangeStatusAbilityEffectDto = changeStatusAbilityEffectDto
        };
        ChangeStatusAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityEffectDto removeAbilityEffectDto)
    {
        RemoveAbilityEffectRequest request = new()
        {
            RemoveAbilityEffectDto = removeAbilityEffectDto
        };
        RemoveAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityEffectDto getByIdAbilityEffectDto)
    {
        GetByIdAbilityEffectRequest request = new()
        {
            GetByIdAbilityEffectDto = getByIdAbilityEffectDto
        };
        GetByIdAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityEffectRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityEffectResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityEffectRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityEffectResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
