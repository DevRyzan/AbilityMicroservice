using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityEnemyEffectStats;

public class RemoveAbilityEnemyEffectStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEnemyEffectStatService> _abilityEnemyEffectStatServiceMock;
    private readonly Mock<IAbilityEnemyEffectStatRepository> _abilityEnemyEffectStatRepositoryMock;
    private readonly Mock<AbilityEnemyEffectStatBusinessRules> _abilityEnemyEffectStatBusinessRulesMock;

    public RemoveAbilityEnemyEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEnemyEffectStatServiceMock = new Mock<IAbilityEnemyEffectStatService>();
        _abilityEnemyEffectStatRepositoryMock = new Mock<IAbilityEnemyEffectStatRepository>();
        _abilityEnemyEffectStatBusinessRulesMock = new Mock<AbilityEnemyEffectStatBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityEnemyEffectStat_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEnemyEffectStatBusinessRules>(_abilityEnemyEffectStatRepositoryMock.Object);

        var handler = new RemoveAbilityEnemyEffectStatHandler(_abilityEnemyEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityEnemyEffectStatRequest
        {
            RemoveAbilityEnemyEffectStatDto = new RemoveAbilityEnemyEffectStatDto
            {
                Id = id
            }
        };

        var abilityEnemyEffectStat = new AbilityEnemyEffectStat
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new RemoveAbilityEnemyEffectStatResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityEnemyEffectStat>(request.RemoveAbilityEnemyEffectStatDto))
                   .Returns(abilityEnemyEffectStat);

        _abilityEnemyEffectStatServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityEnemyEffectStat);

        _abilityEnemyEffectStatServiceMock.Setup(m => m.Remove(abilityEnemyEffectStat))
                                        .ReturnsAsync(abilityEnemyEffectStat);

        _mapperMock.Setup(m => m.Map<RemoveAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEnemyEffectStatServiceMock.Verify(m => m.GetById(abilityEnemyEffectStat.Id), Times.Once);
        _abilityEnemyEffectStatServiceMock.Verify(m => m.Remove(abilityEnemyEffectStat), Times.Once);
    }

}
