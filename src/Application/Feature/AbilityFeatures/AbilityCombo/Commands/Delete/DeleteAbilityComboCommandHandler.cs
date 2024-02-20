using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Delete;

public class DeleteAbilityComboCommandHandler : IRequestHandler<DeleteAbilityComboCommandRequest, DeleteAbilityComboCommandResponse>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityComboCommandHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityComboCommandResponse> Handle(DeleteAbilityComboCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists in the business rules for AbilityCombo deletion.
        await _abilityComboBusinessRules.IdShouldBeExist(id: request.DeleteAbilityComboDto.Id);

        // Retrieve the AbilityCombo using the provided ID.
        Domain.Abilities.AbilityCombo abilityCombo = await _abilityComboService.GetById(id: request.DeleteAbilityComboDto.Id);

        // Set the Status to false, mark the AbilityCombo as deleted, and record the deletion date.
        abilityCombo.Status = false;
        abilityCombo.IsDeleted = true;
        abilityCombo.DeletedDate = DateTime.Now;

        // Update the AbilityCombo in the database.
        await _abilityComboService.Update(abilityCombo);

        // Map the deleted AbilityCombo to a response object.
        DeleteAbilityComboCommandResponse mappedResponse = _mapper.Map<DeleteAbilityComboCommandResponse>(abilityCombo);

        // Return the mapped response.
        return mappedResponse;
    
    }
}
