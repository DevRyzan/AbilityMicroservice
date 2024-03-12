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
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.GetByIdAbilityAffectUnitDto.Id);

        // Retrieve the AbilityAffectUnit associated with the provided ID from the service.
        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.GetByIdAbilityAffectUnitDto.Id);

        // Map the retrieved AbilityAffectUnit to the response DTO.
        GetByIdAbilityAffectUnitResponse mappedResponse = _mapper.Map<GetByIdAbilityAffectUnitResponse>(abilityAffectUnit);

        // Return the mapped response.
        return mappedResponse;

    }
}
