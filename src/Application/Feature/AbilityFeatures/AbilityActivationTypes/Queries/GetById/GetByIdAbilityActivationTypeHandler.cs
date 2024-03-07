using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetById;

public class GetByIdAbilityActivationTypeHandler : IRequestHandler<GetByIdAbilityActivationTypeRequest, GetByIdAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityActivationTypeResponse> Handle(GetByIdAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.GetByIdAbilityActivationTypeDto.Id);

        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.GetByIdAbilityActivationTypeDto.Id);

        GetByIdAbilityActivationTypeResponse mappedResponse = _mapper.Map<GetByIdAbilityActivationTypeResponse>(abilityActivationType);
        return mappedResponse;
    }
}
