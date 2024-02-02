using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetListByInActive;

public class GetListByInActiveAbilityTargetTypeDetailEngCommandHandler : IRequestHandler<GetListByInActiveAbilityTargetTypeDetailEngCommandRequest, List<GetListByInActiveAbilityTargetTypeDetailEngCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAbilityTargetTypeDetailEngService _abilityTargetTypeDetailEngService;
    private readonly AbilityTargetTypeDetailEngBusinessRules _abilityTargetTypeDetailEngBusinessRules;

    public GetListByInActiveAbilityTargetTypeDetailEngCommandHandler(IMapper mapper, IAbilityTargetTypeDetailEngService abilityTargetTypeDetailEngService, AbilityTargetTypeDetailEngBusinessRules abilityTargetTypeDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityTargetTypeDetailEngService = abilityTargetTypeDetailEngService;
        _abilityTargetTypeDetailEngBusinessRules = abilityTargetTypeDetailEngBusinessRules;
    }

    public async Task<List<GetListByInActiveAbilityTargetTypeDetailEngCommandResponse>> Handle(GetListByInActiveAbilityTargetTypeDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified page request is valid, applying business rules
        await _abilityTargetTypeDetailEngBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityTargetTypeDetailEngs using the specified page index and size
        List<Domain.Abilities.AbilityTargetTypeDetailEng> abilityTargetTypeDetailEngs = await _abilityTargetTypeDetailEngService.GetInActiveList(index: request.PageRequest.Page, size: request.PageRequest.Page);

        // Map the list of inactive AbilityTargetTypeDetailEngs to a list of GetListByInActiveAbilityTargetTypeDetailEngCommandResponse using the mapper
        List<GetListByInActiveAbilityTargetTypeDetailEngCommandResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityTargetTypeDetailEngCommandResponse>>(abilityTargetTypeDetailEngs);

        // Return the mapped response
        return mappedResponse;

    }
}
 