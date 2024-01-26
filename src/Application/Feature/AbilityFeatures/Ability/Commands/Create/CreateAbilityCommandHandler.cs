using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Create;

public class CreateAbilityCommandHandler : IRequestHandler<CreateAbilityCommandRequest, CreateAbilityCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityService _abilityService;

    public CreateAbilityCommandHandler(IMapper mapper, IAbilityService abilityService)
    {
        _mapper = mapper;
        _abilityService = abilityService;
    }

    public async Task<CreateAbilityCommandResponse> Handle(CreateAbilityCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Abilities.Ability ability = _mapper.Map<Domain.Abilities.Ability>(request);

        ability.Status = true;
        ability.IsDeleted = false;

        ability.CreatedDate = DateTime.Now;


        await _abilityService.Create(ability);


        CreateAbilityCommandResponse mappedResponse = _mapper.Map<CreateAbilityCommandResponse>(ability);

        return mappedResponse;
    }
}
