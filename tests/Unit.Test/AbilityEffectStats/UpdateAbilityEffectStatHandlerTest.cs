using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffectStats;

public class UpdateAbilityEffectStatHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityEffectStatDtoTestData()
    {
        yield return new object[] { new UpdateAbilityEffectStatDto {
            AbilityEffectId = ObjectId.GenerateNewId().ToString(),
            CrowdControlDuration = 10
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectStatService> _abilityEffectStatServiceMock;
    private readonly Mock<IAbilityEffectStatRepository> _abilityEffectStatRepositoryMock;
    private readonly Mock<AbilityEffectStatBusinessRules> _abilityEffectStatBusinessRulesMock;

    public UpdateAbilityEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectStatServiceMock = new Mock<IAbilityEffectStatService>();
        _abilityEffectStatRepositoryMock = new Mock<IAbilityEffectStatRepository>();
        _abilityEffectStatBusinessRulesMock = new Mock<AbilityEffectStatBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityEffectStatDtoTestData))]
    public async Task AbilityEffect_UpdateHandler_ValidRequest_ReturnsResponse(UpdateAbilityEffectStatDto updateAbilityEffectStatDto)
    {
        var businessRuleMock = new Mock<AbilityEffectStatBusinessRules>(_abilityEffectStatRepositoryMock.Object);

        var handler = new UpdateAbilityEffectStatHandler(_abilityEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityEffectStatRequest
        {
            UpdateAbilityEffectStatDto = updateAbilityEffectStatDto
        };

        var abilityEffectStat = new AbilityEffectStat
        {
            Id = request.UpdateAbilityEffectStatDto.Id,
            CrowdControlDuration = 10
        };

        var expectedResponse = new UpdateAbilityEffectStatResponse
        {
            Id = request.UpdateAbilityEffectStatDto.Id,
            CrowdControlDuration = 10
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectStat>(request.UpdateAbilityEffectStatDto))
                   .Returns(abilityEffectStat);

        _abilityEffectStatServiceMock.Setup(m => m.GetById(abilityEffectStat.Id))
                                    .ReturnsAsync(abilityEffectStat);

        _abilityEffectStatServiceMock.Setup(m => m.Update(abilityEffectStat))
                                    .ReturnsAsync(abilityEffectStat);

        _mapperMock.Setup(m => m.Map<UpdateAbilityEffectStatResponse>(abilityEffectStat))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectStatServiceMock.Verify(m => m.GetById(abilityEffectStat.Id), Times.Once);
        _abilityEffectStatServiceMock.Verify(m => m.Update(abilityEffectStat), Times.Once);
    }
}
