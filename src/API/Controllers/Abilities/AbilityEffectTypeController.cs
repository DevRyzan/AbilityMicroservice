using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers.Abilities;


[Route("api/[controller]")]
[ApiController]
public class AbilityEffectTypeController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityEffectTypeDto createAbilityEffectTypeDto)
    {
        CreateAbilityEffectTypeRequest request = new()
        {
            CreateAbilityEffectTypeDto = createAbilityEffectTypeDto
        };
        CreateAbilityEffectTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityEffectTypeDto updateAbilityEffectTypeDto)
    {
        UpdateAbilityEffectTypeRequest request = new()
        {
            UpdateAbilityEffectTypeDto = updateAbilityEffectTypeDto
        };
        UpdateAbilityEffectTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityEffectTypeDto deleteAbilityEffectTypeDto)
    {
        DeleteAbilityEffectTypeRequest request = new()
        {
            DeleteAbilityEffectTypeDto = deleteAbilityEffectTypeDto
        };

        DeleteAbilityEffectTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityEffectTypeDto undoDeleteAbilityEffectTypeDto)
    {
        UndoDeleteAbilityEffectTypeRequest request = new()
        {
            UndoDeleteAbilityEffectTypeDto = undoDeleteAbilityEffectTypeDto
        };
        UndoDeleteAbilityEffectTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityEffectTypeDto changeStatusAbilityEffectTypeDto)
    {
        ChangeStatusAbilityEffectTypeRequest request = new()
        {
            ChangeStatusAbilityEffectTypeDto = changeStatusAbilityEffectTypeDto
        };
        ChangeStatusAbilityEffectTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityEffectTypeDto removeAbilityEffectTypeDto)
    {
        RemoveAbilityEffectTypeRequest request = new()
        {
            RemoveAbilityEffectTypeDto = removeAbilityEffectTypeDto
        };
        RemoveAbilityEffectTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityEffectTypeDto getByIdAbilityEffectTypeDto)
    {
        GetByIdAbilityEffectTypeRequest request = new()
        {
            GetByIdAbilityEffectTypeDto = getByIdAbilityEffectTypeDto
        };
        GetByIdAbilityEffectTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetByActiveListAbilityEffectTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetByActiveListAbilityEffectTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetByInActiveListAbilityEffectTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetByInActiveListAbilityEffectTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }



}
