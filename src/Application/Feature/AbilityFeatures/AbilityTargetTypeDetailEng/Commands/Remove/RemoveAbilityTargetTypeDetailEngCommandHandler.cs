using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Remove;

public class RemoveAbilityTargetTypeDetailEngCommandHandler : IRequestHandler<RemoveAbilityTargetTypeDetailEngCommandRequest, RemoveAbilityTargetTypeDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityTargetTypeDetailEngService _abilityTargetTypeDetailEngService;
    private readonly AbilityTargetTypeDetailEngBusinessRules _abilityTargetTypeDetailEngBusinessRules;

    public RemoveAbilityTargetTypeDetailEngCommandHandler(IMapper mapper, IAbilityTargetTypeDetailEngService abilityTargetTypeDetailEngService, AbilityTargetTypeDetailEngBusinessRules abilityTargetTypeDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityTargetTypeDetailEngService = abilityTargetTypeDetailEngService;
        _abilityTargetTypeDetailEngBusinessRules = abilityTargetTypeDetailEngBusinessRules;
    }

    public async Task<RemoveAbilityTargetTypeDetailEngCommandResponse> Handle(RemoveAbilityTargetTypeDetailEngCommandRequest request, CancellationToken cancellationToken)
    {

        // Apply additional business rules for removing the ability target type detail (English)
        await _abilityTargetTypeDetailEngBusinessRules.RemoveCondition(id: request.RemoveAbilityTargetTypeDetailEngDto.Id);

        // Check if the specified ability target type detail (English) ID exists, applying business rules
        await _abilityTargetTypeDetailEngBusinessRules.IdShouldBeExist(id: request.RemoveAbilityTargetTypeDetailEngDto.Id);

        // Retrieve an AbilityTargetTypeDetailEng using the specified ID
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngService.GetById(id: request.RemoveAbilityTargetTypeDetailEngDto.Id);

        // Call the Remove method of _abilityTargetTypeDetailEngService to remove the AbilityTargetTypeDetailEng
        await _abilityTargetTypeDetailEngService.Remove(abilityTargetTypeDetailEng);

        // Map the removed AbilityTargetTypeDetailEng to a RemoveAbilityTargetTypeDetailEngCommandResponse using the mapper
        RemoveAbilityTargetTypeDetailEngCommandResponse mappedResponse = _mapper.Map<RemoveAbilityTargetTypeDetailEngCommandResponse>(abilityTargetTypeDetailEng);

        // Return the mapped response
        return mappedResponse;


    }
}
