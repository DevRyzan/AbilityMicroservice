using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Update;

public class UpdateAbilityEffectTypeHandler : IRequestHandler<UpdateAbilityEffectTypeRequest, UpdateAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEffectTypeResponse> Handle(UpdateAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists in the business rules before updating the AbilityEffectType
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityEffectTypeDto.Id);

        // Retrieve the AbilityEffectType from the service using the provided ID
        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.UpdateAbilityEffectTypeDto.Id);

        // Update the AbilityEffectType properties with the values from the request DTO
        abilityEffectType.Name = request.UpdateAbilityEffectTypeDto.Name;
        abilityEffectType.Description = request.UpdateAbilityEffectTypeDto.Description;

        // Set the UpdatedDate to the current date and time
        abilityEffectType.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectType in the service to persist the changes
        await _abilityTypeService.Update(abilityEffectType);

        // Map the updated AbilityEffectType to the response DTO
        UpdateAbilityEffectTypeResponse mappedResponse = _mapper.Map<UpdateAbilityEffectTypeResponse>(abilityEffectType);

        // Return the mapped response
        return mappedResponse;

    }
}
