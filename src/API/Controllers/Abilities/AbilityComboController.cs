using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCategory.Dto;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityComboController : BaseController
{
    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityComboDto changeStatusAbilityComboDto)
    {
        ChangeStatusAbilityComboCommandRequest request = new()
        {
            ChangeStatusAbilityComboDto = changeStatusAbilityComboDto
        };
        ChangeStatusAbilityComboCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityComboDto createAbilityComboDto)
    {
        CreateAbilityComboCommandRequest request = new()
        {
            CreateAbilityComboDto = createAbilityComboDto
        };
        CreateAbilityComboCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityComboDto deleteAbilityComboDto)
    {
        DeleteAbilityComboCommandRequest request = new()
        {
            DeleteAbilityComboDto = deleteAbilityComboDto
        };

        DeleteAbilityComboCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityComboDto removeAbilityComboDto)
    {
        RemoveAbilityComboCommandRequest request = new()
        {
            RemoveAbilityComboDto = removeAbilityComboDto
        };
        RemoveAbilityComboCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityComboDto updateAbilityComboDto)
    {
        UpdateAbilityComboCommandRequest request = new()
        {
            UpdateAbilityComboDto = updateAbilityComboDto
        };
        UpdateAbilityComboCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdAbilityComboDto getByIdAbilityComboDto)
    {
        GetByIdAbilityComboQueryRequest request = new()
        {
            GetByIdAbilityComboDto = getByIdAbilityComboDto
        };
        GetByIdAbilityComboQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveAbilityComboQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveAbilityComboQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveAbilityComboQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveAbilityComboQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }




}
