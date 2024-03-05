using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetById;

public class GetByIdAbilityEffectDisableTypeHandler : IRequestHandler<GetByIdAbilityEffectDisableTypeRequest, GetByIdAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityEffectDisableTypeResponse> Handle(GetByIdAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.GetByIdAbilityEffectDisableTypeDto.Id);

        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.GetByIdAbilityEffectDisableTypeDto.Id);

        GetByIdAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<GetByIdAbilityEffectDisableTypeResponse>(abilityEffectDisableType);
        return mappedResponse;
    }
}
