using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Delete;

public class DeleteAbilityActivationTypeHandler : IRequestHandler<DeleteAbilityActivationTypeRequest, DeleteAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityActivationTypeResponse> Handle(DeleteAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {// Check if the provided ID exists, enforcing a business rule.
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityActivationTypeDto.Id);

        // Retrieve the AbilityActivationType from the service based on the provided ID.
        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.DeleteAbilityActivationTypeDto.Id);

        // Set IsDeleted to true, indicating that the record is flagged as deleted.
        abilityActivationType.IsDeleted = true;

        // Set Status to false, indicating that the record is no longer active.
        abilityActivationType.Status = false;

        // Set the deletion timestamp for the AbilityActivationType.
        abilityActivationType.DeletedDate = DateTime.Now;

        // Delete the AbilityActivationType in the database using the service.
        await _abilityActivationTypeService.Delete(abilityActivationType);

        // Map the deleted AbilityActivationType to the response DTO.
        DeleteAbilityActivationTypeResponse mappedResponse = _mapper.Map<DeleteAbilityActivationTypeResponse>(abilityActivationType);

        // Return the mapped response.
        return mappedResponse;

    }
}
