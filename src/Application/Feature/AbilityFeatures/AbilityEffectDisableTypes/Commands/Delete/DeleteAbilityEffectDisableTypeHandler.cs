using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Delete;

public class DeleteAbilityEffectDisableTypeHandler : IRequestHandler<DeleteAbilityEffectDisableTypeRequest, DeleteAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityEffectDisableTypeResponse> Handle(DeleteAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityEffectDisableTypeDto.Id);

        // Retrieve the AbilityEffectDisableType associated with the provided ID from the service.
        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.DeleteAbilityEffectDisableTypeDto.Id);

        // Set the 'IsDeleted' flag to true, indicating the deletion.
        abilityEffectDisableType.IsDeleted = true;

        // Set the 'Status' flag to false, indicating deactivation.
        abilityEffectDisableType.Status = false;

        // Set the 'DeletedDate' property to the current date and time.
        abilityEffectDisableType.DeletedDate = DateTime.Now;

        // Delete the AbilityEffectDisableType from the database.
        await _abilityEffectDisableTypeService.Delete(abilityEffectDisableType);

        // Map the deleted AbilityEffectDisableType to the response DTO.
        DeleteAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<DeleteAbilityEffectDisableTypeResponse>(abilityEffectDisableType);

        // Return the mapped response.
        return mappedResponse;

    }
}
