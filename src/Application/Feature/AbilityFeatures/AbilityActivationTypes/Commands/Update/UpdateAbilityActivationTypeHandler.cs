using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Update;

public class UpdateAbilityActivationTypeHandler : IRequestHandler<UpdateAbilityActivationTypeRequest, UpdateAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityActivationTypeResponse> Handle(UpdateAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityActivationTypeDto.Id);

        // Retrieve the AbilityActivationType associated with the provided ID from the service.
        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.UpdateAbilityActivationTypeDto.Id);

        // Update properties with the values from the request DTO.
        abilityActivationType.Name = request.UpdateAbilityActivationTypeDto.Name;
        abilityActivationType.Description = request.UpdateAbilityActivationTypeDto.Description;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityActivationType.UpdatedDate = DateTime.Now;

        // Update the AbilityActivationType in the database.
        await _abilityActivationTypeService.Update(abilityActivationType);

        // Map the updated AbilityActivationType to the response DTO.
        UpdateAbilityActivationTypeResponse mappedResponse = _mapper.Map<UpdateAbilityActivationTypeResponse>(abilityActivationType);

        // Return the mapped response.
        return mappedResponse;
    }
}
