using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Queries.GetListByActive;

public class GetListByActiveAbilityQueryHandler : IRequestHandler<GetListByActiveAbilityQueryRequest, List<GetListByActiveAbilityQueryResponse>>
{
    private readonly IAbilityService _abilityService;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityQueryHandler(IAbilityService abilityService, AbilityBusinessRules abilityBusinessRules, IMapper mapper)
    {
        _abilityService = abilityService;
        _abilityBusinessRules = abilityBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityQueryResponse>> Handle(GetListByActiveAbilityQueryRequest request, CancellationToken cancellationToken)
    {
        //// Check if the specified page request is valid, applying business rules
        //await _abilityBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        //// Retrieve a list of active Abilities using the specified page index and size
        //List<Domain.Abilities.Ability> abilities = await _abilityService.GetActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        //// Map the list of active Abilities to a list of GetListByActiveAbilityQueryResponse using the mapper
        //List<GetListByActiveAbilityQueryResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityQueryResponse>>(abilities);

        //// Return the mapped response
        //return mappedResponse;

        throw new NotImplementedException();

    }
}
