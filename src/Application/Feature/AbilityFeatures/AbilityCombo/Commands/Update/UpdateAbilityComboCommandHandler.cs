using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Update;

public class UpdateAbilityComboCommandHandler : IRequestHandler<UpdateAbilityComboCommandRequest, UpdateAbilityComboCommandResponse>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityComboCommandHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityComboCommandResponse> Handle(UpdateAbilityComboCommandRequest request, CancellationToken cancellationToken)
    {
        //// Check if the specified ID exists in the business rules for AbilityCombo update.
        //await _abilityComboBusinessRules.IdShouldBeExist(id: request.UpdateAbilityComboDto.Id);

        //// Retrieve the AbilityCombo using the provided ID.
        //Domain.Abilities.AbilityCombo abilityCombo = await _abilityComboService.GetById(request.UpdateAbilityComboDto.Id);

        //// Update the IconUrl, ComboNumber, and UpdatedDate properties of the AbilityCombo.
        //abilityCombo.IconUrl = request.UpdateAbilityComboDto.IconUrl;
        //abilityCombo.ComboNumber = request.UpdateAbilityComboDto.ComboNumber;
        //abilityCombo.UpdatedDate = DateTime.Now;

        //// Update the AbilityCombo in the database.
        //await _abilityComboService.Update(abilityCombo);

        //// Map the updated AbilityCombo to a response object.
        //UpdateAbilityComboCommandResponse mappedResponse = _mapper.Map<UpdateAbilityComboCommandResponse>(abilityCombo);

        //// Return the mapped response.
        //return mappedResponse;

        throw new NotImplementedException();


    }
}
