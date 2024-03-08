using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetListByActive;

public class GetListByActiveAbilityAttackStatHandler : IRequestHandler<GetListByActiveAbilityAttackStatRequest, List<GetListByActiveAbilityAttackStatResponse>>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityAttackStatResponse>> Handle(GetListByActiveAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAttackStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilityAttackStat> abilityAttackStatList = await _abilityAttackStatService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByActiveAbilityAttackStatResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityAttackStatResponse>>(abilityAttackStatList);
        return mappedResponse;
    }
}
