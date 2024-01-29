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
        // Check if the specified ID exists in the business rules for AbilityCategory update.
        await _abilityCategoryBusinessRule.IdShouldBeExist(request.AbilityCategoryUpdateDto.Id);

        // Retrieve the AbilityCategoryDetailEng using the provided ID.
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEng.GetByAbilityId(abilityId: request.AbilityCategoryUpdateDto.Id);

        // Update the Name, Description, and UpdatedDate properties of the AbilityCategoryDetailEng.
        abilityCategoryDetailEng.Name = request.AbilityCategoryUpdateDto.Name;
        abilityCategoryDetailEng.Description = request.AbilityCategoryUpdateDto.Description;
        abilityCategoryDetailEng.UpdatedDate = DateTime.Now;

        // Update the AbilityCategoryDetailEng in the database.
        await _abilityCategoryDetailEng.Update(abilityCategoryDetailEng);

        // Map the updated AbilityCategoryDetailEng to a response object.
        UpdatedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<UpdatedAbilityCategoryCommandResponse>(abilityCategoryDetailEng);

        // Return the mapped response.
        return mappedResponse;

    }
}
