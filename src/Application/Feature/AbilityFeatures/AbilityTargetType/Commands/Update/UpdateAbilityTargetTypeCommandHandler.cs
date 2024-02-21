using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Update;

public class UpdateAbilityTargetTypeCommandHandler : IRequestHandler<UpdateAbilityTargetTypeCommandRequest, UpdateAbilityTargetTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public UpdateAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<UpdateAbilityTargetTypeCommandResponse> Handle(UpdateAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityTargetTypeBusinessRules.IdShouldBeExist(id: request.UpdateAbilityTargetTypeDto.Id);      

        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeService.GetById(id: request.UpdateAbilityTargetTypeDto.Id);      
        
        abilityTargetType.Name = request.UpdateAbilityTargetTypeDto.Name;
        abilityTargetType.Description = request.UpdateAbilityTargetTypeDto.Description;
 
        await _abilityTargetTypeService.Update(abilityTargetType);        

        UpdateAbilityTargetTypeCommandResponse mappedResponse = _mapper.Map<UpdateAbilityTargetTypeCommandResponse>(abilityTargetType);      
        
        return mappedResponse;

    }
}
