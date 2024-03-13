using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetById;

public class GetByIdAbilitySelfEffectStatHandler : IRequestHandler<GetByIdAbilitySelfEffectStatRequest, GetByIdAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilitySelfEffectStatResponse> Handle(GetByIdAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before attempting to retrieve the entity
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.GetByIdAbilitySelfEffectStatDto.Id);

        // Retrieve the AbilitySelfEffectStat entity from the service by ID
        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.GetByIdAbilitySelfEffectStatDto.Id);

        // Map the retrieved entity to the corresponding response DTO
        GetByIdAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<GetByIdAbilitySelfEffectStatResponse>(abilitySelfEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}
