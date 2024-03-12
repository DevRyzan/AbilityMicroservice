using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Delete;

public class DeleteAbilityAffectUnitHandler : IRequestHandler<DeleteAbilityAffectUnitRequest, DeleteAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityAffectUnitResponse> Handle(DeleteAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.DeleteAbilityAffectUnitDto.Id);

        // Retrieve the AbilityAffectUnit associated with the provided ID from the service.
        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.DeleteAbilityAffectUnitDto.Id);

        // Set IsDeleted to true, indicating that the record is flagged as deleted.
        abilityAffectUnit.IsDeleted = true;

        // Set Status to false, indicating that the record is no longer active.
        abilityAffectUnit.Status = false;

        // Set the deletion timestamp for the AbilityAffectUnit.
        abilityAffectUnit.DeletedDate = DateTime.Now;

        // Delete the AbilityAffectUnit in the database using the service.
        await _abilityAffectUnitService.Delete(abilityAffectUnit);

        // Map the deleted AbilityAffectUnit to the response DTO.
        DeleteAbilityAffectUnitResponse mappedResponse = _mapper.Map<DeleteAbilityAffectUnitResponse>(abilityAffectUnit);

        // Return the mapped response.
        return mappedResponse;

    }
}
