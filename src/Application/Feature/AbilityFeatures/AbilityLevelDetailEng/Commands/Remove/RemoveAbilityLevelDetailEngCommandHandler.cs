using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Remove;

public class RemoveAbilityLevelDetailEngCommandHandler : IRequestHandler<RemoveAbilityLevelDetailEngCommandRequest, RemoveAbilityLevelDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public RemoveAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
    }

    public async Task<RemoveAbilityLevelDetailEngCommandResponse> Handle(RemoveAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        
        await _abilityLevelDetailEngBusinessRules.IdShouldBeExist(id: request.RemoveAbilityLevelDetailEngDto.Id);
        await _abilityLevelDetailEngBusinessRules.RemoveCondition(id: request.RemoveAbilityLevelDetailEngDto.Id);

        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngService.GetById(id: request.RemoveAbilityLevelDetailEngDto.Id);
        
        await _abilityLevelDetailEngService.Remove(abilityLevelDetailEng);

        RemoveAbilityLevelDetailEngCommandResponse mappedResponse = _mapper.Map<RemoveAbilityLevelDetailEngCommandResponse>(abilityLevelDetailEng);

        return mappedResponse;
    }
}
