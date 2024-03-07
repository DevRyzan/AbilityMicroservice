using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;


[Route("api/[controller]")]
[ApiController]
public class AbilityActivationTypeController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityActivationTypeDto createAbilityActivationTypeDto)
    {
        CreateAbilityActivationTypeRequest request = new()
        {
            CreateAbilityActivationTypeDto = createAbilityActivationTypeDto
        };
        CreateAbilityActivationTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityActivationTypeDto changeStatusAbilityActivationTypeDto)
    {
        ChangeStatusAbilityActivationTypeRequest request = new()
        {
            ChangeStatusAbilityActivationTypeDto = changeStatusAbilityActivationTypeDto
        };
        ChangeStatusAbilityActivationTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityActivationTypeDto deleteAbilityActivationTypeDto)
    {
        DeleteAbilityActivationTypeRequest request = new()
        {
            DeleteAbilityActivationTypeDto = deleteAbilityActivationTypeDto
        };

        DeleteAbilityActivationTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityActivationTypeDto undoDeleteAbilityActivationTypeDto)
    {
        UndoDeleteAbilityActivationTypeRequest request = new()
        {
            UndoDeleteAbilityActivationTypeDto = undoDeleteAbilityActivationTypeDto
        };
        UndoDeleteAbilityActivationTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityActivationTypeDto updateAbilityActivationTypeDto)
    {
        UpdateAbilityActivationTypeRequest request = new()
        {
            UpdateAbilityActivationTypeDto = updateAbilityActivationTypeDto
        };
        UpdateAbilityActivationTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityActivationTypeDto removeAbilityActivationTypeDto)
    {
        RemoveAbilityActivationTypeRequest request = new()
        {
            RemoveAbilityActivationTypeDto = removeAbilityActivationTypeDto
        };
        RemoveAbilityActivationTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityActivationTypeDto getByIdAbilityActivationTypeDto)
    {
        GetByIdAbilityActivationTypeRequest request = new()
        {
            GetByIdAbilityActivationTypeDto = getByIdAbilityActivationTypeDto
        };
        GetByIdAbilityActivationTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityActivationTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityActivationTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityActivationTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityActivationTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
