using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Remove;

public class RemoveAbilityTargetTypeCommandHandler : IRequestHandler<RemoveAbilityTargetTypeCommandRequest, RemoveAbilityTargetTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public RemoveAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<RemoveAbilityTargetTypeCommandResponse> Handle(RemoveAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability target type ID exists, applying business rules
        await _abilityTargetTypeBusinessRules.IdShouldBeExist(id: request.RemoveAbilityTargetTypeDto.Id);

        // Apply additional business rules for removing the ability target type
        await _abilityTargetTypeBusinessRules.RemoveCondition(id: request.RemoveAbilityTargetTypeDto.Id);

        // Retrieve an AbilityTargetType using the specified ID
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeService.GetById(id: request.RemoveAbilityTargetTypeDto.Id);

        // Call the Remove method of _abilityTargetTypeService to remove the AbilityTargetType
        await _abilityTargetTypeService.Remove(abilityTargetType);

        // Map the removed AbilityTargetType to a RemoveAbilityTargetTypeCommandResponse using the mapper
        RemoveAbilityTargetTypeCommandResponse mappedResponse = _mapper.Map<RemoveAbilityTargetTypeCommandResponse>(abilityTargetType);

        // Return the mapped response
        return mappedResponse;

    }
}
