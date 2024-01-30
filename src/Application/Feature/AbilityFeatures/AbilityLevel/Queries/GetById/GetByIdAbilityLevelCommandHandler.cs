using Application.Feature.AbilityFeatures.AbilityLevel.Rules;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetById;

public class GetByIdAbilityLevelCommandHandler : IRequestHandler<GetByIdAbilityLevelCommandRequest, GetByIdAbilityLevelCommandResponse>
{
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IMapper _mapper;
    private readonly AbilityLevelBusinessRules _abilityLevelBusinessRules;

    public GetByIdAbilityLevelCommandHandler(IAbilityLevelService abilityLevelService, IMapper mapper, AbilityLevelBusinessRules abilityLevelBusinessRules)
    {
        _abilityLevelService = abilityLevelService;
        _mapper = mapper;
        _abilityLevelBusinessRules = abilityLevelBusinessRules;
    }

    public async Task<GetByIdAbilityLevelCommandResponse> Handle(GetByIdAbilityLevelCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists in the business rules for AbilityLevel retrieval.
        await _abilityLevelBusinessRules.IdShouldBeExist(id: request.GetByIdAbilityLevelDto.Id);

        // Retrieve the AbilityLevel using the provided ID.
        Domain.Abilities.AbilityLevel abilityLevel = await _abilityLevelService.GetById(id: request.GetByIdAbilityLevelDto.Id);

        // Map the AbilityLevel to a response object.
        GetByIdAbilityLevelCommandResponse mappedResponse = _mapper.Map<GetByIdAbilityLevelCommandResponse>(abilityLevel);

        // Return the mapped response.
        return mappedResponse;


    }
}
