using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEnemyEffectStats;

public class CreateAbilityEnemyEffectStatHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityEnemyEffectStatDtoTestData()
    {
        yield return new object[] { new CreateAbilityEnemyEffectStatDto {
            AbilityEffectStatsId = ObjectId.GenerateNewId().ToString(),
            EnemyCrowdControlReduction = 10
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEnemyEffectStatService> _abilityEnemyEffectStatServiceMock;
    private readonly Mock<IAbilityEnemyEffectStatRepository> _abilityEnemyEffectStatRepositoryMock;
    private readonly Mock<AbilityEnemyEffectStatBusinessRules> _abilityEnemyEffectStatBusinessRulesMock;

    public CreateAbilityEnemyEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEnemyEffectStatServiceMock = new Mock<IAbilityEnemyEffectStatService>();
        _abilityEnemyEffectStatRepositoryMock = new Mock<IAbilityEnemyEffectStatRepository>();
        _abilityEnemyEffectStatBusinessRulesMock = new Mock<AbilityEnemyEffectStatBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityEnemyEffectStatDtoTestData))]
    public async Task AbilityEnemyEffectStat_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityEnemyEffectStatDto createAbilityEnemyEffectStatDto)
    {
        var businessRuleMock = new Mock<AbilityEnemyEffectStatBusinessRules>(_abilityEnemyEffectStatRepositoryMock.Object);

        var handler = new CreateAbilityEnemyEffectStatHandler(_abilityEnemyEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new CreateAbilityEnemyEffectStatRequest
        {
            CreateAbilityEnemyEffectStatDto = createAbilityEnemyEffectStatDto
        };

        var abilityEnemyEffectStat = new AbilityEnemyEffectStat
        {
            Id = ObjectId.GenerateNewId().ToString(),
            AbilityEffectStatsId = ObjectId.GenerateNewId().ToString(),
            EnemyCrowdControlReduction = 10
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityEnemyEffectStatDto, abilityEnemyEffectStat));

        var expectedResponse = new CreateAbilityEnemyEffectStatResponse
        {
            Id = ObjectId.GenerateNewId().ToString(),
            AbilityEffectStatsId = ObjectId.GenerateNewId().ToString(),
            EnemyCrowdControlReduction = 10
        };

        _mapperMock.Setup(m => m.Map<AbilityEnemyEffectStat>(request.CreateAbilityEnemyEffectStatDto))
                   .Returns(abilityEnemyEffectStat);

        _abilityEnemyEffectStatServiceMock.Setup(m => m.Create(abilityEnemyEffectStat))
                                    .ReturnsAsync(abilityEnemyEffectStat);

        _mapperMock.Setup(m => m.Map<CreateAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEnemyEffectStatServiceMock.Verify(m => m.Create(abilityEnemyEffectStat), Times.Once);
    }
}
