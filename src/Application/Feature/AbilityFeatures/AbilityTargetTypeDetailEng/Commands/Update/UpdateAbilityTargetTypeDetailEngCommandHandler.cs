using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Update;

public class UpdateAbilityTargetTypeDetailEngCommandHandler : IRequestHandler<UpdateAbilityTargetTypeDetailEngCommandRequest, UpdateAbilityTargetTypeDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityTargetTypeDetailEngService _abilityTargetTypeDetailEngService;
    private readonly AbilityTargetTypeDetailEngBusinessRules _abilityTargetTypeDetailEngBusinessRules;

    public UpdateAbilityTargetTypeDetailEngCommandHandler(IMapper mapper, IAbilityTargetTypeDetailEngService abilityTargetTypeDetailEngService, AbilityTargetTypeDetailEngBusinessRules abilityTargetTypeDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityTargetTypeDetailEngService = abilityTargetTypeDetailEngService;
        _abilityTargetTypeDetailEngBusinessRules = abilityTargetTypeDetailEngBusinessRules;
    }

    public async Task<UpdateAbilityTargetTypeDetailEngCommandResponse> Handle(UpdateAbilityTargetTypeDetailEngCommandRequest request, CancellationToken cancellationToken)
    {

        await _abilityTargetTypeDetailEngBusinessRules.IdShouldBeExist(id: request.UpdateAbilityTargetTypeDetailEngDto.Id);
        await _abilityTargetTypeDetailEngBusinessRules.AbilityTargetTypeShouldBeAvailableForUpdate(abilityTargetTypeId: request.UpdateAbilityTargetTypeDetailEngDto.AbilityTargetTypeId, Id: request.UpdateAbilityTargetTypeDetailEngDto.Id);

        await _abilityTargetTypeDetailEngBusinessRules.AbilityTargetTypeShouldBeExist(abilityTargetTypeId: request.UpdateAbilityTargetTypeDetailEngDto.AbilityTargetTypeId);

        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngService.GetById(id: request.UpdateAbilityTargetTypeDetailEngDto.Id);

        abilityTargetTypeDetailEng.AbilityTargetTypeId = abilityTargetTypeDetailEng.AbilityTargetTypeId;
        abilityTargetTypeDetailEng.Name = request.UpdateAbilityTargetTypeDetailEngDto.Name;
        abilityTargetTypeDetailEng.Description = request.UpdateAbilityTargetTypeDetailEngDto.Description;
        abilityTargetTypeDetailEng.UpdatedDate = DateTime.Now;

        UpdateAbilityTargetTypeDetailEngCommandResponse mappedResponse = _mapper.Map<UpdateAbilityTargetTypeDetailEngCommandResponse>(abilityTargetTypeDetailEng);

        return mappedResponse;
    }
}
