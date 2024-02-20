using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.ChangeStatus;

public class ChangeStatusAbilityComboCommandHandler : IRequestHandler<ChangeStatusAbilityComboCommandRequest, ChangeStatusAbilityComboCommandResponse>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityComboCommandHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityComboCommandResponse> Handle(ChangeStatusAbilityComboCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists in the business rules for AbilityCombo.
        await _abilityComboBusinessRules.IdShouldBeExist(id: request.ChangeStatusAbilityComboDto.Id);

        // Retrieve the AbilityCombo using the provided ID.
        Domain.Abilities.AbilityCombo abilityCombo = await _abilityComboService.GetById(id: request.ChangeStatusAbilityComboDto.Id);

        // Toggle the status of the AbilityCombo (if it's true, set it to false, and vice versa).
        abilityCombo.Status = abilityCombo.Status == true ? false : true;

        // Update the UpdatedDate property of the AbilityCombo to the current UTC time.
        abilityCombo.UpdatedDate = DateTime.Now;

        // Update the AbilityCombo in the database.
        await _abilityComboService.Update(abilityCombo);

        // Map the updated AbilityCombo to a response object.
        ChangeStatusAbilityComboCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityComboCommandResponse>(abilityCombo);

        // Return the mapped response.
        return mappedResponse;

    }
}
