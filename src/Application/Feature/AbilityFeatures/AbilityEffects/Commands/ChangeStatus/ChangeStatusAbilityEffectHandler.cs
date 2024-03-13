using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectHandler : IRequestHandler<ChangeStatusAbilityEffectRequest, ChangeStatusAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEffectResponse> Handle(ChangeStatusAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityEffectBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEffectDto.Id);

        // Retrieve the AbilityEffect associated with the provided ID from the service.
        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.ChangeStatusAbilityEffectDto.Id);

        // Toggle the Status property and update the UpdatedDate.
        abilityEffect.Status = !abilityEffect.Status;
        abilityEffect.UpdatedDate = DateTime.Now;

        // Update the AbilityEffect in the service.
        await _abilityEffectService.Update(abilityEffect);

        // Map the updated AbilityEffect to the response DTO.
        ChangeStatusAbilityEffectResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEffectResponse>(abilityEffect);

        // Return the mapped response.
        return mappedResponse;

    }
}
