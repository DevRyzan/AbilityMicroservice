using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Update;

public class UpdateAbilitySelfEffectStatHandler : IRequestHandler<UpdateAbilitySelfEffectStatRequest, UpdateAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilitySelfEffectStatResponse> Handle(UpdateAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.UpdateAbilitySelfEffectStatDto.Id);

        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.UpdateAbilitySelfEffectStatDto.Id);

        _mapper.Map(request.UpdateAbilitySelfEffectStatDto, abilitySelfEffectStat);

        abilitySelfEffectStat.UpdatedDate = DateTime.Now;

        await _abilitySelfEffectStatService.Update(abilitySelfEffectStat);

        UpdateAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<UpdateAbilitySelfEffectStatResponse>(abilitySelfEffectStat);
        return mappedResponse;
    }
}
