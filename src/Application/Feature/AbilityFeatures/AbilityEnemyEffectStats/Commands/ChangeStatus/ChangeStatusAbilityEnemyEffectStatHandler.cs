using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityEnemyEffectStatHandler : IRequestHandler<ChangeStatusAbilityEnemyEffectStatRequest, ChangeStatusAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEnemyEffectStatResponse> Handle(ChangeStatusAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists according to business rules
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEnemyEffectStatDto.Id);

        // Retrieve the AbilityEnemyEffectStat from the service based on the provided ID
        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.ChangeStatusAbilityEnemyEffectStatDto.Id);

        // Toggle the Status of the AbilityEnemyEffectStat (if true, set to false, and vice versa)
        abilityEnemyEffectStat.Status = abilityEnemyEffectStat.Status == true ? false : true;

        // Update the UpdatedDate to the current date and time
        abilityEnemyEffectStat.UpdatedDate = DateTime.Now;

        // Update the AbilityEnemyEffectStat in the service
        await _abilityEnemyEffectStatService.Update(abilityEnemyEffectStat);

        // Map the updated AbilityEnemyEffectStat to the response DTO
        ChangeStatusAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

