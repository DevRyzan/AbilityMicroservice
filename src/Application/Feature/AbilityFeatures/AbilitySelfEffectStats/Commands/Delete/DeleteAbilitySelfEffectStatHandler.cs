using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Delete;

public class DeleteAbilitySelfEffectStatHandler : IRequestHandler<DeleteAbilitySelfEffectStatRequest, DeleteAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilitySelfEffectStatResponse> Handle(DeleteAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.DeleteAbilitySelfEffectStatDto.Id);

        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.DeleteAbilitySelfEffectStatDto.Id);
        abilitySelfEffectStat.IsDeleted = true;
        abilitySelfEffectStat.Status = false;
        abilitySelfEffectStat.DeletedDate = DateTime.Now;

        await _abilitySelfEffectStatService.Delete(abilitySelfEffectStat);

        DeleteAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<DeleteAbilitySelfEffectStatResponse>(abilitySelfEffectStat);
        return mappedResponse;
    }
}
