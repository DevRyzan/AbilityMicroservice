using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Queries.GetById;

public class GetByIdAbilityQueryHandler : IRequestHandler<GetByIdAbilityQueryRequest, GetByIdAbilityQueryResponse>
{
    private readonly IAbilityService _abilityService;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityQueryHandler(IAbilityService abilityService, AbilityBusinessRules abilityBusinessRules, IMapper mapper)
    {
        _abilityService = abilityService;
        _abilityBusinessRules = abilityBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityQueryResponse> Handle(GetByIdAbilityQueryRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability ID exists, applying business rules
        await _abilityBusinessRules.IdShouldBeExist(id: request.GetByIdAbilityDto.Id);

        // Retrieve an Ability using the specified ID
        Domain.Abilities.Ability ability = await _abilityService.GetById(id: request.GetByIdAbilityDto.Id);

        // Map the retrieved Ability to a GetByIdAbilityQueryResponse using the mapper
        GetByIdAbilityQueryResponse mappedResponse = _mapper.Map<GetByIdAbilityQueryResponse>(ability);

        // Return the mapped response
        return mappedResponse;

    }
}
