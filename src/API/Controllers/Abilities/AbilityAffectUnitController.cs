using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityAffectUnitController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityAffectUnitDto createAbilityAffectUnitDto)
    {
        CreateAbilityAffectUnitRequest request = new()
        {
            CreateAbilityAffectUnitDto = createAbilityAffectUnitDto
        };
        CreateAbilityAffectUnitResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityAffectUnitDto changeStatusAbilityAffectUnitDto)
    {
        ChangeStatusAbilityAffectUnitRequest request = new()
        {
            ChangeStatusAbilityAffectUnitDto = changeStatusAbilityAffectUnitDto
        };
        ChangeStatusAbilityAffectUnitResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityAffectUnitDto deleteAbilityAffectUnitDto)
    {
        DeleteAbilityAffectUnitRequest request = new()
        {
            DeleteAbilityAffectUnitDto = deleteAbilityAffectUnitDto
        };

        DeleteAbilityAffectUnitResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityAffectUnitDto undoDeleteAbilityAffectUnitDto)
    {
        UndoDeleteAbilityAffectUnitRequest request = new()
        {
            UndoDeleteAbilityAffectUnitDto = undoDeleteAbilityAffectUnitDto
        };
        UndoDeleteAbilityAffectUnitResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityAffectUnitDto updateAbilityAffectUnitDto)
    {
        UpdateAbilityAffectUnitRequest request = new()
        {
            UpdateAbilityAffectUnitDto = updateAbilityAffectUnitDto
        };
        UpdateAbilityAffectUnitResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityAffectUnitDto removeAbilityAffectUnitDto)
    {
        RemoveAbilityAffectUnitRequest request = new()
        {
            RemoveAbilityAffectUnitDto = removeAbilityAffectUnitDto
        };
        RemoveAbilityAffectUnitResponse result = await Mediator.Send(request);
        return Ok(result);
    }




}
