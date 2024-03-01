using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetById;

public class GetByIdAbilityTypeQueryHandler : IRequestHandler<GetByIdAbilityTypeQueryRequest, GetByIdAbilityTypeQueryResponse>
{

    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityTypeQueryHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityTypeQueryResponse> Handle(GetByIdAbilityTypeQueryRequest request, CancellationToken cancellationToken)
    {
        await _abilityTypeBusinessRules.IdShouldBeExist(request.GetByIdAbilityTypeDto.Id);

        AbilityType abilityType = await _abilityTypeService.GetById(request.GetByIdAbilityTypeDto.Id);

        GetByIdAbilityTypeQueryResponse mappedResponse = _mapper.Map<GetByIdAbilityTypeQueryResponse>(abilityType);
        return mappedResponse;
    }
}
