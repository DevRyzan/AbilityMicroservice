using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Remove;

public class RemoveAbilitySelfEffectStatHandler : IRequestHandler<RemoveAbilitySelfEffectStatRequest, RemoveAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilitySelfEffectStatResponse> Handle(RemoveAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before attempting removal
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.RemoveAbilitySelfEffectStatDto.Id);

        // Retrieve the AbilitySelfEffectStat entity from the service by ID
        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.RemoveAbilitySelfEffectStatDto.Id);

        // Perform the removal of the entity from the database
        await _abilitySelfEffectStatService.Remove(abilitySelfEffectStat);

        // Map the removed entity to the corresponding response DTO
        RemoveAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<RemoveAbilitySelfEffectStatResponse>(abilitySelfEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}
