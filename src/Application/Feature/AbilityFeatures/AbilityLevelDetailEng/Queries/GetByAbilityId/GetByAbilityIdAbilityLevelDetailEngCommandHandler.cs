using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetByAbilityId;

public class GetByAbilityIdAbilityLevelDetailEngCommandHandler : IRequestHandler<GetByAbilityIdAbilityLevelDetailEngCommandRequest, GetByAbilityIdAbilityLevelDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public GetByAbilityIdAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, IAbilityLevelService abilityLevelService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelService = abilityLevelService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
    }

    public async Task<GetByAbilityIdAbilityLevelDetailEngCommandResponse> Handle(GetByAbilityIdAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityLevelDetailEngBusinessRules.AbilityLevelIdShouldBeExist(abilityLevelId: request.GetByAbilityIdAbilityLevelDetailEngDto.AbilityLevelId);

        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngService.GetByAbilityLevelId(abilityLevelId: request.GetByAbilityIdAbilityLevelDetailEngDto.AbilityLevelId);

        GetByAbilityIdAbilityLevelDetailEngCommandResponse mappedResponse = _mapper.Map<GetByAbilityIdAbilityLevelDetailEngCommandResponse>(abilityLevelDetailEng);
        mappedResponse.AbilityLevelId = abilityLevelDetailEng.AbilityLevelId;
        mappedResponse.Id = abilityLevelDetailEng.Id;
        mappedResponse.Description = abilityLevelDetailEng.Description;

        return mappedResponse;
    }
}
