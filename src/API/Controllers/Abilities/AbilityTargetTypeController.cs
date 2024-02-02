using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityTargetTypeController : BaseController
{
    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityTargetTypeDto  changeStatusAbilityTargetTypeDto)
    {
        ChangeStatusAbilityTargetTypeCommandRequest request = new()
        {
             ChangeStatusAbilityTargetTypeDto = changeStatusAbilityTargetTypeDto
        };
        ChangeStatusAbilityTargetTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityTargetTypeDto  createAbilityTargetTypeDto)
    {
        CreateAbilityTargetTypeCommandRequest request = new()
        {
             CreateAbilityTargetTypeDto = createAbilityTargetTypeDto
        };
        CreateAbilityTargetTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityTargetTypeDto  deleteAbilityTargetTypeDto)
    {
        DeleteAbilityTargetTypeCommandRequest request = new()
        {
             DeleteAbilityTargetTypeDto = deleteAbilityTargetTypeDto
        };

        DeleteAbilityTargetTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityTargetTypeDto  removeAbilityTargetTypeDto)
    {
        RemoveAbilityTargetTypeCommandRequest request = new()
        {
             RemoveAbilityTargetTypeDto = removeAbilityTargetTypeDto
        };
        RemoveAbilityTargetTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityTargetTypeDto  updateAbilityTargetTypeDto)
    {
        UpdateAbilityTargetTypeCommandRequest request = new()
        {
             UpdateAbilityTargetTypeDto = updateAbilityTargetTypeDto
        };
        UpdateAbilityTargetTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityTargetTypeDto  getByIdAbilityTargetTypeDto)
    {
        GetByIdAbilityTargetTypeCommandRequest request = new()
        {
             GetByIdAbilityTargetTypeDto = getByIdAbilityTargetTypeDto
        };
        GetByIdAbilityTargetTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetByActiveListAbilityTargetTypeCommandRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetByActiveListAbilityTargetTypeCommandResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetByInActiveListAbilityTargetTypeCommandRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetByInActiveListAbilityTargetTypeCommandResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
