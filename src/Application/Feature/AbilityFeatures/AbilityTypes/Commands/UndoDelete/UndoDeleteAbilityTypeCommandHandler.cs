using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.UndoDelete;

public class UndoDeleteAbilityTypeCommandHandler : IRequestHandler<UndoDeleteAbilityTypeCommandRequest, UndoDeleteAbilityTypeCommandResponse>
{
    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityTypeCommandHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityTypeCommandResponse> Handle(UndoDeleteAbilityTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityTypeDto.Id);

        AbilityType abilityType = await _abilityTypeService.GetById(request.UndoDeleteAbilityTypeDto.Id);
        abilityType.IsDeleted = false;
        abilityType.UpdatedDate = DateTime.Now;

        await _abilityTypeService.Update(abilityType);

        UndoDeleteAbilityTypeCommandResponse mappedResponse = _mapper.Map<UndoDeleteAbilityTypeCommandResponse>(abilityType);
        return mappedResponse;
    }
}
