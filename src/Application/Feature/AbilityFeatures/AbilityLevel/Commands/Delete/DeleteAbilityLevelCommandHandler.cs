using Application.Feature.AbilityFeatures.AbilityLevel.Rules;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Delete;

public class DeleteAbilityLevelCommandHandler : IRequestHandler<DeleteAbilityLevelCommandRequest, DeleteAbilityLevelCommandResponse>
{
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IMapper _mapper;
    private readonly AbilityLevelBusinessRules _abilityLevelBusinessRules;

    public DeleteAbilityLevelCommandHandler(IAbilityLevelService abilityLevelService, IMapper mapper, AbilityLevelBusinessRules abilityLevelBusinessRules)
    {
        _abilityLevelService = abilityLevelService;
        _mapper = mapper;
        _abilityLevelBusinessRules = abilityLevelBusinessRules;
    }

    public async Task<DeleteAbilityLevelCommandResponse> Handle(DeleteAbilityLevelCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists in the business rules for AbilityLevel deletion.
        await _abilityLevelBusinessRules.IdShouldBeExist(id: request.DeleteAbilityLevelDto.Id);

        // Retrieve the AbilityLevel using the provided ID.
        Domain.Abilities.AbilityLevel abilityLevel = await _abilityLevelService.GetById(id: request.DeleteAbilityLevelDto.Id);

        // Set the Status to false, mark the AbilityLevel as deleted, and record the deletion date.
        abilityLevel.Status = false;
        abilityLevel.IsDeleted = true;
        abilityLevel.DeletedDate = DateTime.Now;

        // Update the AbilityLevel in the database.
        await _abilityLevelService.Update(abilityLevel);

        // Map the deleted AbilityLevel to a response object.
        DeleteAbilityLevelCommandResponse mappedResponse = _mapper.Map<DeleteAbilityLevelCommandResponse>(abilityLevel);

        // Return the mapped response.
        return mappedResponse;

    }
}
