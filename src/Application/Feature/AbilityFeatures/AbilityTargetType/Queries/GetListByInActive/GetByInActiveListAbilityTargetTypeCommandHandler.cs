using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByInActive;

public class GetByInActiveListAbilityTargetTypeCommandHandler : IRequestHandler<GetByInActiveListAbilityTargetTypeCommandRequest, List<GetByInActiveListAbilityTargetTypeCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public GetByInActiveListAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<List<GetByInActiveListAbilityTargetTypeCommandResponse>> Handle(GetByInActiveListAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified page request is valid, applying business rules
        await _abilityTargetTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityTargetTypes using the specified page index and size
        List<Domain.Abilities.AbilityTargetType> abilityTargetTypes = await _abilityTargetTypeService.GetInActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of inactive AbilityTargetTypes to a list of GetByInActiveListAbilityTargetTypeCommandResponse using the mapper
        List<GetByInActiveListAbilityTargetTypeCommandResponse> mappedResponse = _mapper.Map<List<GetByInActiveListAbilityTargetTypeCommandResponse>>(abilityTargetTypes);

        // Return the mapped response
        return mappedResponse;

    }
}
