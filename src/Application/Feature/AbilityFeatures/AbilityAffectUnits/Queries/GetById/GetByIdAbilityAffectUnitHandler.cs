using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetById;

public class GetByIdAbilityAffectUnitHandler : IRequestHandler<GetByIdAbilityAffectUnitRequest, GetByIdAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityAffectUnitResponse> Handle(GetByIdAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.GetByIdAbilityAffectUnitDto.Id);

        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.GetByIdAbilityAffectUnitDto.Id);

        GetByIdAbilityAffectUnitResponse mappedResponse = _mapper.Map<GetByIdAbilityAffectUnitResponse>(abilityAffectUnit);
        return mappedResponse;
    }
}
