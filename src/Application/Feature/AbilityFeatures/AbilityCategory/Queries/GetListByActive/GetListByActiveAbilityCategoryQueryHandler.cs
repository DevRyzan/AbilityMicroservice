using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByActive;

public class GetListByActiveAbilityCategoryQueryHandler : IRequestHandler<GetListByActiveAbilityCategoryQueryRequest, GetListResponse<GetListByActiveAbilityCategoryQueryResponse>>
{
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEngService;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public GetListByActiveAbilityCategoryQueryHandler(IAbilityCategoryDetailEngService abilityCategoryDetailEngService, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryDetailEngService = abilityCategoryDetailEngService;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<GetListResponse<GetListByActiveAbilityCategoryQueryResponse>> Handle(GetListByActiveAbilityCategoryQueryRequest request, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}
