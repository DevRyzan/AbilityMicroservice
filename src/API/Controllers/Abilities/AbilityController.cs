using Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.Ability.Commands.Create;
using Application.Feature.AbilityFeatures.Ability.Commands.Delete;
using Application.Feature.AbilityFeatures.Ability.Commands.Remove;
using Application.Feature.AbilityFeatures.Ability.Commands.Update;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Queries.GetById;
using Application.Feature.AbilityFeatures.Ability.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.Ability.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityController : BaseController
{

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityDto  changeStatusAbilityDto)
    {
        ChangeStatusAbilityCommandRequest request = new()
        {
             ChangeStatusAbilityDto   = changeStatusAbilityDto
        };
        ChangeStatusAbilityCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityDto createAbilityDto)
    {
        CreateAbilityCommandRequest request = new()
        {
             CreateAbilityDto = createAbilityDto
        };
        CreateAbilityCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityDto  deleteAbilityDto)
    {
        DeleteAbilityCommandRequest request = new()
        {
             DeleteAbilityDto = deleteAbilityDto
        };

        DeleteAbilityCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityDto  removeAbilityDto)
    {
        RemoveAbilityCommandRequest request = new()
        {
             RemoveAbilityDto = removeAbilityDto
        };
        RemoveAbilityCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityDto  updateAbilityDto)
    {
        UpdateAbilityCommandRequest request = new()
        {
             UpdateAbilityDto = updateAbilityDto
        };
        UpdateAbilityCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityDto  getByIdAbilityDto)
    {
        GetByIdAbilityQueryRequest request = new()
        {
             GetByIdAbilityDto = getByIdAbilityDto
        };
        GetByIdAbilityQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
