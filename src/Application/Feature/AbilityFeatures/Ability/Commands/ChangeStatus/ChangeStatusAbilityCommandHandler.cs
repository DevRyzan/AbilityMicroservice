using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;

public class ChangeStatusAbilityCommandHandler : IRequestHandler<ChangeStatusAbilityCommandRequest, ChangeStatusAbilityCommandResponse>
{
    private readonly IAbilityService _abilityService;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityCommandHandler(IAbilityService abilityService, AbilityBusinessRules abilityBusinessRules, IMapper mapper)
    {
        _abilityService = abilityService;
        _abilityBusinessRules = abilityBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityCommandResponse> Handle(ChangeStatusAbilityCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the ability with the specified ID exists in the business rules.
        await _abilityBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityDto.Id);

        // Retrieve the ability entity from the service based on the provided ID.
        Domain.Abilities.Ability ability = await _abilityService.GetById(request.ChangeStatusAbilityDto.Id);

        // Toggle the status of the ability (if it's true, set it to false; if it's false, set it to true).
        ability.Status = ability.Status == true ? false : true;

        // Update the 'UpdatedDate' property of the ability to the current UTC time.
        ability.UpdatedDate = DateTime.Now;

        // Update the ability entity in the database using the ability service.
        await _abilityService.Update(ability);

        // Return a new object containing the updated ability ID and status.
        ChangeStatusAbilityCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityCommandResponse>(ability);

        return mappedResponse;
    }
}
