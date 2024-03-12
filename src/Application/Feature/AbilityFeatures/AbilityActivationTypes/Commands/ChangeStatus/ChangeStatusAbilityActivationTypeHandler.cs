using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityActivationTypeHandler : IRequestHandler<ChangeStatusAbilityActivationTypeRequest, ChangeStatusAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityActivationTypeResponse> Handle(ChangeStatusAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {// Check if the provided ID exists, enforcing a business rule.
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityActivationTypeDto.Id);

        // Retrieve the AbilityActivationType from the service based on the provided ID.
        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.ChangeStatusAbilityActivationTypeDto.Id);

        // Toggle the status of the retrieved AbilityActivationType (switch between true and false).
        abilityActivationType.Status = abilityActivationType.Status == true ? false : true;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityActivationType.UpdatedDate = DateTime.Now;

        // Update the AbilityActivationType in the database.
        await _abilityActivationTypeService.Update(abilityActivationType);

        // Map the updated AbilityActivationType to the response DTO.
        ChangeStatusAbilityActivationTypeResponse mappedResponse = _mapper.Map<ChangeStatusAbilityActivationTypeResponse>(abilityActivationType);

        // Return the mapped response.
        return mappedResponse;

    }
}
