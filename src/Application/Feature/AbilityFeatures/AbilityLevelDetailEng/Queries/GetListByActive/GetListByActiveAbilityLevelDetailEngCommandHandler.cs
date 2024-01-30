using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByActive;

public class GetListByActiveAbilityLevelDetailEngCommandHandler : IRequestHandler<GetListByActiveAbilityLevelDetailEngCommandRequest, List<GetListByActiveAbilityLevelDetailEngCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public GetListByActiveAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, IAbilityLevelService abilityLevelService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelService = abilityLevelService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
    }

    public async Task<List<GetListByActiveAbilityLevelDetailEngCommandResponse>> Handle(GetListByActiveAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {

        List<Domain.Abilities.AbilityLevelDetailEng> abilityLevelDetailEngs = await _abilityLevelDetailEngService.GetListByActive(index: request.PageRequest.PageSize, size: request.PageRequest.PageSize);

        List<GetListByActiveAbilityLevelDetailEngCommandResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityLevelDetailEngCommandResponse>>(abilityLevelDetailEngs);

        return mappedResponse;

    }
}
