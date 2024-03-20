using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityAllyEffectStats;

public class UpdateAbilityAllyEffectStatHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityAllyEffectStatDtoTestData()
    {
        yield return new object[] { new UpdateAbilityAllyEffectStatDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAllyEffectStatService> _abilityAllyEffectStatServiceMock;
    private readonly Mock<IAbilityAllyEffectStatRepository> _abilityAllyEffectStatRepositoryMock;
    private readonly Mock<AbilityAllyEffectStatsBusinessRules> _abilityAllyEffectStatBusinessRulesMock;

    public UpdateAbilityAllyEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAllyEffectStatBusinessRulesMock = new Mock<AbilityAllyEffectStatsBusinessRules>();
        _abilityAllyEffectStatServiceMock = new Mock<IAbilityAllyEffectStatService>();
        _abilityAllyEffectStatRepositoryMock = new Mock<IAbilityAllyEffectStatRepository>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityAllyEffectStatDtoTestData))]
    public async Task AbilityAllyEffectStat_UpdateHandler_ValidRequest_ReturnsResponse(UpdateAbilityAllyEffectStatDto updateAbilityAllyEffectStatDto)
    {
        var businessRuleMock = new Mock<AbilityAllyEffectStatsBusinessRules>(_abilityAllyEffectStatRepositoryMock.Object);

        var handler = new UpdateAbilityAllyEffectStatHandler(_abilityAllyEffectStatServiceMock.Object, _abilityAllyEffectStatBusinessRulesMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityAllyEffectStatRequest
        {
            UpdateAbilityAllyEffectStatDto = updateAbilityAllyEffectStatDto
        };

        var abilityAllyEffectStat = new AbilityAllyEffectStat
        {
            Id = request.UpdateAbilityAllyEffectStatDto.Id,
            AbilityEffectStatsId = request.UpdateAbilityAllyEffectStatDto.AbilityEffectStatsId
        };

        var expectedResponse = new UpdateAbilityAllyEffectStatResponse
        {
            Id = request.UpdateAbilityAllyEffectStatDto.Id,
            AbilityEffectStatsId = request.UpdateAbilityAllyEffectStatDto.AbilityEffectStatsId
        };

        _mapperMock.Setup(m => m.Map<AbilityAllyEffectStat>(request.UpdateAbilityAllyEffectStatDto))
                   .Returns(abilityAllyEffectStat);

        _abilityAllyEffectStatServiceMock.Setup(m => m.GetById(abilityAllyEffectStat.Id))
                                    .ReturnsAsync(abilityAllyEffectStat);

        _abilityAllyEffectStatServiceMock.Setup(m => m.Update(abilityAllyEffectStat))
                                    .ReturnsAsync(abilityAllyEffectStat);

        _mapperMock.Setup(m => m.Map<UpdateAbilityAllyEffectStatResponse>(abilityAllyEffectStat))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityAllyEffectStatServiceMock.Verify(m => m.GetById(abilityAllyEffectStat.Id), Times.Once);
        _abilityAllyEffectStatServiceMock.Verify(m => m.Update(abilityAllyEffectStat), Times.Once);
    }
}
