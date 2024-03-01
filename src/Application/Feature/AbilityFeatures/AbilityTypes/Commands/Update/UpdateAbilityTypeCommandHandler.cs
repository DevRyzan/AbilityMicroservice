using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.Update;

public class UpdateAbilityTypeCommandHandler : IRequestHandler<UpdateAbilityTypeCommandRequest, UpdateAbilityTypeCommandResponse>
{

    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityTypeCommandHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityTypeCommandResponse> Handle(UpdateAbilityTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityTypeDto.Id);

        AbilityType abilityType = await _abilityTypeService.GetById(request.UpdateAbilityTypeDto.Id);
        abilityType.Name = request.UpdateAbilityTypeDto.Name;
        abilityType.Description = request.UpdateAbilityTypeDto.Description;

        abilityType.UpdatedDate = DateTime.Now;
        await _abilityTypeService.Update(abilityType);

        UpdateAbilityTypeCommandResponse mappedResponse = _mapper.Map<UpdateAbilityTypeCommandResponse>(abilityType);
        return mappedResponse;
    }
}
