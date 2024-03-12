using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.ChangeStatus;

public class ChangeStatusAbilityAttackStatHandler : IRequestHandler<ChangeStatusAbilityAttackStatRequest, ChangeStatusAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityAttackStatResponse> Handle(ChangeStatusAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityAttackStatDto.Id);

        // Retrieve the AbilityAttackStat associated with the provided ID from the service.
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.ChangeStatusAbilityAttackStatDto.Id);

        // Toggle the status of the retrieved AbilityAttackStat (switch between true and false).
        abilityAttackStat.Status = abilityAttackStat.Status == true ? false : true;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityAttackStat.UpdatedDate = DateTime.Now;

        // Update the AbilityAttackStat in the database.
        await _abilityAttackStatService.Update(abilityAttackStat);

        // Map the updated AbilityAttackStat to the response DTO.
        ChangeStatusAbilityAttackStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityAttackStatResponse>(abilityAttackStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
