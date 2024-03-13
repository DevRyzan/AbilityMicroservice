using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Delete;

public class DeleteAbilityEffectTypeHandler : IRequestHandler<DeleteAbilityEffectTypeRequest, DeleteAbilityEffectTypeResponse>
{

    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityEffectTypeResponse> Handle(DeleteAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Check if the provided ID exists in the business rules
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityEffectTypeDto.Id);

        // Retrieve the AbilityEffectType from the service using the provided ID
        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.DeleteAbilityEffectTypeDto.Id);

        // Set IsDeleted to true, marking the AbilityEffectType as deleted
        abilityEffectType.IsDeleted = true;

        // Set Status to false, indicating the inactive status after deletion
        abilityEffectType.Status = false;

        // Set DeletedDate to the current timestamp, marking when the AbilityEffectType was deleted
        abilityEffectType.DeletedDate = DateTime.Now;

        // Use the service to delete the AbilityEffectType from the database
        await _abilityTypeService.Delete(abilityEffectType);

        // Map the deleted AbilityEffectType to the response DTO
        DeleteAbilityEffectTypeResponse mappedResponse = _mapper.Map<DeleteAbilityEffectTypeResponse>(abilityEffectType);

        // Return the mapped response
        return mappedResponse;

    }
}
