using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffectStats;

public class RemoveAbilityEffectStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectStatService> _abilityEffectStatServiceMock;
    private readonly Mock<IAbilityEffectStatRepository> _abilityEffectStatRepositoryMock;
    private readonly Mock<AbilityEffectStatBusinessRules> _abilityEffectStatBusinessRulesMock;

    public RemoveAbilityEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectStatServiceMock = new Mock<IAbilityEffectStatService>();
        _abilityEffectStatRepositoryMock = new Mock<IAbilityEffectStatRepository>();
        _abilityEffectStatBusinessRulesMock = new Mock<AbilityEffectStatBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityEffectStat_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEffectStatBusinessRules>(_abilityEffectStatRepositoryMock.Object);

        var handler = new RemoveAbilityEffectStatHandler(_abilityEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityEffectStatRequest
        {
            RemoveAbilityEffectStatDto = new RemoveAbilityEffectStatDto
            {
                Id = id
            }
        };

        var abilityEffectStat = new AbilityEffectStat
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new RemoveAbilityEffectStatResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectStat>(request.RemoveAbilityEffectStatDto))
                   .Returns(abilityEffectStat);

        _abilityEffectStatServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityEffectStat);

        _abilityEffectStatServiceMock.Setup(m => m.Remove(abilityEffectStat))
                                        .ReturnsAsync(abilityEffectStat);

        _mapperMock.Setup(m => m.Map<RemoveAbilityEffectStatResponse>(abilityEffectStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectStatServiceMock.Verify(m => m.GetById(abilityEffectStat.Id), Times.Once);
        _abilityEffectStatServiceMock.Verify(m => m.Remove(abilityEffectStat), Times.Once);
    }
}
