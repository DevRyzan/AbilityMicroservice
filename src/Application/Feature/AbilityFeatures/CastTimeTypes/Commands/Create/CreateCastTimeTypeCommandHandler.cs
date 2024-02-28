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
        RandomCodeGenerator randomCodeGenerator = new();

        CastTimeType castTimeType = _mapper.Map<CastTimeType>(request.CreateCastTimeTypeDto);
        castTimeType.Id = ObjectId.GenerateNewId().ToString();
        castTimeType.Status = true;
        castTimeType.IsDeleted = false;
        castTimeType.Code = randomCodeGenerator.GenerateUniqueCode();
        castTimeType.CreatedDate = DateTime.Now;

        await _castTimeTypeService.Create(castTimeType);

        CreateCastTimeTypeCommandResponse mappedResponse = _mapper.Map<CreateCastTimeTypeCommandResponse>(castTimeType);

        return mappedResponse;
    }
}
