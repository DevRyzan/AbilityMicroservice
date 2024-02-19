using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;

public class CreateAbilityComboCommandHandler : IRequestHandler<CreateAbilityComboCommandRequest, CreateAbilityComboCommandResponse>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityComboCommandHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityComboCommandResponse> Handle(CreateAbilityComboCommandRequest request, CancellationToken cancellationToken)
    {
        //// Generate a unique random code for the AbilityCombo.
        //RandomCodeGenerator code = new RandomCodeGenerator();

        //// Create a new AbilityCombo instance with properties from the request and some default values.
        //Domain.Abilities.AbilityCombo abilityCombo = new Domain.Abilities.AbilityCombo
        //{
        //    ComboNumber = request.CreateAbilityComboDto.ComboNumber,
        //    IconUrl = request.CreateAbilityComboDto.IconUrl,
        //    Status = true,
        //    IsDeleted = false,
        //    CreatedDate = DateTime.Now,
        //    Code = code.GenerateUniqueCode()
        //};

        //// Create the AbilityCombo in the database.
        //await _abilityComboService.Create(abilityCombo);

        //// Map the created AbilityCombo to a response object.
        //CreateAbilityComboCommandResponse mappedResponse = _mapper.Map<CreateAbilityComboCommandResponse>(abilityCombo);

        //// Return the mapped response.
        //return mappedResponse;

        throw new NotImplementedException();


    }
}
