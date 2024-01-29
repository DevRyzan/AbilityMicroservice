using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Remove;

public class RemoveAbilityComboCommandHandler : IRequestHandler<RemoveAbilityComboCommandRequest, RemoveAbilityComboCommandResponse>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityComboCommandHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityComboCommandResponse> Handle(RemoveAbilityComboCommandRequest request, CancellationToken cancellationToken)
    {
        // Remove any additional conditions related to the AbilityCombo removal.
        await _abilityComboBusinessRules.RemoveCondition(id: request.RemoveAbilityComboDto.Id);

        // Check if the specified ID exists in the business rules for AbilityCombo removal.
        await _abilityComboBusinessRules.IdShouldBeExist(id: request.RemoveAbilityComboDto.Id);

        // Retrieve the AbilityCombo using the provided ID.
        Domain.Abilities.AbilityCombo abilityCombo = await _abilityComboService.GetById(id: request.RemoveAbilityComboDto.Id);

        // Remove the AbilityCombo from the database.
        await _abilityComboService.Remove(abilityCombo);

        // Map the removed AbilityCombo to a response object.
        RemoveAbilityComboCommandResponse mappedResponse = _mapper.Map<RemoveAbilityComboCommandResponse>(abilityCombo);

        // Return the mapped response.
        return mappedResponse;


    }
}
