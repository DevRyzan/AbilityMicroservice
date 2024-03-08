using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.UndoDelete;

public class UndoDeleteAbilityEffectHandler : IRequestHandler<UndoDeleteAbilityEffectRequest, UndoDeleteAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEffectResponse> Handle(UndoDeleteAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEffectDto.Id);

        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.UndoDeleteAbilityEffectDto.Id);
        abilityEffect.IsDeleted = false;
        abilityEffect.UpdatedDate = DateTime.Now;

        await _abilityEffectService.Update(abilityEffect);

        UndoDeleteAbilityEffectResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEffectResponse>(abilityEffect);
        return mappedResponse;
    }
}
