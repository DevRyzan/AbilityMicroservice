using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityTargetTypeDetailEngController : BaseController
{
    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityTargetTypeDetailEngDto  changeStatusAbilityTargetTypeDetailEngDto)
    {
        ChangeStatusAbilityTargetTypeDetailEngCommandRequest request = new()
        {
             ChangeStatusAbilityTargetTypeDetailEngDto = changeStatusAbilityTargetTypeDetailEngDto
        };
        ChangeStatusAbilityTargetTypeDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityTargetTypeDetailEngDto  createAbilityTargetTypeDetailEngDto)
    {
        CreateAbilityTargetTypeDetailEngCommandRequest request = new()
        {
             CreateAbilityTargetTypeDetailEngDto = createAbilityTargetTypeDetailEngDto
        };
        CreateAbilityTargetTypeDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityTargetTypeDetailEngDto  deleteAbilityTargetTypeDetailEngDto)
    {
        DeleteAbilityTargetTypeDetailEngCommandRequest request = new()
        {
             DeleteAbilityTargetTypeDetailEngDto = deleteAbilityTargetTypeDetailEngDto
        };

        DeleteAbilityTargetTypeDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityTargetTypeDetailEngDto  removeAbilityTargetTypeDetailEngDto)
    {
        RemoveAbilityTargetTypeDetailEngCommandRequest request = new()
        {
             RemoveAbilityTargetTypeDetailEngDto = removeAbilityTargetTypeDetailEngDto
        };
        RemoveAbilityTargetTypeDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityTargetTypeDetailEngDto  updateAbilityTargetTypeDetailEngDto)
    {
        UpdateAbilityTargetTypeDetailEngCommandRequest request = new()
        {
             UpdateAbilityTargetTypeDetailEngDto = updateAbilityTargetTypeDetailEngDto
        };
        UpdateAbilityTargetTypeDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityTargetTypeDetailEngDto  getByIdAbilityTargetTypeDetailEngDto)
    {
        GetByIdAbilityTargetTypeDetailEngCommandRequest request = new()
        {
             GetByIdAbilityTargetTypeDetailEngDto = getByIdAbilityTargetTypeDetailEngDto
        };
        GetByIdAbilityTargetTypeDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityTargetTypeDetailEngCommandRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityTargetTypeDetailEngCommandResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityTargetTypeDetailEngCommandRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityTargetTypeDetailEngCommandResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}

