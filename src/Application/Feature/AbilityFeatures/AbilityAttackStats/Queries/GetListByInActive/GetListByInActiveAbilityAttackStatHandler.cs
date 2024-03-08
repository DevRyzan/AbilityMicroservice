using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetListByInActive;

public class GetListByInActiveAbilityAttackStatHandler : IRequestHandler<GetListByInActiveAbilityAttackStatRequest, List<GetListByInActiveAbilityAttackStatResponse>>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityAttackStatResponse>> Handle(GetListByInActiveAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAttackStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilityAttackStat> abilityAttackStatList = await _abilityAttackStatService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByInActiveAbilityAttackStatResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityAttackStatResponse>>(abilityAttackStatList);
        return mappedResponse;
    }
}
