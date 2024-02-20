using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Update;

public class UpdateAbilityCommandHandler : IRequestHandler<UpdateAbilityCommandRequest, UpdateAbilityCommandResponse>
{
    private readonly IAbilityService _abilityService;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityCommandHandler(IAbilityService abilityService, AbilityBusinessRules abilityBusinessRules, IMapper mapper)
    {
        _abilityService = abilityService;
        _abilityBusinessRules = abilityBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityCommandResponse> Handle(UpdateAbilityCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided Ability ID exists before attempting an update
        await _abilityBusinessRules.IdShouldBeExist(request.UpdateAbilityDto.Id);

        // Fetch the existing Ability from the service based on the provided ID
        Domain.Abilities.Ability ability = await _abilityService.GetById(request.UpdateAbilityDto.Id);

        // Update the properties of the existing Ability with the new data from the request
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<UpdateAbilityDto, Domain.Abilities.Ability>();
        });

        var mapper = config.CreateMapper();
        mapper.Map(request.UpdateAbilityDto, ability);

        // Update the 'UpdatedDate' property with the current date and time
        ability.UpdatedDate = DateTime.Now;

        // Perform the update operation in the _abilityService
        await _abilityService.Update(ability);

        // Map the updated Ability object to the response DTO
        UpdateAbilityCommandResponse mappedResponse = _mapper.Map<UpdateAbilityCommandResponse>(ability);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}
