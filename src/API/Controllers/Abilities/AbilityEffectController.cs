using Application.Feature.AbilityFeatures.AbilityEffects.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityEffectController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAbilityEffectDto createAbilityEffectDto)
    {
        CreateAbilityEffectRequest request = new()
        {
            CreateAbilityEffectDto = createAbilityEffectDto
        };
        CreateAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityEffectDto updateAbilityEffectDto)
    {
        UpdateAbilityEffectRequest request = new()
        {
            UpdateAbilityEffectDto = updateAbilityEffectDto
        };
        UpdateAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAbilityEffectDto deleteAbilityEffectDto)
    {
        DeleteAbilityEffectRequest request = new()
        {
            DeleteAbilityEffectDto = deleteAbilityEffectDto
        };

        DeleteAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteAbilityEffectDto undoDeleteAbilityEffectDto)
    {
        UndoDeleteAbilityEffectRequest request = new()
        {
            UndoDeleteAbilityEffectDto = undoDeleteAbilityEffectDto
        };
        UndoDeleteAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityEffectDto changeStatusAbilityEffectDto)
    {
        ChangeStatusAbilityEffectRequest request = new()
        {
            ChangeStatusAbilityEffectDto = changeStatusAbilityEffectDto
        };
        ChangeStatusAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveAbilityEffectDto removeAbilityEffectDto)
    {
        RemoveAbilityEffectRequest request = new()
        {
            RemoveAbilityEffectDto = removeAbilityEffectDto
        };
        RemoveAbilityEffectResponse result = await Mediator.Send(request);
        return Ok(result);
    }
}
