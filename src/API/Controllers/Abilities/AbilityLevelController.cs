using Application.Feature.AbilityFeatures.AbilityLevel.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityLevel.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityLevel.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityLevel.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityLevel.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityLevel.Dto;
using Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityLevelController : BaseController
{
    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityLevelDto changeStatusAbilityLevel)
    {
        ChangeStatusAbilityLevelCommandRequest request = new()
        {
            ChangeStatusAbilityLevelDto = changeStatusAbilityLevel
        };
        ChangeStatusAbilityLevelCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityLevelDto createAbilityLevelDto)
    {
        CreateAbilityLevelCommandRequest request = new()
        {
             CreateAbilityLevelDto = createAbilityLevelDto
        };
        CreateAbilityLevelCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityLevelDto  deleteAbilityLevelDto)
    {
        DeleteAbilityLevelCommandRequest request = new()
        {
             DeleteAbilityLevelDto = deleteAbilityLevelDto
        };

        DeleteAbilityLevelCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityLevelDto  removeAbilityLevelDto)
    {
        RemoveAbilityLevelCommandRequest request = new()
        {
             RemoveAbilityLevelDto = removeAbilityLevelDto
        };
        RemoveAbilityLevelCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityLevelDto updateAbilityLevelDto)
    {
        UpdateAbilityLevelCommandRequest request = new()
        {
             UpdateAbilityLevelDto = updateAbilityLevelDto
        };
        UpdateAbilityLevelCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityLevelDto getByIdAbilityLevelDto)
    {
        GetByIdAbilityLevelCommandRequest request = new()
        {
             GetByIdAbilityLevelDto = getByIdAbilityLevelDto
        };
        GetByIdAbilityLevelCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityLevelCommandRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityLevelCommandResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityLevelCommandRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityLevelCommandResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
