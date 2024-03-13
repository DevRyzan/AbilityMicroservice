using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Update;

public class UpdateAbilityEffectHandler : IRequestHandler<UpdateAbilityEffectRequest, UpdateAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEffectResponse> Handle(UpdateAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before updating the AbilityEffect.
        await _abilityEffectBusinessRules.IdShouldBeExist(request.UpdateAbilityEffectDto.Id);

        // Retrieve the AbilityEffect entity by ID.
        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.UpdateAbilityEffectDto.Id);

        // Map the properties from the request DTO to the entity.
        _mapper.Map(request.UpdateAbilityEffectDto, abilityEffect);

        // Set the UpdatedDate to the current date.
        abilityEffect.UpdatedDate = DateTime.Now;

        // Update the AbilityEffect in the service.
        await _abilityEffectService.Update(abilityEffect);

        // Map the updated AbilityEffect to the response DTO.
        UpdateAbilityEffectResponse mappedResponse = _mapper.Map<UpdateAbilityEffectResponse>(abilityEffect);

        // Return the mapped response.
        return mappedResponse;

    }
}
