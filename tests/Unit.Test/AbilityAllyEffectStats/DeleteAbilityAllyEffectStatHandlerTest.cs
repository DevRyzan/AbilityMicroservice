using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAllyEffectStats;

public class DeleteAbilityAllyEffectStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAllyEffectStatService> _abilityAllyEffectStatServiceMock;
    private readonly Mock<IAbilityAllyEffectStatRepository> _abilityAllyEffectStatRepositoryMock;
    private readonly Mock<AbilityAllyEffectStatsBusinessRules> _abilityAllyEffectStatBusinessRulesMock;

    public DeleteAbilityAllyEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAllyEffectStatBusinessRulesMock = new Mock<AbilityAllyEffectStatsBusinessRules>();
        _abilityAllyEffectStatServiceMock = new Mock<IAbilityAllyEffectStatService>();
        _abilityAllyEffectStatRepositoryMock = new Mock<IAbilityAllyEffectStatRepository>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityAllyEffectStat_DeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityAllyEffectStatsBusinessRules>(_abilityAllyEffectStatRepositoryMock.Object);

        var handler = new DeleteAbilityAllyEffectStatHandler(_abilityAllyEffectStatServiceMock.Object, _abilityAllyEffectStatBusinessRulesMock.Object, _mapperMock.Object);

        var request = new DeleteAbilityAllyEffectStatRequest
        {
            DeleteAbilityAllyEffectStatDto = new DeleteAbilityAllyEffectStatDto
            {
                Id = id
            }
        };

        var abilityAllyEffectStat = new AbilityAllyEffectStat
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new DeleteAbilityAllyEffectStatResponse
        {
            Id = id,
            Status = !abilityAllyEffectStat.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityAllyEffectStat>(request.DeleteAbilityAllyEffectStatDto))
                   .Returns(abilityAllyEffectStat);

        _abilityAllyEffectStatServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityAllyEffectStat);

        _abilityAllyEffectStatServiceMock.Setup(m => m.Delete(abilityAllyEffectStat))
                                        .ReturnsAsync(abilityAllyEffectStat);

        _mapperMock.Setup(m => m.Map<DeleteAbilityAllyEffectStatResponse>(abilityAllyEffectStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityAllyEffectStatServiceMock.Verify(m => m.GetById(abilityAllyEffectStat.Id), Times.Once);
        _abilityAllyEffectStatServiceMock.Verify(m => m.Delete(abilityAllyEffectStat), Times.Once);
    }
}
