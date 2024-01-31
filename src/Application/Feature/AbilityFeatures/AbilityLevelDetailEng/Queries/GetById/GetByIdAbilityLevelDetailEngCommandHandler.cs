using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetById;

public class GetByIdAbilityLevelDetailEngCommandHandler : IRequestHandler<GetByIdAbilityLevelDetailEngCommandRequest, GetByIdAbilityLevelDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public GetByIdAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, IAbilityLevelService abilityLevelService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelService = abilityLevelService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
    }

    public async Task<GetByIdAbilityLevelDetailEngCommandResponse> Handle(GetByIdAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {

        await _abilityLevelDetailEngBusinessRules.IdShouldBeExist(id: request.GetByIdAbilityLevelDetailEngDto.Id);

        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngService.GetById(id: request.GetByIdAbilityLevelDetailEngDto.Id);

        GetByIdAbilityLevelDetailEngCommandResponse mappedResponse = _mapper.Map<GetByIdAbilityLevelDetailEngCommandResponse>(abilityLevelDetailEng);
        mappedResponse.AbilityLevelId = abilityLevelDetailEng.AbilityLevelId;
        mappedResponse.Id = abilityLevelDetailEng.Id;
        mappedResponse.Description = abilityLevelDetailEng.Description;

        return mappedResponse;
    }
}
