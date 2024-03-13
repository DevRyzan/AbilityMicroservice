using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Remove;

public class RemoveAbilityActivationTypeHandler : IRequestHandler<RemoveAbilityActivationTypeRequest, RemoveAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityActivationTypeResponse> Handle(RemoveAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityActivationTypeDto.Id);

        // Check additional conditions for the removal process.
        await _abilityActivationTypeBusinessRules.RemoveCondition(request.RemoveAbilityActivationTypeDto.Id);

        // Retrieve the AbilityActivationType associated with the provided ID from the service.
        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.RemoveAbilityActivationTypeDto.Id);

        // Remove the AbilityActivationType from the database.
        await _abilityActivationTypeService.Remove(abilityActivationType);

        // Map the removed AbilityActivationType to the response DTO.
        RemoveAbilityActivationTypeResponse mappedResponse = _mapper.Map<RemoveAbilityActivationTypeResponse>(abilityActivationType);

        // Return the mapped response.
        return mappedResponse;

    }
}
