using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffects;

public class CreateAbilityEffectHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityEffectDtoTestData()
    {
        yield return new object[] { new CreateAbilityEffectDto { 
            AbilityId = ObjectId.GenerateNewId().ToString(),
            Name = "string" 
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectService> _abilityEffectServiceMock;
    private readonly Mock<IAbilityEffectRepository> _abilityEffectRepositoryMock;
    private readonly Mock<AbilityEffectBusinessRules> _abilityEffectBusinessRulesMock;

    public CreateAbilityEffectHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectServiceMock = new Mock<IAbilityEffectService>();
        _abilityEffectRepositoryMock = new Mock<IAbilityEffectRepository>();
        _abilityEffectBusinessRulesMock = new Mock<AbilityEffectBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityEffectDtoTestData))]
    public async Task AbilityEffect_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityEffectDto createAbilityEffectDto)
    {
        var businessRuleMock = new Mock<AbilityEffectBusinessRules>(_abilityEffectRepositoryMock.Object);

        var handler = new CreateAbilityEffectHandler(_abilityEffectServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new CreateAbilityEffectRequest
        {
            CreateAbilityEffectDto = createAbilityEffectDto
        };

        var abilityEffect = new AbilityEffect
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = request.CreateAbilityEffectDto.Name
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityEffectDto, abilityEffect));

        var expectedResponse = new CreateAbilityEffectResponse
        {
            Id = abilityEffect.Id,
            Name = request.CreateAbilityEffectDto.Name
        };

        _mapperMock.Setup(m => m.Map<AbilityEffect>(request.CreateAbilityEffectDto))
                   .Returns(abilityEffect);

        _abilityEffectServiceMock.Setup(m => m.Create(abilityEffect))
                                    .ReturnsAsync(abilityEffect);

        _mapperMock.Setup(m => m.Map<CreateAbilityEffectResponse>(abilityEffect))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectServiceMock.Verify(m => m.Create(abilityEffect), Times.Once);
    }
}