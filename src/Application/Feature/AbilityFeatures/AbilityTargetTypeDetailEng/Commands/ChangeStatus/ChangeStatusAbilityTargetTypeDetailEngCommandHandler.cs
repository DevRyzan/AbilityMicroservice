using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.ChangeStatus;

public class ChangeStatusAbilityTargetTypeDetailEngCommandHandler : IRequestHandler<ChangeStatusAbilityTargetTypeDetailEngCommandRequest, ChangeStatusAbilityTargetTypeDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityTargetTypeDetailEngService _abilityTargetTypeDetailEngService;
    private readonly AbilityTargetTypeDetailEngBusinessRules _abilityTargetTypeDetailEngBusinessRules;

    public ChangeStatusAbilityTargetTypeDetailEngCommandHandler(IMapper mapper, IAbilityTargetTypeDetailEngService abilityTargetTypeDetailEngService, AbilityTargetTypeDetailEngBusinessRules abilityTargetTypeDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityTargetTypeDetailEngService = abilityTargetTypeDetailEngService;
        _abilityTargetTypeDetailEngBusinessRules = abilityTargetTypeDetailEngBusinessRules;
    }

    public async Task<ChangeStatusAbilityTargetTypeDetailEngCommandResponse> Handle(ChangeStatusAbilityTargetTypeDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability target type detail (English) ID exists, applying business rules
        await _abilityTargetTypeDetailEngBusinessRules.IdShouldBeExist(id: request.ChangeStatusAbilityTargetTypeDetailEngDto.Id);

        // Retrieve an AbilityTargetTypeDetailEng using the specified ID
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngService.GetById(id: request.ChangeStatusAbilityTargetTypeDetailEngDto.Id);

        // Toggle the Status property of the AbilityTargetTypeDetailEng
        abilityTargetTypeDetailEng.Status = abilityTargetTypeDetailEng.Status == true ? false : true;

        // Update the UpdatedDate property to the current date and time
        abilityTargetTypeDetailEng.UpdatedDate = DateTime.Now;

        // Call the Update method of _abilityTargetTypeDetailEngService to persist the changes
        await _abilityTargetTypeDetailEngService.Update(abilityTargetTypeDetailEng);

        // Map the updated AbilityTargetTypeDetailEng to a ChangeStatusAbilityTargetTypeDetailEngCommandResponse using the mapper
        ChangeStatusAbilityTargetTypeDetailEngCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityTargetTypeDetailEngCommandResponse>(abilityTargetTypeDetailEng);

        // Return the mapped response
        return mappedResponse;


    }
}
