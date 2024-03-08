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
        await _abilityEffectBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEffectDto.Id);

        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.ChangeStatusAbilityEffectDto.Id);
        abilityEffect.Status = abilityEffect.Status == true ? false : true;
        abilityEffect.UpdatedDate = DateTime.Now;

        await _abilityEffectService.Update(abilityEffect);

        ChangeStatusAbilityEffectResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEffectResponse>(abilityEffect);
        return mappedResponse;
    }
}
