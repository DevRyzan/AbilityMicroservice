using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetById;

public class GetByIdAbilityTargetTypeDetailEngCommandHandler : IRequestHandler<GetByIdAbilityTargetTypeDetailEngCommandRequest, GetByIdAbilityTargetTypeDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityTargetTypeDetailEngService _abilityTargetTypeDetailEngService;
    private readonly AbilityTargetTypeDetailEngBusinessRules _abilityTargetTypeDetailEngBusinessRules;

    public GetByIdAbilityTargetTypeDetailEngCommandHandler(IMapper mapper, IAbilityTargetTypeDetailEngService abilityTargetTypeDetailEngService, AbilityTargetTypeDetailEngBusinessRules abilityTargetTypeDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityTargetTypeDetailEngService = abilityTargetTypeDetailEngService;
        _abilityTargetTypeDetailEngBusinessRules = abilityTargetTypeDetailEngBusinessRules;
    }

    public async Task<GetByIdAbilityTargetTypeDetailEngCommandResponse> Handle(GetByIdAbilityTargetTypeDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability target type detail (English) ID exists, applying business rules
        await _abilityTargetTypeDetailEngBusinessRules.IdShouldBeExist(id: request.GetByIdAbilityTargetTypeDetailEngDto.Id);

        // Retrieve an AbilityTargetTypeDetailEng using the specified ID
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngService.GetById(id: request.GetByIdAbilityTargetTypeDetailEngDto.Id);

        // Map the retrieved AbilityTargetTypeDetailEng to a GetByIdAbilityTargetTypeDetailEngCommandResponse using the mapper
        GetByIdAbilityTargetTypeDetailEngCommandResponse mappedResponse = _mapper.Map<GetByIdAbilityTargetTypeDetailEngCommandResponse>(abilityTargetTypeDetailEng);

        // Return the mapped response
        return mappedResponse;

    }
}
