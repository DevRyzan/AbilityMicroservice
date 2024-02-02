using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;
using AutoMapper;
using MediatR;
using System.Collections.Generic;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetListByActive;

public class GetListByActiveAbilityTargetTypeDetailEngCommandHandler : IRequestHandler<GetListByActiveAbilityTargetTypeDetailEngCommandRequest, List<GetListByActiveAbilityTargetTypeDetailEngCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAbilityTargetTypeDetailEngService _abilityTargetTypeDetailEngService;
    private readonly AbilityTargetTypeDetailEngBusinessRules _abilityTargetTypeDetailEngBusinessRules;

    public GetListByActiveAbilityTargetTypeDetailEngCommandHandler(IMapper mapper, IAbilityTargetTypeDetailEngService abilityTargetTypeDetailEngService, AbilityTargetTypeDetailEngBusinessRules abilityTargetTypeDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityTargetTypeDetailEngService = abilityTargetTypeDetailEngService;
        _abilityTargetTypeDetailEngBusinessRules = abilityTargetTypeDetailEngBusinessRules;
    }

    public async Task<List<GetListByActiveAbilityTargetTypeDetailEngCommandResponse>> Handle(GetListByActiveAbilityTargetTypeDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified page request is valid, applying business rules
        await _abilityTargetTypeDetailEngBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityTargetTypeDetailEngs using the specified page index and size
        List<Domain.Abilities.AbilityTargetTypeDetailEng> abilityTargetTypeDetailEngs = await _abilityTargetTypeDetailEngService.GetActiveList(index: request.PageRequest.Page, size: request.PageRequest.Page);

        // Map the list of active AbilityTargetTypeDetailEngs to a list of GetListByActiveAbilityTargetTypeDetailEngCommandResponse using the mapper
        List<GetListByActiveAbilityTargetTypeDetailEngCommandResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityTargetTypeDetailEngCommandResponse>>(abilityTargetTypeDetailEngs);

        // Return the mapped response
        return mappedResponse;


    }
}
