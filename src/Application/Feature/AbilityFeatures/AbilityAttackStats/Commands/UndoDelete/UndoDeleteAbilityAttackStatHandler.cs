using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.UndoDelete;

public class UndoDeleteAbilityAttackStatHandler : IRequestHandler<UndoDeleteAbilityAttackStatRequest, UndoDeleteAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityAttackStatResponse> Handle(UndoDeleteAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityAttackStatDto.Id);

        // Retrieve the AbilityAttackStat associated with the provided ID from the service.
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.UndoDeleteAbilityAttackStatDto.Id);

        // Set the 'IsDeleted' flag to false, indicating the undo of the deletion.
        abilityAttackStat.IsDeleted = false;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityAttackStat.UpdatedDate = DateTime.Now;

        // Update the AbilityAttackStat in the database.
        await _abilityAttackStatService.Update(abilityAttackStat);

        // Map the updated AbilityAttackStat to the response DTO.
        UndoDeleteAbilityAttackStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilityAttackStatResponse>(abilityAttackStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
