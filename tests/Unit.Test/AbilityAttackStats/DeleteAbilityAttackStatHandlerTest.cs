using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAttackStats;

public class DeleteAbilityAttackStatHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAttackStatService> _abilityAttackStatServiceMock;
    private readonly Mock<IAbilityAttackStatRepository> _abilityAttackStatRepositoryMock;
    private readonly Mock<AbilityAttackStatBusinessRules> _abilityAttackStatBusinessRulesMock;

    public DeleteAbilityAttackStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAttackStatBusinessRulesMock = new Mock<AbilityAttackStatBusinessRules>();
        _abilityAttackStatServiceMock = new Mock<IAbilityAttackStatService>();
        _abilityAttackStatRepositoryMock = new Mock<IAbilityAttackStatRepository>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityAttackStat_DeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityAttackStatBusinessRules>(_abilityAttackStatRepositoryMock.Object);

        var handler = new DeleteAbilityAttackStatHandler(_abilityAttackStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new DeleteAbilityAttackStatRequest
        {
            DeleteAbilityAttackStatDto = new DeleteAbilityAttackStatDto
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

        var expectedResponse = new DeleteAbilityAttackStatResponse
        {
            Id = id,
            Status = !abilityAttackStat.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityAttackStat>(request.DeleteAbilityAttackStatDto))
                   .Returns(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.Delete(abilityAttackStat))
                                        .ReturnsAsync(abilityAttackStat);

        _mapperMock.Setup(m => m.Map<DeleteAbilityAttackStatResponse>(abilityAttackStat))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityAttackStatServiceMock.Verify(m => m.GetById(abilityAttackStat.Id), Times.Once);
        _abilityAttackStatServiceMock.Verify(m => m.Delete(abilityAttackStat), Times.Once);
    }

}
