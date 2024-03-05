using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetById;

public class GetByIdAbilityDamageTypeHandler : IRequestHandler<GetByIdAbilityDamageTypeRequest, GetByIdAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityDamageTypeResponse> Handle(GetByIdAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.GetByIdAbilityDamageTypeDto.Id);

        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.GetByIdAbilityDamageTypeDto.Id);

        GetByIdAbilityDamageTypeResponse mappedResponse = _mapper.Map<GetByIdAbilityDamageTypeResponse>(abilityDamageType);
        return mappedResponse;
    }
}
