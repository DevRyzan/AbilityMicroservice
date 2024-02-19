using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Queries.GetListByInActive;

public class GetListByInActiveAbilityQueryHandler : IRequestHandler<GetListByInActiveAbilityQueryRequest, List<GetListByInActiveAbilityQueryResponse>>
{
    private readonly IAbilityService _abilityService;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityQueryHandler(IAbilityService abilityService, AbilityBusinessRules abilityBusinessRules, IMapper mapper)
    {
        _abilityService = abilityService;
        _abilityBusinessRules = abilityBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityQueryResponse>> Handle(GetListByInActiveAbilityQueryRequest request, CancellationToken cancellationToken)
    {
        //// Check if the specified page request is valid, applying business rules
        //await _abilityBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        //// Retrieve a list of inactive Abilities using the specified page index and size
        //List<Domain.Abilities.Ability> abilities = await _abilityService.GetInActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        //// Map the list of inactive Abilities to a list of GetListByInActiveAbilityQueryResponse using the mapper
        //List<GetListByInActiveAbilityQueryResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityQueryResponse>>(abilities);

        //// Return the mapped response
        //return mappedResponse;


        throw new NotImplementedException();


    }
}
