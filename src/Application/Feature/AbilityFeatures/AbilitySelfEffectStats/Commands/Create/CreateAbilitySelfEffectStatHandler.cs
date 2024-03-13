using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Create;

public class CreateAbilitySelfEffectStatHandler : IRequestHandler<CreateAbilitySelfEffectStatRequest, CreateAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilitySelfEffectStatResponse> Handle(CreateAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Create an instance of RandomCodeGenerator for generating unique codes
        RandomCodeGenerator randomCodeGenerator = new();

        // Map the request DTO to an AbilitySelfEffectStat entity
        AbilitySelfEffectStat abilitySelfEffectStat = _mapper.Map<AbilitySelfEffectStat>(request.CreateAbilitySelfEffectStatDto);

        // Generate a new unique ID for the AbilitySelfEffectStat
        abilitySelfEffectStat.Id = ObjectId.GenerateNewId().ToString();

        // Set the initial status, deletion status, and generate a unique code
        abilitySelfEffectStat.Status = true;
        abilitySelfEffectStat.IsDeleted = false;
        abilitySelfEffectStat.Code = randomCodeGenerator.GenerateUniqueCode();

        // Set the creation date to the current date and time
        abilitySelfEffectStat.CreatedDate = DateTime.Now;

        // Create the AbilitySelfEffectStat in the database
        await _abilitySelfEffectStatService.Create(abilitySelfEffectStat);

        // Map the created AbilitySelfEffectStat to the corresponding response DTO
        CreateAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<CreateAbilitySelfEffectStatResponse>(abilitySelfEffectStat);

        // Return the mapped response
        return mappedResponse;


    }
}
