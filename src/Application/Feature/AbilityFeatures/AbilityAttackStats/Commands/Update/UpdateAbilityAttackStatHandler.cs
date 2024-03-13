using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Update;

public class UpdateAbilityAttackStatHandler : IRequestHandler<UpdateAbilityAttackStatRequest, UpdateAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityAttackStatResponse> Handle(UpdateAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.UpdateAbilityAttackStatDto.Id);

        // Retrieve the AbilityAttackStat associated with the provided ID from the service.
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.UpdateAbilityAttackStatDto.Id);

        // Map properties from the request DTO to the existing AbilityAttackStat.
        _mapper.Map(request.UpdateAbilityAttackStatDto, abilityAttackStat);

        // Update the 'UpdatedDate' property to the current date and time.
        abilityAttackStat.UpdatedDate = DateTime.Now;

        // Update the AbilityAttackStat in the database.
        await _abilityAttackStatService.Update(abilityAttackStat);

        // Map the updated AbilityAttackStat to the response DTO.
        UpdateAbilityAttackStatResponse mappedResponse = _mapper.Map<UpdateAbilityAttackStatResponse>(abilityAttackStat);

        // Return the mapped response.
        return mappedResponse;


    }
}
