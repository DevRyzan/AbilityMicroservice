using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAttackStats;

public class RemoveAbilityAttackStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAttackStatService> _abilityAttackStatServiceMock;
    private readonly Mock<IAbilityAttackStatRepository> _abilityAttackStatRepositoryMock;
    private readonly Mock<AbilityAttackStatBusinessRules> _abilityAttackStatBusinessRulesMock;

    public RemoveAbilityAttackStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAttackStatBusinessRulesMock = new Mock<AbilityAttackStatBusinessRules>();
        _abilityAttackStatServiceMock = new Mock<IAbilityAttackStatService>();
        _abilityAttackStatRepositoryMock = new Mock<IAbilityAttackStatRepository>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityActivationType_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityAttackStatBusinessRules>(_abilityAttackStatRepositoryMock.Object);

        var handler = new RemoveAbilityAttackStatHandler(_abilityAttackStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityAttackStatRequest
        {
            RemoveAbilityAttackStatDto = new RemoveAbilityAttackStatDto
            {
                Id = id
            }
        };

        var abilityAttackStat = new AbilityAttackStat
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new RemoveAbilityAttackStatResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityAttackStat>(request.RemoveAbilityAttackStatDto))
                   .Returns(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.Remove(abilityAttackStat))
                                        .ReturnsAsync(abilityAttackStat);

        _mapperMock.Setup(m => m.Map<RemoveAbilityAttackStatResponse>(abilityAttackStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityAttackStatServiceMock.Verify(m => m.GetById(abilityAttackStat.Id), Times.Once);
        _abilityAttackStatServiceMock.Verify(m => m.Remove(abilityAttackStat), Times.Once);

    }
}
