using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Delete;

public class DeleteAbilityTargetTypeCommandHandler : IRequestHandler<DeleteAbilityTargetTypeCommandRequest, DeleteAbilityTargetTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public DeleteAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<DeleteAbilityTargetTypeCommandResponse> Handle(DeleteAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability target type ID exists, applying business rules
        await _abilityTargetTypeBusinessRules.IdShouldBeExist(id: request.DeleteAbilityTargetTypeDto.Id);

        // Retrieve an AbilityTargetType using the specified ID
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeService.GetById(id: request.DeleteAbilityTargetTypeDto.Id);

        // Update the properties of the AbilityTargetType to mark it as deleted
        abilityTargetType.Status = false;
        abilityTargetType.IsDeleted = true;
        abilityTargetType.DeletedDate = DateTime.Now;

        // Call the Delete method of _abilityTargetTypeService to delete the AbilityTargetType
        await _abilityTargetTypeService.Delete(abilityTargetType);

        // Map the deleted AbilityTargetType to a DeleteAbilityTargetTypeCommandResponse using the mapper
        DeleteAbilityTargetTypeCommandResponse mappedResponse = _mapper.Map<DeleteAbilityTargetTypeCommandResponse>(abilityTargetType);

        // Return the mapped response
        return mappedResponse;

    }
}
