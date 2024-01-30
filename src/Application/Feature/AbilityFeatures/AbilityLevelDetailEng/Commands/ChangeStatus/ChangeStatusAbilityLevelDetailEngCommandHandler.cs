using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.ChangeStatus;

public class ChangeStatusAbilityLevelDetailEngCommandHandler : IRequestHandler<ChangeStatusAbilityLevelDetailEngCommandRequest, ChangeStatusAbilityLevelDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public ChangeStatusAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules, IAbilityLevelService abilityLevelService)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
        _abilityLevelService = abilityLevelService;
    }

    public async Task<ChangeStatusAbilityLevelDetailEngCommandResponse> Handle(ChangeStatusAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {

        await _abilityLevelDetailEngBusinessRules.IdShouldBeExist(id: request.ChangeStatusAbilityLevelDetailEng.Id);

        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngService.GetById(id: request.ChangeStatusAbilityLevelDetailEng.Id);

        abilityLevelDetailEng.Status = abilityLevelDetailEng.Status == true ? false: true;
        abilityLevelDetailEng.UpdatedDate = DateTime.Now;

        await _abilityLevelDetailEngService.Update(abilityLevelDetailEng);

        ChangeStatusAbilityLevelDetailEngCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityLevelDetailEngCommandResponse>(abilityLevelDetailEng);

        return mappedResponse;
    }
}
