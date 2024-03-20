using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAttackStats;

public class UpdateAbilityAttackStatHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityAttackStatDtoTestData()
    {
        yield return new object[] { new UpdateAbilityAttackStatDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAttackStatService> _abilityAttackStatServiceMock;
    private readonly Mock<IAbilityAttackStatRepository> _abilityAttackStatRepositoryMock;
    private readonly Mock<AbilityAttackStatBusinessRules> _abilityAttackStatBusinessRulesMock;

    public UpdateAbilityAttackStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAttackStatBusinessRulesMock = new Mock<AbilityAttackStatBusinessRules>();
        _abilityAttackStatServiceMock = new Mock<IAbilityAttackStatService>();
        _abilityAttackStatRepositoryMock = new Mock<IAbilityAttackStatRepository>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityAttackStatDtoTestData))]
    public async Task AbilityAllyEffectStat_UpdateHandler_ValidRequest_ReturnsResponse(UpdateAbilityAttackStatDto updateAbilityAttackStatDto)
    {
        var businessRuleMock = new Mock<AbilityAttackStatBusinessRules>(_abilityAttackStatRepositoryMock.Object);

        var handler = new UpdateAbilityAttackStatHandler(_abilityAttackStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityAttackStatRequest
        {
            UpdateAbilityAttackStatDto = updateAbilityAttackStatDto
        };

        var abilityAttackStat = new AbilityAttackStat
        {
            Id = request.UpdateAbilityAttackStatDto.Id,
            AbilityLevelId = request.UpdateAbilityAttackStatDto.AbilityLevelId
        };

        var expectedResponse = new UpdateAbilityAttackStatResponse
        {
            Id = request.UpdateAbilityAttackStatDto.Id,
            AbilityLevelId = request.UpdateAbilityAttackStatDto.AbilityLevelId
        };

        _mapperMock.Setup(m => m.Map<AbilityAttackStat>(request.UpdateAbilityAttackStatDto))
                   .Returns(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.GetById(abilityAttackStat.Id))
                                    .ReturnsAsync(abilityAttackStat);

        _abilityAttackStatServiceMock.Setup(m => m.Update(abilityAttackStat))
                                    .ReturnsAsync(abilityAttackStat);

        _mapperMock.Setup(m => m.Map<UpdateAbilityAttackStatResponse>(abilityAttackStat))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityAttackStatServiceMock.Verify(m => m.GetById(abilityAttackStat.Id), Times.Once);
        _abilityAttackStatServiceMock.Verify(m => m.Update(abilityAttackStat), Times.Once);
    }
}
