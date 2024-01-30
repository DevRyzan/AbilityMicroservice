using Application.Feature.AbilityFeatures.AbilityLevel.Rules;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Remove;

public class RemoveAbilityLevelCommandHandler : IRequestHandler<RemoveAbilityLevelCommandRequest, RemoveAbilityLevelCommandResponse>
{
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IMapper _mapper;
    private readonly AbilityLevelBusinessRules _abilityLevelBusinessRules;

    public RemoveAbilityLevelCommandHandler(IAbilityLevelService abilityLevelService, IMapper mapper, AbilityLevelBusinessRules abilityLevelBusinessRules)
    {
        _abilityLevelService = abilityLevelService;
        _mapper = mapper;
        _abilityLevelBusinessRules = abilityLevelBusinessRules;
    }

    public async Task<RemoveAbilityLevelCommandResponse> Handle(RemoveAbilityLevelCommandRequest request, CancellationToken cancellationToken)
    {
        // Remove any additional conditions related to the AbilityLevel removal.
        await _abilityLevelBusinessRules.RemoveCondition(id: request.RemoveAbilityLevelDto.Id);

        // Retrieve the AbilityLevel using the provided ID.
        Domain.Abilities.AbilityLevel abilityLevel = await _abilityLevelService.GetById(id: request.RemoveAbilityLevelDto.Id);

        // Remove the AbilityLevel from the database.
        await _abilityLevelService.Remove(abilityLevel);

        // Map the removed AbilityLevel to a response object.
        RemoveAbilityLevelCommandResponse mappedResponse = _mapper.Map<RemoveAbilityLevelCommandResponse>(abilityLevel);

        // Return the mapped response.
        return mappedResponse;

    }
}
