using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityAllyEffectStatHandler : IRequestHandler<ChangeStatusAbilityAllyEffectStatRequest, ChangeStatusAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityAllyEffectStatResponse> Handle(ChangeStatusAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityAllyEffectStatDto.Id);

        // Retrieve the AbilityAllyEffectStat associated with the provided ID from the service.
        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.ChangeStatusAbilityAllyEffectStatDto.Id);

        // Toggle the status of the retrieved AbilityAllyEffectStat (switch between true and false).
        abilityAllyEffectStat.Status = abilityAllyEffectStat.Status == true ? false : true;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityAllyEffectStat.UpdatedDate = DateTime.Now;

        // Update the AbilityAllyEffectStat in the database.
        await _abilityAllyEffectStatService.Update(abilityAllyEffectStat);

        // Map the updated AbilityAllyEffectStat to the response DTO.
        ChangeStatusAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityAllyEffectStatResponse>(abilityAllyEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
