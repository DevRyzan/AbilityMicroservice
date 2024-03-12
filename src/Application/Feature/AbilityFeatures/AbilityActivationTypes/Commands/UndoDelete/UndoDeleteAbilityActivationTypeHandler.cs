using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.UndoDelete;

public class UndoDeleteAbilityActivationTypeHandler : IRequestHandler<UndoDeleteAbilityActivationTypeRequest, UndoDeleteAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityActivationTypeResponse> Handle(UndoDeleteAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {// Check the existence of the specified ID; it should comply with business rules.
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityActivationTypeDto.Id);

        // Retrieve the AbilityActivationType associated with the provided ID from the service.
        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.UndoDeleteAbilityActivationTypeDto.Id);

        // Set the 'IsDeleted' flag to false, indicating the undo of the deletion.
        abilityActivationType.IsDeleted = false;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityActivationType.UpdatedDate = DateTime.Now;

        // Update the AbilityActivationType in the database.
        await _abilityActivationTypeService.Update(abilityActivationType);

        // Map the updated AbilityActivationType to the response DTO.
        UndoDeleteAbilityActivationTypeResponse mappedResponse = _mapper.Map<UndoDeleteAbilityActivationTypeResponse>(abilityActivationType);

        // Return the mapped response.
        return mappedResponse;

    }
}
