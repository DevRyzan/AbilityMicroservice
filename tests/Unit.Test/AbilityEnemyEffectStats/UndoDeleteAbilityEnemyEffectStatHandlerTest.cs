using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEnemyEffectStats;

public class UndoDeleteAbilityEnemyEffectStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEnemyEffectStatService> _abilityEnemyEffectStatServiceMock;
    private readonly Mock<IAbilityEnemyEffectStatRepository> _abilityEnemyEffectStatRepositoryMock;
    private readonly Mock<AbilityEnemyEffectStatBusinessRules> _abilityEnemyEffectStatBusinessRulesMock;

    public UndoDeleteAbilityEnemyEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEnemyEffectStatServiceMock = new Mock<IAbilityEnemyEffectStatService>();
        _abilityEnemyEffectStatRepositoryMock = new Mock<IAbilityEnemyEffectStatRepository>();
        _abilityEnemyEffectStatBusinessRulesMock = new Mock<AbilityEnemyEffectStatBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityEnemyEffectStat_UndoDeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEnemyEffectStatBusinessRules>(_abilityEnemyEffectStatRepositoryMock.Object);

        var handler = new UndoDeleteAbilityEnemyEffectStatHandler(_abilityEnemyEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UndoDeleteAbilityEnemyEffectStatRequest
        {
            UndoDeleteAbilityEnemyEffectStatDto = new UndoDeleteAbilityEnemyEffectStatDto
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

        var expectedResponse = new UndoDeleteAbilityEnemyEffectStatResponse
        {
            Id = id,
            Status = !abilityEnemyEffectStat.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityEnemyEffectStat>(request.UndoDeleteAbilityEnemyEffectStatDto))
                   .Returns(abilityEnemyEffectStat);

        _abilityEnemyEffectStatServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityEnemyEffectStat);

        _abilityEnemyEffectStatServiceMock.Setup(m => m.Update(abilityEnemyEffectStat))
                                        .ReturnsAsync(abilityEnemyEffectStat);

        _mapperMock.Setup(m => m.Map<UndoDeleteAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityEnemyEffectStatServiceMock.Verify(m => m.GetById(abilityEnemyEffectStat.Id), Times.Once);
        _abilityEnemyEffectStatServiceMock.Verify(m => m.Update(abilityEnemyEffectStat), Times.Once);
    }
}
