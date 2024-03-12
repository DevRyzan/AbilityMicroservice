using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Remove;

public class RemoveAbilityEffectStatHandler : IRequestHandler<RemoveAbilityEffectStatRequest, RemoveAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEffectStatResponse> Handle(RemoveAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the ID exists using business rules.
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.RemoveAbilityEffectStatDto.Id);

        // Remove any additional conditions related to the ID.
        await _abilityEffectStatBusinessRules.RemoveCondition(request.RemoveAbilityEffectStatDto.Id);

        // Get the AbilityEffectStat entity by ID.
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.RemoveAbilityEffectStatDto.Id);

        // Remove the AbilityEffectStat entity from the database.
        await _abilityEffectStatService.Remove(abilityEffectStat);

        // Map the removed AbilityEffectStat entity to the response DTO.
        RemoveAbilityEffectStatResponse mappedResponse = _mapper.Map<RemoveAbilityEffectStatResponse>(abilityEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
