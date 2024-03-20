using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityCombos;

public class CreateAbilityComboHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityComboDtoTestData()
    {
        yield return new object[] { new CreateAbilityComboDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityComboService> _abilityComboServiceMock;
    private readonly Mock<IAbilityComboRepository> _abilityComboRepositoryMock;
    private readonly Mock<AbilityComboBusinessRules> _abilityComboBusinessRulesMock;

    public CreateAbilityComboHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityComboServiceMock = new Mock<IAbilityComboService>();
        _abilityComboRepositoryMock = new Mock<IAbilityComboRepository>();
        _abilityComboBusinessRulesMock = new Mock<AbilityComboBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityComboDtoTestData))]
    public async Task AbilityActivationType_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityComboDto createAbilityComboDto)
    {
        var businessRuleMock = new Mock<AbilityComboBusinessRules>(_abilityComboRepositoryMock.Object);

        var handler = new CreateAbilityComboCommandHandler(_abilityComboServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new CreateAbilityComboCommandRequest
        {
            CreateAbilityComboDto = createAbilityComboDto
        };

        var abilityCombo = new AbilityCombo
        {
            Id = ObjectId.GenerateNewId().ToString(),
            AbilityId = request.CreateAbilityComboDto.AbilityId
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityComboDto, abilityCombo));

        var expectedResponse = new CreateAbilityComboCommandResponse
        {
            Id = abilityCombo.Id,
            AbilityId = request.CreateAbilityComboDto.AbilityId
        };

        _mapperMock.Setup(m => m.Map<AbilityCombo>(request.CreateAbilityComboDto))
                   .Returns(abilityCombo);

        _abilityComboServiceMock.Setup(m => m.Create(abilityCombo))
                                    .ReturnsAsync(abilityCombo);

        _mapperMock.Setup(m => m.Map<CreateAbilityComboCommandResponse>(abilityCombo))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityComboServiceMock.Verify(m => m.Create(abilityCombo), Times.Once);
    }
}
