using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Update;

public class UpdateAbilityDamageTypeHandler : IRequestHandler<UpdateAbilityDamageTypeRequest, UpdateAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityDamageTypeResponse> Handle(UpdateAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityDamageTypeDto.Id);

        // Retrieve the AbilityDamageType associated with the provided ID from the service.
        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.UpdateAbilityDamageTypeDto.Id);

        // Update the properties of the AbilityDamageType with data from the request DTO.
        abilityDamageType.Name = request.UpdateAbilityDamageTypeDto.Name;
        abilityDamageType.Description = request.UpdateAbilityDamageTypeDto.Description;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityDamageType.UpdatedDate = DateTime.Now;

        // Update the AbilityDamageType in the database.
        await _abilityDamageTypeService.Update(abilityDamageType);

        // Map the updated AbilityDamageType to the response DTO.
        UpdateAbilityDamageTypeResponse mappedResponse = _mapper.Map<UpdateAbilityDamageTypeResponse>(abilityDamageType);

        // Return the mapped response.
        return mappedResponse;

    }
}
