using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;



namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Update;

public class UpdateAbilityEffectDisableTypeHandler : IRequestHandler<UpdateAbilityEffectDisableTypeRequest, UpdateAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEffectDisableTypeResponse> Handle(UpdateAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityEffectDisableTypeDto.Id);

        // Retrieve the AbilityEffectDisableType associated with the provided ID from the service.
        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.UpdateAbilityEffectDisableTypeDto.Id);

        // Update properties of the AbilityEffectDisableType with the values from the request DTO.
        abilityEffectDisableType.Name = request.UpdateAbilityEffectDisableTypeDto.Name;
        abilityEffectDisableType.Description = request.UpdateAbilityEffectDisableTypeDto.Description;

        // Set the 'UpdatedDate' property to the current date and time.
        abilityEffectDisableType.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectDisableType in the database.
        await _abilityEffectDisableTypeService.Update(abilityEffectDisableType);

        // Map the updated AbilityEffectDisableType to the response DTO.
        UpdateAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<UpdateAbilityEffectDisableTypeResponse>(abilityEffectDisableType);

        // Return the mapped response.
        return mappedResponse;

    }
}
