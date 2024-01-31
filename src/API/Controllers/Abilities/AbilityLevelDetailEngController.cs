using Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetByAbilityId;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityLevelDetailEngController : BaseController
{
    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityLevelDetailEngDto  changeStatusAbilityLevelDetail)
    {
        ChangeStatusAbilityLevelDetailEngCommandRequest request = new()
        {
             ChangeStatusAbilityLevelDetailEng = changeStatusAbilityLevelDetail
        };
        ChangeStatusAbilityLevelDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityLevelDetailEngDto  createAbilityLevelDetailEng)
    {
        CreateAbilityLevelDetailEngCommandRequest request = new()
        {
             CreateAbilityLevelDetailEng = createAbilityLevelDetailEng
        };
        CreateAbilityLevelDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityLevelDetailEngDto  deleteAbilityLevelDetailEngDto)
    {
        DeleteAbilityLevelDetailEngCommandRequest request = new()
        {
             DeleteAbilityLevelDetailEngDto = deleteAbilityLevelDetailEngDto
        };
        DeleteAbilityLevelDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityLevelDetailEngDto  removeAbilityLevelDetailEngDto)
    {
        RemoveAbilityLevelDetailEngCommandRequest request = new()
        {
             RemoveAbilityLevelDetailEngDto = removeAbilityLevelDetailEngDto
        };
        RemoveAbilityLevelDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityLevelDetailEngDto  updateAbilityLevelDetailEngDto)
    {
        UpdateAbilityLevelDetailEngCommandRequest request = new()
        {
             UpdateAbilityLevelDetailEngDto = updateAbilityLevelDetailEngDto
        };
        UpdateAbilityLevelDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityLevelDetailEngDto  getByIdAbilityLevelDetailEngDto)
    {
        GetByIdAbilityLevelDetailEngCommandRequest request = new()
        {
             GetByIdAbilityLevelDetailEngDto = getByIdAbilityLevelDetailEngDto
        };
        GetByIdAbilityLevelDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByAbilityLevelId")]
    public async Task<IActionResult> GetByAbilityId([FromQuery] GetByAbilityLevelIdAbilityLevelDetailEngDto  getByAbilityLevelIdAbilityLevelDetailEngDto)
    {
        GetByAbilityIdAbilityLevelDetailEngCommandRequest request = new()
        {
             GetByAbilityIdAbilityLevelDetailEngDto = getByAbilityLevelIdAbilityLevelDetailEngDto
        };
        GetByAbilityIdAbilityLevelDetailEngCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityLevelDetailEngCommandRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityLevelDetailEngCommandResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityLevelDetailEngCommandRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityLevelDetailEngCommandResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
