using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using Application.Service.AbilityServices.AbilityCategoryService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Update;

public class UpdateAbilityCategoryCommandHandler : IRequestHandler<UpdateAbilityCategoryCommandRequest, UpdatedAbilityCategoryCommandResponse>
{
    private readonly IAbilityCategoryService _abilityCategoryService;
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEng;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRule;

    public UpdateAbilityCategoryCommandHandler(IAbilityCategoryService abilityCategoryService, IAbilityCategoryDetailEngService abilityCategoryDetailEng, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRule)
    {
        _abilityCategoryService = abilityCategoryService;
        _abilityCategoryDetailEng = abilityCategoryDetailEng;
        _mapper = mapper;
        _abilityCategoryBusinessRule = abilityCategoryBusinessRule;
    }

    public async Task<UpdatedAbilityCategoryCommandResponse> Handle(UpdateAbilityCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityCategoryBusinessRule.IdShouldBeExist(request.Id);

        // Retrieve the Ability Category object by its ID.
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEng.GetByAbilityId(abilityId:request.Id);

        abilityCategoryDetailEng.Name = request.Name;
        abilityCategoryDetailEng.Description = request.Description;
        abilityCategoryDetailEng.UpdatedDate = DateTime.Now;

         await _abilityCategoryDetailEng.Update(abilityCategoryDetailEng);

        UpdatedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<UpdatedAbilityCategoryCommandResponse>(abilityCategoryDetailEng);

        // Return the mapped response object.
        return mappedResponse;

    }
}
