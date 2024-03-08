using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Delete;

public class DeleteAbilityAttackStatHandler : IRequestHandler<DeleteAbilityAttackStatRequest, DeleteAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityAttackStatResponse> Handle(DeleteAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.DeleteAbilityAttackStatDto.Id);

        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.DeleteAbilityAttackStatDto.Id);
        abilityAttackStat.IsDeleted = true;
        abilityAttackStat.Status = false;
        abilityAttackStat.DeletedDate = DateTime.Now;

        await _abilityAttackStatService.Delete(abilityAttackStat);

        DeleteAbilityAttackStatResponse mappedResponse = _mapper.Map<DeleteAbilityAttackStatResponse>(abilityAttackStat);
        return mappedResponse;
    }
}
