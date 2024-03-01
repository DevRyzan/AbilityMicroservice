using Application.Feature.AbilityFeatures.AbilityTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Update;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers.Abilities;


[Route("api/[controller]")]
[ApiController]
public class AbilityTypeController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityTypeDto createAbilityTypeDto)
    {
        CreateAbilityTypeCommandRequest request = new()
        {
            CreateAbilityTypeDto = createAbilityTypeDto
        };
        CreateAbilityTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityEffectTypeDto updateAbilityTypeDto)
    {
        UpdateAbilityTypeCommandRequest request = new()
        {
            UpdateAbilityTypeDto = updateAbilityTypeDto
        };
        UpdateAbilityTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityEffectTypeDto deleteAbilityTypeDto)
    {
        DeleteAbilityTypeCommandRequest request = new()
        {
            DeleteAbilityTypeDto = deleteAbilityTypeDto
        };

        DeleteAbilityTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityEffectTypeDto undoDeleteAbilityTypeDto)
    {
        UndoDeleteAbilityTypeCommandRequest request = new()
        {
            UndoDeleteAbilityTypeDto = undoDeleteAbilityTypeDto
        };

        UndoDeleteAbilityTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityTypeDto changeStatusAbilityTypeDto)
    {
        ChangeStatusAbilityTypeCommandRequest request = new()
        {
            ChangeStatusAbilityTypeDto = changeStatusAbilityTypeDto
        };
        ChangeStatusAbilityTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityEffectTypeDto removeAbilityTypeDto)
    {
        RemoveAbilityTypeCommandRequest request = new()
        {
            RemoveAbilityTypeDto = removeAbilityTypeDto
        };
        RemoveAbilityTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityEffectTypeDto getByIdAbilityTypeDto)
    {
        GetByIdAbilityTypeQueryRequest request = new()
        {
            GetByIdAbilityTypeDto = getByIdAbilityTypeDto
        };
        GetByIdAbilityTypeQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityTypeQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityTypeQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityTypeQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityTypeQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
