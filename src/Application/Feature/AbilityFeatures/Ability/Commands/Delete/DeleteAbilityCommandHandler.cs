using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Delete;

public class DeleteAbilityCommandHandler : IRequestHandler<DeleteAbilityCommandRequest, DeleteAbilityCommandResponse>
{
    private readonly IAbilityService _abilityService;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityCommandHandler(IAbilityService abilityService, AbilityBusinessRules abilityBusinessRules, IMapper mapper)
    {
        _abilityService = abilityService;
        _abilityBusinessRules = abilityBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityCommandResponse> Handle(DeleteAbilityCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability ID exists, applying business rules
        await _abilityBusinessRules.IdShouldBeExist(id: request.DeleteAbilityDto.Id);

        // Retrieve an Ability using the specified ID
        Domain.Abilities.Ability ability = await _abilityService.GetById(id: request.DeleteAbilityDto.Id);

        // Update the properties of the Ability to mark it as deleted
        ability.Status = false;
        ability.IsDeleted = true;
        ability.DeletedDate = DateTime.Now;

        // Call the Update method of _abilityService to update the Ability
        await _abilityService.Update(ability);

        // Map the updated Ability to a DeleteAbilityCommandResponse using the mapper
        DeleteAbilityCommandResponse mappedResponse = _mapper.Map<DeleteAbilityCommandResponse>(ability);

        // Return the mapped response
        return mappedResponse;

    }
}
