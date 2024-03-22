using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffectTypes;

public class CreateAbilityEffectTypeHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityEffectTypeDtoTestData()
    {
        yield return new object[] { new CreateAbilityEffectTypeDto {
            Name = "nameTest",
            Description = "descriptionTest"
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectTypeService> _abilityEffectTypeServiceMock;
    private readonly Mock<IAbilityEffectTypeRepository> _abilityEffectTypeRepositoryMock;
    private readonly Mock<AbilityEffectTypeBusinessRules> _abilityEffectTypeBusinessRulesMock;

    public CreateAbilityEffectTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectTypeServiceMock = new Mock<IAbilityEffectTypeService>();
        _abilityEffectTypeRepositoryMock = new Mock<IAbilityEffectTypeRepository>();
        _abilityEffectTypeBusinessRulesMock = new Mock<AbilityEffectTypeBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityEffectTypeDtoTestData))]
    public async Task AbilityEffectType_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityEffectTypeDto createAbilityEffectTypeDto)
    {
        var businessRuleMock = new Mock<AbilityEffectTypeBusinessRules>(_abilityEffectTypeRepositoryMock.Object);

        var handler = new CreateAbilityEffectTypeHandler(_abilityEffectTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new CreateAbilityEffectTypeRequest
        {
            CreateAbilityEffectTypeDto = createAbilityEffectTypeDto
        };

        var abilityEffectType = new AbilityEffectType
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = request.CreateAbilityEffectTypeDto.Name
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityEffectTypeDto, abilityEffectType));

        var expectedResponse = new CreateAbilityEffectTypeResponse
        {
            Id = abilityEffectType.Id,
            Name = request.CreateAbilityEffectTypeDto.Name
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectType>(request.CreateAbilityEffectTypeDto))
                   .Returns(abilityEffectType);

        _abilityEffectTypeServiceMock.Setup(m => m.Create(abilityEffectType))
                                    .ReturnsAsync(abilityEffectType);

        _mapperMock.Setup(m => m.Map<CreateAbilityEffectTypeResponse>(abilityEffectType))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectTypeServiceMock.Verify(m => m.Create(abilityEffectType), Times.Once);
    }
}
