using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;

public class GetByIdAbilityCategoryQueryHandler : IRequestHandler<GetByIdAbilityCategoryQueryRequest, GetByIdAbilityCategoryQueryResponse>
{
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEngService;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public GetByIdAbilityCategoryQueryHandler(IAbilityCategoryDetailEngService abilityCategoryDetailEngService, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryDetailEngService = abilityCategoryDetailEngService;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<GetByIdAbilityCategoryQueryResponse> Handle(GetByIdAbilityCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists in the business rules for AbilityCategory retrieval.
        await _abilityCategoryBusinessRules.IdShouldBeExist(request.AbilityCategoryGetByIdDto.Id);

        // Retrieve the AbilityCategoryDetailEng using the provided ID.
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEngService.GetByAbilityId(request.AbilityCategoryGetByIdDto.Id);

        // Map the AbilityCategoryDetailEng to a response object.
        GetByIdAbilityCategoryQueryResponse mappedResponse = _mapper.Map<GetByIdAbilityCategoryQueryResponse>(abilityCategoryDetailEng);

        // Set additional properties in the response object.
        mappedResponse.Id = abilityCategoryDetailEng.AbilityCategoryId;
        mappedResponse.AbilityCategoryDetailEngId = abilityCategoryDetailEng.Id;

        // Return the mapped response.
        return mappedResponse;

    }
}
