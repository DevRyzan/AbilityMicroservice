using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Delete;

public class DeleteAbilityEffectStatHandler : IRequestHandler<DeleteAbilityEffectStatRequest, DeleteAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityEffectStatResponse> Handle(DeleteAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.DeleteAbilityEffectStatDto.Id);

        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.DeleteAbilityEffectStatDto.Id);
        abilityEffectStat.IsDeleted = true;
        abilityEffectStat.Status = false;
        abilityEffectStat.DeletedDate = DateTime.Now;

        DeleteAbilityEffectStatResponse mappedResponse = _mapper.Map<DeleteAbilityEffectStatResponse>(abilityEffectStat);
        return mappedResponse;
    }

}
