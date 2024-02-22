using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByInActive;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Create;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Delete;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Remove;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Update;
using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetById;
using Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetListByInActive;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class ResourceCostTypesController : BaseController
{
    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusResourceCostTypeDto changeStatusResourceCostTypeDto)
    {
        ChangeStatusResourceCostTypeCommandRequest request = new()
        {
            ChangeStatusResourceCostTypeDto = changeStatusResourceCostTypeDto
        };
        ChangeStatusResourceCostTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateResourcesCostTypeDto  createResourcesCostTypeDto)
    {
        CreateResourceCostTypeCommandRequest request = new()
        {
              CreateResourcesCostTypeDto = createResourcesCostTypeDto
        };
        CreateResourceCostTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteResourcesCostTypeDto  deleteResourcesCostTypeDto)
    {
        DeleteResourceCostTypeCommandRequest request = new()
        {
             DeleteResourcesCostTypeDto = deleteResourcesCostTypeDto
        };

        DeleteResourceCostTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteResourcesCostTypeDto  undoDeleteResourcesCostTypeDto)
    {
        UndoDeleteResourceCostTypeCommandRequest request = new()
        {
             UndoDeleteResourcesCostTypeDto = undoDeleteResourcesCostTypeDto
        };

        UndoDeleteResourceCostTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveResourcesCostTypeDto  removeResourcesCostTypeDto)
    {
        RemoveResourceCostTypeCommandRequest request = new()
        {
             RemoveResourcesCostTypeDto = removeResourcesCostTypeDto
        };
        RemoveResourceCostTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateResourcesCostTypeDto updateResourcesCostTypeDto)
    {
        UpdateResourceCostTypeCommandRequest request = new()
        {
             UpdateResourcesCostTypeDto = updateResourcesCostTypeDto
        };
        UpdateResourceCostTypeCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdResourcesCostTypeDto  getByIdResourcesCostTypeDto)
    {
        GetByIdResourceCostTypeQueryRequest request = new()
        {
             GetByIdResourcesCostTypeDto = getByIdResourcesCostTypeDto
        };
        GetByIdResourceCostTypeQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActiveList")]
    public async Task<IActionResult> GetByActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveResourceCostTypeQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByActiveResourceCostTypeQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActiveList")]
    public async Task<IActionResult> GetByInActiveList([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveResourceCostTypeQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        List<GetListByInActiveResourceCostTypeQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
