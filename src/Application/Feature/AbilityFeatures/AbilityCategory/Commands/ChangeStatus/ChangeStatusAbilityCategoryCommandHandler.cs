using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using Application.Service.AbilityServices.AbilityCategoryService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;

public class ChangeStatusAbilityCategoryCommandHandler : IRequestHandler<ChangeStatusAbilityCategoryCommandRequest, ChangeStatusAbilityCategoryCommandResponse>
{
    private readonly IAbilityCategoryService _abilityCategoryService;
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEng;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public ChangeStatusAbilityCategoryCommandHandler(IAbilityCategoryService abilityCategoryService, IAbilityCategoryDetailEngService abilityCategoryDetailEng, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryService = abilityCategoryService;
        _abilityCategoryDetailEng = abilityCategoryDetailEng;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<ChangeStatusAbilityCategoryCommandResponse> Handle(ChangeStatusAbilityCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists in the business rules for AbilityCategory.
        await _abilityCategoryBusinessRules.IdShouldBeExist(id: request.AbilityCategoryChangeStatusDto.Id);

        // Retrieve the AbilityCategory using the provided ID.
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.GetById(request.AbilityCategoryChangeStatusDto.Id);

        // Toggle the status of the AbilityCategory (if it's true, set it to false, and vice versa).
        abilityCategory.Status = abilityCategory.Status == true ? false : true;

        // Update the UpdatedDate property of the AbilityCategory to the current UTC time.
        abilityCategory.UpdatedDate = DateTime.UtcNow;

        // Update the AbilityCategory in the database.
        await _abilityCategoryService.Update(abilityCategory);

        // Retrieve the corresponding AbilityCategoryDetailEng using the AbilityCategory's ID.
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEng.GetByAbilityId(abilityId: abilityCategory.Id);

        // Update the status of the AbilityCategoryDetailEng with the status of the AbilityCategory.
        abilityCategoryDetailEng.Status = abilityCategory.Status;

        // Update the UpdatedDate property of the AbilityCategoryDetailEng to match the AbilityCategory.
        abilityCategory.UpdatedDate = abilityCategory.UpdatedDate;

        // Update the AbilityCategoryDetailEng in the database.
        await _abilityCategoryDetailEng.Update(abilityCategoryDetailEng);

        // Map the updated AbilityCategory to a response object.
        ChangeStatusAbilityCategoryCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityCategoryCommandResponse>(abilityCategory);

        // Return the mapped response.
        return mappedResponse;


    }
}
