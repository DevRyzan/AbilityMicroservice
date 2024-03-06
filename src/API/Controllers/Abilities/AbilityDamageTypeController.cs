using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityDamageTypeController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityDamageTypeDto createAbilityDamageTypeDto)
    {
        CreateAbilityDamageTypeRequest request = new()
        {
            CreateAbilityDamageTypeDto = createAbilityDamageTypeDto
        };
        CreateAbilityDamageTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityDamageTypeDto updateAbilityDamageTypeDto)
    {
        UpdateAbilityDamageTypeRequest request = new()
        {
            UpdateAbilityDamageTypeDto = updateAbilityDamageTypeDto
        };
        UpdateAbilityDamageTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityDamageTypeDto deleteAbilityDamageTypeDto)
    {
        DeleteAbilityDamageTypeRequest request = new()
        {
            DeleteAbilityDamageTypeDto = deleteAbilityDamageTypeDto
        };

        DeleteAbilityDamageTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityDamageTypeDto undoDeleteAbilityDamageTypeDto)
    {
        UndoDeleteAbilityDamageTypeRequest request = new()
        {
            UndoDeleteAbilityDamageTypeDto = undoDeleteAbilityDamageTypeDto
        };
        UndoDeleteAbilityDamageTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityDamageTypeDto changeStatusAbilityDamageTypeDto)
    {
        ChangeStatusAbilityDamageTypeRequest request = new()
        {
            ChangeStatusAbilityDamageTypeDto = changeStatusAbilityDamageTypeDto
        };
        ChangeStatusAbilityDamageTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityDamageTypeDto removeAbilityDamageTypeDto)
    {
        RemoveAbilityDamageTypeRequest request = new()
        {
            RemoveAbilityDamageTypeDto = removeAbilityDamageTypeDto
        };
        RemoveAbilityDamageTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityDamageTypeDto getByIdAbilityDamageTypeDto)
    {
        GetByIdAbilityDamageTypeRequest request = new()
        {
            GetByIdAbilityDamageTypeDto = getByIdAbilityDamageTypeDto
        };
        GetByIdAbilityDamageTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityDamageTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityDamageTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityDamageTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityDamageTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }




}
