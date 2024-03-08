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
        await _abilityEffectBusinessRules.IdShouldBeExist(request.UpdateAbilityEffectDto.Id);

        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.UpdateAbilityEffectDto.Id);

        _mapper.Map(request.UpdateAbilityEffectDto, abilityEffect);
        abilityEffect.UpdatedDate = DateTime.Now;

        await _abilityEffectService.Update(abilityEffect);

        UpdateAbilityEffectResponse mappedResponse = _mapper.Map<UpdateAbilityEffectResponse>(abilityEffect);
        return mappedResponse;
    }
}
