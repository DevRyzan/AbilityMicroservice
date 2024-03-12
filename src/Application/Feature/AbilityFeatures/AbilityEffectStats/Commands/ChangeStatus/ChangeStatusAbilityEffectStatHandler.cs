using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectStatHandler : IRequestHandler<ChangeStatusAbilityEffectStatRequest, ChangeStatusAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEffectStatResponse> Handle(ChangeStatusAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists.
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEffectStatDto.Id);

        // Retrieve the AbilityEffectStat entity based on the provided ID.
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.ChangeStatusAbilityEffectStatDto.Id);

        // Toggle the Status property.
        abilityEffectStat.Status = abilityEffectStat.Status == true ? false : true;

        // Update the UpdatedDate property.
        abilityEffectStat.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectStat entity in the database.
        await _abilityEffectStatService.Update(abilityEffectStat);

        // Map the updated AbilityEffectStat entity to the response DTO.
        ChangeStatusAbilityEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEffectStatResponse>(abilityEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
