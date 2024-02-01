using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.ChangeStatus;

public class ChangeStatusAbilityTargetTypeCommandHandler : IRequestHandler<ChangeStatusAbilityTargetTypeCommandRequest, ChangeStatusAbilityTargetTypeCommandResponse>
{

    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public ChangeStatusAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<ChangeStatusAbilityTargetTypeCommandResponse> Handle(ChangeStatusAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability target type ID exists, applying business rules
        await _abilityTargetTypeBusinessRules.IdShouldBeExist(id: request.ChangeStatusAbilityTargetTypeDto.Id);

        // Retrieve an AbilityTargetType using the specified ID
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeService.GetById(request.ChangeStatusAbilityTargetTypeDto.Id);

        // Toggle the Status property of the AbilityTargetType
        abilityTargetType.Status = abilityTargetType.Status == true ? false : true;

        // Update the UpdatedDate property to the current date and time
        abilityTargetType.UpdatedDate = DateTime.Now;

        // Call the Update method of _abilityTargetTypeService to persist the changes
        await _abilityTargetTypeService.Update(abilityTargetType);

        // Map the updated AbilityTargetType to a ChangeStatusAbilityTargetTypeCommandResponse using the mapper
        ChangeStatusAbilityTargetTypeCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityTargetTypeCommandResponse>(abilityTargetType);

        // Return the mapped response
        return mappedResponse;
    }
}
