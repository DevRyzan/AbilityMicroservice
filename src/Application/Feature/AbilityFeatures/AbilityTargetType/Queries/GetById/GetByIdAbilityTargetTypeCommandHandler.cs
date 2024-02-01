using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetById;

public class GetByIdAbilityTargetTypeCommandHandler : IRequestHandler<GetByIdAbilityTargetTypeCommandRequest, GetByIdAbilityTargetTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public GetByIdAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<GetByIdAbilityTargetTypeCommandResponse> Handle(GetByIdAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability target type ID exists, applying business rules
        await _abilityTargetTypeBusinessRules.IdShouldBeExist(id: request.GetByIdAbilityTargetTypeDto.Id);

        // Retrieve an AbilityTargetType using the specified ID
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeService.GetById(id: request.GetByIdAbilityTargetTypeDto.Id);

        // Map the retrieved AbilityTargetType to a GetByIdAbilityTargetTypeCommandResponse using the mapper
        GetByIdAbilityTargetTypeCommandResponse mappedResponse = _mapper.Map<GetByIdAbilityTargetTypeCommandResponse>(abilityTargetType);

        // Return the mapped response
        return mappedResponse;


    }
}
