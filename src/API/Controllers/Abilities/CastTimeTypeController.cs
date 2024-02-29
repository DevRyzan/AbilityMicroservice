using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Create;
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
public class CastTimeTypeController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateCastTimeTypeDto createCastTimeTypeDto)
    {
        CreateCastTimeTypeCommandRequest request = new()
        {
            CreateCastTimeTypeDto = createCastTimeTypeDto
        };
        CreateCastTimeTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCastTimeTypeDto updateCastTimeTypeDto)
    {
        UpdateCastTimeTypeCommandRequest request = new()
        {
            UpdateCastTimeTypeDto = updateCastTimeTypeDto
        };
        UpdateCastTimeTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] RemoveCastTimeTypeDto removeCastTimeTypeDto)
    {
        RemoveCastTimeTypeCommandRequest request = new()
        {
            RemoveCastTimeTypeDto = removeCastTimeTypeDto
        };

        RemoveCastTimeTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteCastTimeTypeDto undoDeleteCastTimeTypeDto)
    {
        UndoDeleteCastTimeTypeCommandRequest request = new()
        {
            UndoDeleteCastTimeTypeDto = undoDeleteCastTimeTypeDto
        };

        UndoDeleteCastTimeTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusCastTimeTypeDto changeStatusCastTimeTypeDto)
    {
        ChangeStatusCastTimeTypeCommandRequest request = new()
        {
            ChangeStatusCastTimeTypeDto = changeStatusCastTimeTypeDto
        };
        ChangeStatusCastTimeTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveCastTimeTypeDto removeCastTimeTypeDto)
    {
        RemoveCastTimeTypeCommandRequest request = new()
        {
            RemoveCastTimeTypeDto = removeCastTimeTypeDto
        };
        RemoveCastTimeTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdCastTimeTypeDto getByIdCastTimeTypeDto)
    {
        GetByIdCastTimeTypeQueryRequest request = new()
        {
            GetByIdCastTimeTypeDto = getByIdCastTimeTypeDto
        };
        GetByIdCastTimeTypeQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveCastTimeTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveCastTimeTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveCastTimeTypeRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveCastTimeTypeResponse> result = await Mediator.Send(request);
        return Ok(result);
    }


}
