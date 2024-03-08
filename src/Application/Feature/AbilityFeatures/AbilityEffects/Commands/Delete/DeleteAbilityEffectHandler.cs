using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Delete;

public class DeleteAbilityEffectHandler : IRequestHandler<DeleteAbilityEffectRequest, DeleteAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityEffectResponse> Handle(DeleteAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectBusinessRules.IdShouldBeExist(request.DeleteAbilityEffectDto.Id);

        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.DeleteAbilityEffectDto.Id);
        abilityEffect.IsDeleted = true;
        abilityEffect.Status = false;
        abilityEffect.DeletedDate = DateTime.Now;

        await _abilityEffectService.Delete(abilityEffect);

        DeleteAbilityEffectResponse mappedResponse = _mapper.Map<DeleteAbilityEffectResponse>(abilityEffect);
        return mappedResponse;
    }
}

