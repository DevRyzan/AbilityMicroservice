using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByActive;

public class GetByActiveListAbilityTargetTypeCommandHandler : IRequestHandler<GetByActiveListAbilityTargetTypeCommandRequest, List<GetByActiveListAbilityTargetTypeCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public GetByActiveListAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<List<GetByActiveListAbilityTargetTypeCommandResponse>> Handle(GetByActiveListAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified page request is valid, applying business rules
        await _abilityTargetTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityTargetTypes using the specified page index and size
        List<Domain.Abilities.AbilityTargetType> abilityTargetTypes = await _abilityTargetTypeService.GetActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of active AbilityTargetTypes to a list of GetByActiveListAbilityTargetTypeCommandResponse using the mapper
        List<GetByActiveListAbilityTargetTypeCommandResponse> mappedResponse = _mapper.Map<List<GetByActiveListAbilityTargetTypeCommandResponse>>(abilityTargetTypes);

        // Return the mapped response
        return mappedResponse;

    }
}
