using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAttackStats;

public class UndoDeleteAbilityAttackStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAttackStatService> _abilityAttackStatServiceMock;
    private readonly Mock<IAbilityAttackStatRepository> _abilityAttackStatRepositoryMock;
    private readonly Mock<AbilityAttackStatBusinessRules> _abilityAttackStatBusinessRulesMock;

    public UndoDeleteAbilityAttackStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAttackStatBusinessRulesMock = new Mock<AbilityAttackStatBusinessRules>();
        _abilityAttackStatServiceMock = new Mock<IAbilityAttackStatService>();
        _abilityAttackStatRepositoryMock = new Mock<IAbilityAttackStatRepository>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityAttackStat_UndoDeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityAttackStatBusinessRules>(_abilityAttackStatRepositoryMock.Object);

        var handler = new UndoDeleteAbilityAttackStatHandler(_abilityAttackStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UndoDeleteAbilityAttackStatRequest
        {
            UndoDeleteAbilityAttackStatDto = new UndoDeleteAbilityAttackStatDto
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

        var expectedResponse = new UndoDeleteAbilityAttackStatResponse
        {
            Id = id,
            Status = !abilityAttackStat.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityAttackStat>(request.UndoDeleteAbilityAttackStatDto))
                   .Returns(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.Update(abilityAttackStat))
                                        .ReturnsAsync(abilityAttackStat);

        _mapperMock.Setup(m => m.Map<UndoDeleteAbilityAttackStatResponse>(abilityAttackStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityAttackStatServiceMock.Verify(m => m.GetById(abilityAttackStat.Id), Times.Once);
        _abilityAttackStatServiceMock.Verify(m => m.Update(abilityAttackStat), Times.Once);
    }
}
