using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;

public class GetByIdAbilityCategoryQueryHandler : IRequestHandler<GetByIdAbilityCategoryQueryRequest, GetByIdAbilityCategoryQueryResponse>
{
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEngService;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public GetByIdAbilityCategoryQueryHandler(IAbilityCategoryDetailEngService abilityCategoryDetailEngService, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryDetailEngService = abilityCategoryDetailEngService;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<GetByIdAbilityCategoryQueryResponse> Handle(GetByIdAbilityCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        await _abilityCategoryBusinessRules.IdShouldBeExist(request.Id);

        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEngService.GetByAbilityId(request.Id);

        GetByIdAbilityCategoryQueryResponse mappedResponse = _mapper.Map<GetByIdAbilityCategoryQueryResponse>(abilityCategoryDetailEng);
        mappedResponse.Id = abilityCategoryDetailEng.AbilityCategoryId;
        mappedResponse.AbilityCategoryDetailEngId = abilityCategoryDetailEng.Id;

        return mappedResponse;
    }
}
