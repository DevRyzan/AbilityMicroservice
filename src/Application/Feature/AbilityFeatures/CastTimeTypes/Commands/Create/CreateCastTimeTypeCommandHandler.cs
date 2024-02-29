using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Create;

public class CreateCastTimeTypeCommandHandler : IRequestHandler<CreateCastTimeTypeCommandRequest, CreateCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateCastTimeTypeCommandResponse> Handle(CreateCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Create a new instance of the RandomCodeGenerator for generating unique codes
        RandomCodeGenerator randomCodeGenerator = new();

        // Map data from the incoming request DTO to a new CastTimeType object
        CastTimeType castTimeType = _mapper.Map<CastTimeType>(request.CreateCastTimeTypeDto);

        // Generate a new unique identifier for the CastTimeType
        castTimeType.Id = ObjectId.GenerateNewId().ToString();

        // Set default values for the new CastTimeType
        castTimeType.Status = true;          // Assuming 'Status' is a boolean property
        castTimeType.IsDeleted = false;      // Assuming 'IsDeleted' is a boolean property
        castTimeType.Code = randomCodeGenerator.GenerateUniqueCode();
        castTimeType.CreatedDate = DateTime.Now;  // Set the creation date to the current date and time

        // Create the new CastTimeType by calling the _castTimeTypeService
        await _castTimeTypeService.Create(castTimeType);

        // Map the created CastTimeType to the response DTO
        CreateCastTimeTypeCommandResponse mappedResponse = _mapper.Map<CreateCastTimeTypeCommandResponse>(castTimeType);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}
