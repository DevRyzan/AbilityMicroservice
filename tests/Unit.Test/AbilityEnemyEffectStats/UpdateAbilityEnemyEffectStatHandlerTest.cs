using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Update;
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

public class UpdateAbilityEnemyEffectStatHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityEnemyEffectStatDtoTestData()
    {
        yield return new object[] { new UpdateAbilityEnemyEffectStatDto {
            Id = ObjectId.GenerateNewId().ToString(),
            AbilityEffectStatsId = ObjectId.GenerateNewId().ToString(),
            EnemyCrowdControlReduction = 10
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEnemyEffectStatService> _abilityEnemyEffectStatServiceMock;
    private readonly Mock<IAbilityEnemyEffectStatRepository> _abilityEnemyEffectStatRepositoryMock;
    private readonly Mock<AbilityEnemyEffectStatBusinessRules> _abilityEnemyEffectStatBusinessRulesMock;

    public UpdateAbilityEnemyEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEnemyEffectStatServiceMock = new Mock<IAbilityEnemyEffectStatService>();
        _abilityEnemyEffectStatRepositoryMock = new Mock<IAbilityEnemyEffectStatRepository>();
        _abilityEnemyEffectStatBusinessRulesMock = new Mock<AbilityEnemyEffectStatBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityEnemyEffectStatDtoTestData))]
    public async Task AbilityEffectType_UpdateHandler_ValidRequest_ReturnsResponse(UpdateAbilityEnemyEffectStatDto updateAbilityEnemyEffectStatDto)
    {
        var businessRuleMock = new Mock<AbilityEnemyEffectStatBusinessRules>(_abilityEnemyEffectStatRepositoryMock.Object);

        var handler = new UpdateAbilityEnemyEffectStatHandler(_abilityEnemyEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityEnemyEffectStatRequest
        {
            UpdateAbilityEnemyEffectStatDto = updateAbilityEnemyEffectStatDto
        };

        var abilityEnemyEffectStat = new AbilityEnemyEffectStat
        {
            Id = request.UpdateAbilityEnemyEffectStatDto.Id,
            AbilityEffectStatsId = ObjectId.GenerateNewId().ToString(),
            EnemyCrowdControlReduction = 10
        };

        var expectedResponse = new UpdateAbilityEnemyEffectStatResponse
        {
            Id = request.UpdateAbilityEnemyEffectStatDto.Id,
            AbilityEffectStatsId = ObjectId.GenerateNewId().ToString(),
            EnemyCrowdControlReduction = 10
        };

        _mapperMock.Setup(m => m.Map<AbilityEnemyEffectStat>(request.UpdateAbilityEnemyEffectStatDto))
                   .Returns(abilityEnemyEffectStat);

        _abilityEnemyEffectStatServiceMock.Setup(m => m.GetById(abilityEnemyEffectStat.Id))
                                    .ReturnsAsync(abilityEnemyEffectStat);

        _abilityEnemyEffectStatServiceMock.Setup(m => m.Update(abilityEnemyEffectStat))
                                    .ReturnsAsync(abilityEnemyEffectStat);

        _mapperMock.Setup(m => m.Map<UpdateAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEnemyEffectStatServiceMock.Verify(m => m.GetById(abilityEnemyEffectStat.Id), Times.Once);
        _abilityEnemyEffectStatServiceMock.Verify(m => m.Update(abilityEnemyEffectStat), Times.Once);
    }
}
