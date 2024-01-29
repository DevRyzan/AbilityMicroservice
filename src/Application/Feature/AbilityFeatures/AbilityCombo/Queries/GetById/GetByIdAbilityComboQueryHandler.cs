using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetById;

public class GetByIdAbilityComboQueryHandler : IRequestHandler<GetByIdAbilityComboQueryRequest, GetByIdAbilityComboQueryResponse>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityComboQueryHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityComboQueryResponse> Handle(GetByIdAbilityComboQueryRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists in the business rules for AbilityCombo retrieval.
        await _abilityComboBusinessRules.IdShouldBeExist(id: request.GetByIdAbilityComboDto.Id);

        // Retrieve the AbilityCombo using the provided ID.
        Domain.Abilities.AbilityCombo abilityCombo = await _abilityComboService.GetById(id: request.GetByIdAbilityComboDto.Id);

        // Map the AbilityCombo to a response object.
        GetByIdAbilityComboQueryResponse mappedResponse = _mapper.Map<GetByIdAbilityComboQueryResponse>(abilityCombo);

        // Return the mapped response.
        return mappedResponse;


    }
}
