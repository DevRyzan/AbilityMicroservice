using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Delete;

public class DeleteAbilityAttackStatHandler : IRequestHandler<DeleteAbilityAttackStatRequest, DeleteAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityAttackStatResponse> Handle(DeleteAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.DeleteAbilityAttackStatDto.Id);

        // Retrieve the AbilityAttackStat associated with the provided ID from the service.
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.DeleteAbilityAttackStatDto.Id);

        // Set IsDeleted to true, indicating that the record is flagged as deleted.
        abilityAttackStat.IsDeleted = true;

        // Set Status to false, indicating that the record is no longer active.
        abilityAttackStat.Status = false;

        // Set the deletion timestamp for the AbilityAttackStat.
        abilityAttackStat.DeletedDate = DateTime.Now;

        // Delete the AbilityAttackStat in the database using the service.
        await _abilityAttackStatService.Delete(abilityAttackStat);

        // Map the deleted AbilityAttackStat to the response DTO.
        DeleteAbilityAttackStatResponse mappedResponse = _mapper.Map<DeleteAbilityAttackStatResponse>(abilityAttackStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
