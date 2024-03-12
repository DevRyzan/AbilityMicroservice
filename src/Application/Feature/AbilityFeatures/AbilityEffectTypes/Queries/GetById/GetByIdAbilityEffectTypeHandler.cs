using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetById;

public class GetByIdAbilityEffectTypeHandler : IRequestHandler<GetByIdAbilityEffectTypeRequest, GetByIdAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityEffectTypeResponse> Handle(GetByIdAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists in the business rules before retrieving the AbilityEffectType
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.GetByIdAbilityEffectTypeDto.Id);

        // Retrieve the AbilityEffectType from the service using the provided ID
        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.GetByIdAbilityEffectTypeDto.Id);

        // Map the retrieved AbilityEffectType to the response DTO
        GetByIdAbilityEffectTypeResponse mappedResponse = _mapper.Map<GetByIdAbilityEffectTypeResponse>(abilityEffectType);

        // Return the mapped response
        return mappedResponse;

    }
}
