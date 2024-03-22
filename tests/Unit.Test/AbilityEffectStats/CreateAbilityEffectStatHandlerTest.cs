using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Create;
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

public class CreateAbilityEffectStatHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityEffectStatDtoTestData()
    {
        yield return new object[] { new CreateAbilityEffectStatDto {
            AbilityEffectId = ObjectId.GenerateNewId().ToString(),
            CrowdControlDuration = 10
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectStatService> _abilityEffectStatServiceMock;
    private readonly Mock<IAbilityEffectStatRepository> _abilityEffectStatRepositoryMock;
    private readonly Mock<AbilityEffectStatBusinessRules> _abilityEffectStatBusinessRulesMock;

    public CreateAbilityEffectStatHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectStatServiceMock = new Mock<IAbilityEffectStatService>();
        _abilityEffectStatRepositoryMock = new Mock<IAbilityEffectStatRepository>();
        _abilityEffectStatBusinessRulesMock = new Mock<AbilityEffectStatBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityEffectStatDtoTestData))]
    public async Task AbilityEffect_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityEffectStatDto createAbilityEffectStatDto)
    {
        var businessRuleMock = new Mock<AbilityEffectStatBusinessRules>(_abilityEffectStatRepositoryMock.Object);

        var handler = new CreateAbilityEffectStatHandler(_abilityEffectStatServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new CreateAbilityEffectStatRequest
        {
            CreateAbilityEffectStatDto = createAbilityEffectStatDto
        };

        var abilityEffectStat = new AbilityEffectStat
        {
            Id = ObjectId.GenerateNewId().ToString(),
            CrowdControlDuration = request.CreateAbilityEffectStatDto.CrowdControlDuration
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityEffectStatDto, abilityEffectStat));

        var expectedResponse = new CreateAbilityEffectStatResponse
        {
            Id = abilityEffectStat.Id,
            CrowdControlDuration = request.CreateAbilityEffectStatDto.CrowdControlDuration
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectStat>(request.CreateAbilityEffectStatDto))
                   .Returns(abilityEffectStat);

        _abilityEffectStatServiceMock.Setup(m => m.Create(abilityEffectStat))
                                    .ReturnsAsync(abilityEffectStat);

        _mapperMock.Setup(m => m.Map<CreateAbilityEffectStatResponse>(abilityEffectStat))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectStatServiceMock.Verify(m => m.Create(abilityEffectStat), Times.Once);
    }
}
