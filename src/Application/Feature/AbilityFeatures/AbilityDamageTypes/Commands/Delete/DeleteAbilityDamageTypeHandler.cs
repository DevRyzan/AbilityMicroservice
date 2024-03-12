using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Delete;

public class DeleteAbilityDamageTypeHandler : IRequestHandler<DeleteAbilityDamageTypeRequest, DeleteAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityDamageTypeResponse> Handle(DeleteAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityDamageTypeDto.Id);

        // Retrieve the AbilityDamageType associated with the provided ID from the service.
        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.DeleteAbilityDamageTypeDto.Id);

        // Set IsDeleted to true, indicating that the record is flagged as deleted.
        abilityDamageType.IsDeleted = true;

        // Set Status to false, indicating that the record is no longer active.
        abilityDamageType.Status = false;

        // Set the deletion timestamp for the AbilityDamageType.
        abilityDamageType.DeletedDate = DateTime.Now;

        // Delete the AbilityDamageType in the database using the service.
        await _abilityDamageTypeService.Delete(abilityDamageType);

        // Map the deleted AbilityDamageType to the response DTO.
        DeleteAbilityDamageTypeResponse mappedResponse = _mapper.Map<DeleteAbilityDamageTypeResponse>(abilityDamageType);

        // Return the mapped response.
        return mappedResponse;

    }
}
