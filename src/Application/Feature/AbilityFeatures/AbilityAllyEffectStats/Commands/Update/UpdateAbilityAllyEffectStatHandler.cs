using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Update;

public class UpdateAbilityAllyEffectStatHandler  : IRequestHandler<UpdateAbilityAllyEffectStatRequest, UpdateAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityAllyEffectStatResponse> Handle(UpdateAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.UpdateAbilityAllyEffectStatDto.Id);

        // Retrieve the AbilityAllyEffectStat associated with the provided ID from the service.
        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.UpdateAbilityAllyEffectStatDto.Id);

        // Map properties from the request DTO to the existing AbilityAllyEffectStat.
        _mapper.Map(request.UpdateAbilityAllyEffectStatDto, abilityAllyEffectStat);

        // Update the 'UpdatedDate' property to the current date and time.
        abilityAllyEffectStat.UpdatedDate = DateTime.Now;

        // Update the AbilityAllyEffectStat in the database.
        await _abilityAllyEffectStatService.Update(abilityAllyEffectStat);

        // Map the updated AbilityAllyEffectStat to the response DTO.
        UpdateAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<UpdateAbilityAllyEffectStatResponse>(abilityAllyEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
