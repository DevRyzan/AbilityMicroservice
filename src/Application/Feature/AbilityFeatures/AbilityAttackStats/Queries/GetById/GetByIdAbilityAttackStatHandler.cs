using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetById;

public class GetByIdAbilityAttackStatHandler : IRequestHandler<GetByIdAbilityAttackStatRequest, GetByIdAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityAttackStatResponse> Handle(GetByIdAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.GetByIdAbilityAttackStatDto.Id);
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.GetByIdAbilityAttackStatDto.Id);

        GetByIdAbilityAttackStatResponse mappedResponse = _mapper.Map<GetByIdAbilityAttackStatResponse>(abilityAttackStat);
        return mappedResponse;
    }
}