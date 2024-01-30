using Application.Feature.AbilityFeatures.AbilityLevel.Rules;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.ChangeStatus;

public class ChangeStatusAbilityLevelCommandHandler : IRequestHandler<ChangeStatusAbilityLevelCommandRequest, ChangeStatusAbilityLevelCommandResponse>
{
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IMapper _mapper;
    private readonly AbilityLevelBusinessRules _abilityLevelBusinessRules;

    public ChangeStatusAbilityLevelCommandHandler(IAbilityLevelService abilityLevelService, IMapper mapper, AbilityLevelBusinessRules abilityLevelBusinessRules)
    {
        _abilityLevelService = abilityLevelService;
        _mapper = mapper;
        _abilityLevelBusinessRules = abilityLevelBusinessRules;
    }

    public async Task<ChangeStatusAbilityLevelCommandResponse> Handle(ChangeStatusAbilityLevelCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists in the business rules for AbilityLevel status change.
        await _abilityLevelBusinessRules.IdShouldBeExist(id: request.ChangeStatusAbilityLevelDto.Id);

        // Retrieve the AbilityLevel using the provided ID.
        Domain.Abilities.AbilityLevel abilityLevel = await _abilityLevelService.GetById(id: request.ChangeStatusAbilityLevelDto.Id);

        // Toggle the status of the AbilityLevel (if it's true, set it to false, and vice versa).
        abilityLevel.Status = abilityLevel.Status == true ? false : true;

        // Update the UpdatedDate property of the AbilityLevel to the current date and time.
        abilityLevel.UpdatedDate = DateTime.Now;

        // Update the AbilityLevel in the database.
        await _abilityLevelService.Update(abilityLevel);

        // Map the updated AbilityLevel to a response object.
        ChangeStatusAbilityLevelCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityLevelCommandResponse>(abilityLevel);

        // Return the mapped response.
        return mappedResponse;


    }
}
