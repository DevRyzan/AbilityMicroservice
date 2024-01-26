using Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using Application.Service.AbilityServices.AbilityCategoryService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Delete;

public class DeleteAbilityCategoryCommandHandler : IRequestHandler<DeleteAbilityCategoryCommandRequest, DeletedAbilityCategoryCommandResponse>
{
    private readonly IAbilityCategoryService _abilityCategoryService;
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEng;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRule;

    public DeleteAbilityCategoryCommandHandler(IAbilityCategoryService abilityCategoryService, IAbilityCategoryDetailEngService abilityCategoryDetailEng, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRule)
    {
        _abilityCategoryService = abilityCategoryService;
        _abilityCategoryDetailEng = abilityCategoryDetailEng;
        _mapper = mapper;
        _abilityCategoryBusinessRule = abilityCategoryBusinessRule;
    }

    public async Task<DeletedAbilityCategoryCommandResponse> Handle(DeleteAbilityCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.GetById(request.Id);

        abilityCategory.Status = false;
        abilityCategory.IsDeleted = false;

        abilityCategory.UpdatedDate = DateTime.UtcNow;

        await _abilityCategoryService.Update(abilityCategory);

        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEng.GetByAbilityId(abilityId: abilityCategory.Id);
        abilityCategoryDetailEng.Status = abilityCategory.Status;
        abilityCategoryDetailEng.IsDeleted = abilityCategory.IsDeleted;
        abilityCategory.UpdatedDate = abilityCategory.UpdatedDate;

        await _abilityCategoryDetailEng.Update(abilityCategoryDetailEng);


        DeletedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<DeletedAbilityCategoryCommandResponse>(abilityCategory);

        return mappedResponse;
    }
}
