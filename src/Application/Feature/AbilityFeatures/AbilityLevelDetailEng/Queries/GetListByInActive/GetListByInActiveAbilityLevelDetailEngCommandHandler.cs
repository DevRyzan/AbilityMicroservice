using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByInActive;


public class GetListByInActiveAbilityLevelDetailEngCommandHandler : IRequestHandler<GetListByInActiveAbilityLevelDetailEngCommandRequest, List<GetListByInActiveAbilityLevelDetailEngCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public GetListByInActiveAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, IAbilityLevelService abilityLevelService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelService = abilityLevelService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
    }

    public async Task<List<GetListByInActiveAbilityLevelDetailEngCommandResponse>> Handle(GetListByInActiveAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityLevelDetailEngBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<Domain.Abilities.AbilityLevelDetailEng> abilityLevelDetailEngs = await _abilityLevelDetailEngService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByInActiveAbilityLevelDetailEngCommandResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityLevelDetailEngCommandResponse>>(abilityLevelDetailEngs);

        return mappedResponse;
    }
}
