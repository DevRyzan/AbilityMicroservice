using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityEffectStats;

public class ChangeStatusAbilityEffectStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectStatService> _abilityEffectStatServiceMock;
    private readonly Mock<IAbilityEffectStatRepository> _abilityEffectStatRepositoryMock;
    private readonly Mock<AbilityEffectStatBusinessRules> _abilityEffectStatBusinessRulesMock;

    public ChangeStatusAbilityEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectStatServiceMock = new Mock<IAbilityEffectStatService>();
        _abilityEffectStatRepositoryMock = new Mock<IAbilityEffectStatRepository>();
        _abilityEffectStatBusinessRulesMock = new Mock<AbilityEffectStatBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityEffectStat_ChangeStatusHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEffectStatBusinessRules>(_abilityEffectStatRepositoryMock.Object);

        var handler = new ChangeStatusAbilityEffectStatHandler(_abilityEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new ChangeStatusAbilityEffectStatRequest
        {
            ChangeStatusAbilityEffectStatDto = new ChangeStatusAbilityEffectStatDto
            {
                Id = id
            }
        };

        var abilityEffectStat = new AbilityEffectStat
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new ChangeStatusAbilityEffectStatResponse
        {
            Id = id,
            Status = !abilityEffectStat.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectStat>(request.ChangeStatusAbilityEffectStatDto))
                   .Returns(abilityEffectStat);

        _abilityEffectStatServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityEffectStat);

        _abilityEffectStatServiceMock.Setup(m => m.Update(abilityEffectStat))
                                    .ReturnsAsync(abilityEffectStat);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityEffectStatResponse>(abilityEffectStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityEffectStatServiceMock.Verify(m => m.GetById(abilityEffectStat.Id), Times.Once);
        _abilityEffectStatServiceMock.Verify(m => m.Update(abilityEffectStat), Times.Once);
    }
}
