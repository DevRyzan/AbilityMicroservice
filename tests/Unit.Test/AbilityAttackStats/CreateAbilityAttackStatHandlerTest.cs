using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAttackStats;

public class CreateAbilityAttackStatHandlerTest
{
    public static IEnumerable<object[]> CreateCreateAbilityAttackStatDtoTestData()
    {
        yield return new object[] { new CreateAbilityAttackStatDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAttackStatService> _abilityAttackStatServiceMock;
    private readonly Mock<IAbilityAttackStatRepository> _abilityAttackStatRepositoryMock;
    private readonly Mock<AbilityAttackStatBusinessRules> _abilityAttackStatBusinessRulesMock;

    public CreateAbilityAttackStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAttackStatBusinessRulesMock = new Mock<AbilityAttackStatBusinessRules>();
        _abilityAttackStatServiceMock = new Mock<IAbilityAttackStatService>();
        _abilityAttackStatRepositoryMock = new Mock<IAbilityAttackStatRepository>();
    }

    [Theory]
    [MemberData(nameof(CreateCreateAbilityAttackStatDtoTestData))]
    public async Task AbilityActivationType_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityAttackStatDto createAbilityAttackStatDto)
    {
        var businessRuleMock = new Mock<AbilityAttackStatBusinessRules>(_abilityAttackStatRepositoryMock.Object);

        var handler = new CreateAbilityAttackStatHandler(_abilityAttackStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new CreateAbilityAttackStatRequest
        {
            CreateAbilityAttackStatDto = createAbilityAttackStatDto
        };

        var abilityAttackStat = new AbilityAttackStat
        {
            Id = ObjectId.GenerateNewId().ToString(),
            AbilityLevelId = request.CreateAbilityAttackStatDto.AbilityLevelId
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityAttackStatDto, abilityAttackStat));

        var expectedResponse = new CreateAbilityAttackStatResponse
        {
            Id = abilityAttackStat.Id,
            AbilityLevelId = request.CreateAbilityAttackStatDto.AbilityLevelId
        };

        _mapperMock.Setup(m => m.Map<AbilityAttackStat>(request.CreateAbilityAttackStatDto))
                   .Returns(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.Create(abilityAttackStat))
                                    .ReturnsAsync(abilityAttackStat);

        _mapperMock.Setup(m => m.Map<CreateAbilityAttackStatResponse>(abilityAttackStat))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityAttackStatServiceMock.Verify(m => m.Create(abilityAttackStat), Times.Once);
    }
}
