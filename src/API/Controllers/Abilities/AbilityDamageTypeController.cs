using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers.Abilities;

[Route("api/[controller]")]
[ApiController]
public class AbilityDamageTypeController : BaseController
{



    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusAbilityDamageTypeDto changeStatusAbilityDamageTypeDto)
    {
        ChangeStatusAbilityDamageTypeRequest request = new()
        {
            ChangeStatusAbilityDamageTypeDto = changeStatusAbilityDamageTypeDto
        };
        ChangeStatusAbilityDamageTypeResponse result = await Mediator.Send(request);
        return Ok(result);
    }






}
