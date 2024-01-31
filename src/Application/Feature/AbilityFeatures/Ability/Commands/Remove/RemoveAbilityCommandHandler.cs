using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Remove;

public class RemoveAbilityCommandHandler : IRequestHandler<RemoveAbilityCommandRequest, RemoveAbilityCommandResponse>
{
    private readonly IAbilityService _abilityService;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityCommandHandler(IAbilityService abilityService, AbilityBusinessRules abilityBusinessRules, IMapper mapper)
    {
        _abilityService = abilityService;
        _abilityBusinessRules = abilityBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityCommandResponse> Handle(RemoveAbilityCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability ID exists, applying business rules
        await _abilityBusinessRules.IdShouldBeExist(id: request.RemoveAbilityDto.Id);

        // Apply additional business rules for removing the ability
        await _abilityBusinessRules.RemoveCondition(id: request.RemoveAbilityDto.Id);

        // Retrieve an Ability using the specified ID
        Domain.Abilities.Ability ability = await _abilityService.GetById(id: request.RemoveAbilityDto.Id);

        // Call the Remove method of _abilityService to remove the Ability
        await _abilityService.Remove(ability);

        // Map the removed Ability to a RemoveAbilityCommandResponse using the mapper
        RemoveAbilityCommandResponse mappedResponse = _mapper.Map<RemoveAbilityCommandResponse>(ability);

        // Return the mapped response
        return mappedResponse;
    }
}
