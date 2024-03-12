using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.UndoDelete;

public class UndoDeleteAbilityEffectHandler : IRequestHandler<UndoDeleteAbilityEffectRequest, UndoDeleteAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEffectResponse> Handle(UndoDeleteAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before proceeding with the undo delete operation.
        await _abilityEffectBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEffectDto.Id);

        // Retrieve the AbilityEffect entity by ID.
        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.UndoDeleteAbilityEffectDto.Id);

        // Undo the delete by marking IsDeleted as false and updating the UpdatedDate.
        abilityEffect.IsDeleted = false;
        abilityEffect.UpdatedDate = DateTime.Now;

        // Update the AbilityEffect in the service.
        await _abilityEffectService.Update(abilityEffect);

        // Map the undone AbilityEffect to the response DTO.
        UndoDeleteAbilityEffectResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEffectResponse>(abilityEffect);

        // Return the mapped response.
        return mappedResponse;

    }
}
