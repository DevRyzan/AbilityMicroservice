using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Update;

public class UpdateAbilityEffectStatHandler : IRequestHandler<UpdateAbilityEffectStatRequest, UpdateAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEffectStatResponse> Handle(UpdateAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.UpdateAbilityEffectStatDto.Id);

        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.UpdateAbilityEffectStatDto.Id);

        _mapper.Map(request.UpdateAbilityEffectStatDto, abilityEffectStat);
        abilityEffectStat.UpdatedDate = DateTime.Now;

        await _abilityEffectStatService.Update(abilityEffectStat);

        UpdateAbilityEffectStatResponse mappedResponse = _mapper.Map<UpdateAbilityEffectStatResponse>(abilityEffectStat);
        return mappedResponse;
    }
}
