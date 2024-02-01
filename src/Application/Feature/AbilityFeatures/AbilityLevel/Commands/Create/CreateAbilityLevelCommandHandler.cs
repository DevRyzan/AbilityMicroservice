using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Create;

public class CreateAbilityLevelCommandHandler : IRequestHandler<CreateAbilityLevelCommandRequest, CreateAbilityLevelCommandResponse>
{
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IMapper _mapper;

    public CreateAbilityLevelCommandHandler(IAbilityLevelService abilityLevelService, IMapper mapper)
    {
        _abilityLevelService = abilityLevelService;
        _mapper = mapper;
    }

    public async Task<CreateAbilityLevelCommandResponse> Handle(CreateAbilityLevelCommandRequest request, CancellationToken cancellationToken)
    {
        // Map the data from the request's CreateAbilityLevelDto to a new AbilityLevel instance.
        Domain.Abilities.AbilityLevel abilityLevel = _mapper.Map<Domain.Abilities.AbilityLevel>(request.CreateAbilityLevelDto);

        RandomCodeGenerator code = new RandomCodeGenerator();

        // Set default values for the new AbilityLevel.
        abilityLevel.Status = true;
        abilityLevel.IsDeleted = false;
        abilityLevel.CreatedDate = DateTime.Now;
        abilityLevel.Code = code.GenerateUniqueCode();

        // Create the new AbilityLevel in the database.
        await _abilityLevelService.Create(abilityLevel);

        // Map the created AbilityLevel to a response object.
        CreateAbilityLevelCommandResponse mappedResponse = _mapper.Map<CreateAbilityLevelCommandResponse>(abilityLevel);

        // Return the mapped response.
        return mappedResponse;

    }
}
