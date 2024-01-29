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
        // Check if the specified ID exists in the business rules for AbilityCategory deletion.
        await _abilityCategoryBusinessRule.IdShouldBeExist(id: request.AbilityCategoryDeleteDto.Id);

        // Retrieve the AbilityCategory using the provided ID.
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.GetById(request.AbilityCategoryDeleteDto.Id);

        // Set the Status to false and mark the AbilityCategory as deleted.
        abilityCategory.Status = false;
        abilityCategory.IsDeleted = true;

        // Update the UpdatedDate property of the AbilityCategory to the current UTC time.
        abilityCategory.UpdatedDate = DateTime.UtcNow;

        // Update the AbilityCategory in the database.
        await _abilityCategoryService.Update(abilityCategory);

        // Retrieve the corresponding AbilityCategoryDetailEng using the AbilityCategory's ID.
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEng.GetByAbilityId(abilityId: abilityCategory.Id);

        // Update the Status and IsDeleted properties of the AbilityCategoryDetailEng to match the AbilityCategory.
        abilityCategoryDetailEng.Status = abilityCategory.Status;
        abilityCategoryDetailEng.IsDeleted = abilityCategory.IsDeleted;
        abilityCategory.UpdatedDate = abilityCategory.UpdatedDate;

        // Update the AbilityCategoryDetailEng in the database.
        await _abilityCategoryDetailEng.Update(abilityCategoryDetailEng);

        // Map the deleted AbilityCategory to a response object.
        DeletedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<DeletedAbilityCategoryCommandResponse>(abilityCategory);

        // Return the mapped response.
        return mappedResponse;

    }
}
