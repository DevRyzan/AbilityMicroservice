using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityAllyEffectStats;

public class ChangeStatusAbilityAllyEffectStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAllyEffectStatService> _abilityAllyEffectStatServiceMock;
    private readonly Mock<IAbilityAllyEffectStatRepository> _abilityAllyEffectStatRepositoryMock;
    private readonly Mock<AbilityAllyEffectStatsBusinessRules> _abilityAllyEffectStatBusinessRulesMock;

    public ChangeStatusAbilityAllyEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAllyEffectStatBusinessRulesMock = new Mock<AbilityAllyEffectStatsBusinessRules>();
        _abilityAllyEffectStatServiceMock = new Mock<IAbilityAllyEffectStatService>();
        _abilityAllyEffectStatRepositoryMock = new Mock<IAbilityAllyEffectStatRepository>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityAllyEffectStat_ChangeStatusHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityAllyEffectStatsBusinessRules>(_abilityAllyEffectStatRepositoryMock.Object);

        var handler = new ChangeStatusAbilityAllyEffectStatHandler(_abilityAllyEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new ChangeStatusAbilityAllyEffectStatRequest
        {
            ChangeStatusAbilityAllyEffectStatDto = new ChangeStatusAbilityAllyEffectStatDto
            {
                Id = id
            }
        };

        var abilityAllyEffectStat = new AbilityAllyEffectStat
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new ChangeStatusAbilityAllyEffectStatResponse
        {
            Id = id,
            Status = !abilityAllyEffectStat.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityAllyEffectStat>(request.ChangeStatusAbilityAllyEffectStatDto))
                   .Returns(abilityAllyEffectStat);

        _abilityAllyEffectStatServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityAllyEffectStat);

        _abilityAllyEffectStatServiceMock.Setup(m => m.Update(abilityAllyEffectStat))
                                    .ReturnsAsync(abilityAllyEffectStat);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityAllyEffectStatResponse>(abilityAllyEffectStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityAllyEffectStatServiceMock.Verify(m => m.GetById(abilityAllyEffectStat.Id), Times.Once);
    }

}
