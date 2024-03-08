using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetListByInActive;

public class GetListByInActiveAbilityEffectHandler : IRequestHandler<GetListByInActiveAbilityEffectRequest, List<GetListByInActiveAbilityEffectResponse>>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityEffectResponse>> Handle(GetListByInActiveAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilityEffect> abilityEffects = await _abilityEffectService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByInActiveAbilityEffectResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityEffectResponse>>(abilityEffects);
        return mappedResponse;
    }
}
