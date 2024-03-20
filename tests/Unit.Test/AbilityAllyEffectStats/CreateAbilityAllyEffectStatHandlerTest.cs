using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAllyEffectStats;

public class CreateAbilityAllyEffectStatHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityAllyEffectStatDtoTestData()
    {
        yield return new object[] { new CreateAbilityAllyEffectStatDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAllyEffectStatService> _abilityAllyEffectStatServiceMock;
    private readonly Mock<IAbilityAllyEffectStatRepository> _abilityAllyEffectStatRepositoryMock;
    private readonly Mock<AbilityAllyEffectStatsBusinessRules> _abilityAllyEffectStatBusinessRulesMock;

    public CreateAbilityAllyEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAllyEffectStatBusinessRulesMock = new Mock<AbilityAllyEffectStatsBusinessRules>();
        _abilityAllyEffectStatServiceMock = new Mock<IAbilityAllyEffectStatService>();
        _abilityAllyEffectStatRepositoryMock = new Mock<IAbilityAllyEffectStatRepository>();
    }
     
    [Theory]
    [MemberData(nameof(CreateAbilityAllyEffectStatDtoTestData))]
    public async Task AbilityActivationType_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityAllyEffectStatDto createAbilityAllyEffectStatDto)
    {
        var businessRuleMock = new Mock<AbilityAllyEffectStatsBusinessRules>(_abilityAllyEffectStatRepositoryMock.Object);

        var handler = new CreateAbilityAllyEffectStatHandler(_abilityAllyEffectStatServiceMock.Object, _abilityAllyEffectStatBusinessRulesMock.Object, _mapperMock.Object);

        var request = new CreateAbilityAllyEffectStatRequest
        {
            CreateAbilityAllyEffectStatDto = createAbilityAllyEffectStatDto
        };

        var abilityAllyEffectStats = new AbilityAllyEffectStat
        {
            Id = ObjectId.GenerateNewId().ToString(),
            AbilityEffectStatsId = request.CreateAbilityAllyEffectStatDto.AbilityEffectStatsId
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityAllyEffectStatDto, abilityAllyEffectStats));

        var expectedResponse = new CreateAbilityAllyEffectStatResponse
        {
            Id = abilityAllyEffectStats.Id,
            AbilityEffectStatsId = request.CreateAbilityAllyEffectStatDto.AbilityEffectStatsId
        };

        _mapperMock.Setup(m => m.Map<AbilityAllyEffectStat>(request.CreateAbilityAllyEffectStatDto))
                   .Returns(abilityAllyEffectStats);

        _abilityAllyEffectStatServiceMock.Setup(m => m.Create(abilityAllyEffectStats))
                                    .ReturnsAsync(abilityAllyEffectStats);

        _mapperMock.Setup(m => m.Map<CreateAbilityAllyEffectStatResponse>(abilityAllyEffectStats))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityAllyEffectStatServiceMock.Verify(m => m.Create(abilityAllyEffectStats), Times.Once);

    }

}
