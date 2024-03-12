using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityAllyEffectStatHandler : IRequestHandler<UndoDeleteAbilityAllyEffectStatRequest, UndoDeleteAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityAllyEffectStatResponse> Handle(UndoDeleteAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityAllyEffectStatDto.Id);

        // Retrieve the AbilityAllyEffectStat associated with the provided ID from the service.
        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.UndoDeleteAbilityAllyEffectStatDto.Id);

        // Set the 'IsDeleted' flag to false, indicating the undo of the deletion.
        abilityAllyEffectStat.IsDeleted = false;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityAllyEffectStat.UpdatedDate = DateTime.Now;

        // Update the AbilityAllyEffectStat in the database.
        await _abilityAllyEffectStatService.Update(abilityAllyEffectStat);

        // Map the updated AbilityAllyEffectStat to the response DTO.
        UndoDeleteAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilityAllyEffectStatResponse>(abilityAllyEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
