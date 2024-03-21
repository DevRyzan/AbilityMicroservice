using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffectDisableTypes;

public class CreateAbilityEffectDisableTypeHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityEffectDisableTypeDtoTestData()
    {
        yield return new object[] { new CreateAbilityEffectDisableTypeDto {
            Name = "name",
            Description = "description"
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectDisableTypeService> _abilityEffectDisableTypeServiceMock;
    private readonly Mock<IAbilityEffectDisableTypeRepository> _abilityEffectDisableTypeRepositoryMock;
    private readonly Mock<AbilityEffectDisableTypeBusinessRules> _abilityEffectDisableTypeBusinessRulesMock;

    public CreateAbilityEffectDisableTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectDisableTypeServiceMock = new Mock<IAbilityEffectDisableTypeService>();
        _abilityEffectDisableTypeRepositoryMock = new Mock<IAbilityEffectDisableTypeRepository>();
        _abilityEffectDisableTypeBusinessRulesMock = new Mock<AbilityEffectDisableTypeBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityEffectDisableTypeDtoTestData))]
    public async Task AbilityEffectDisableType_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityEffectDisableTypeDto createAbilityEffectDisableTypeDto)
    {
        var businessRuleMock = new Mock<AbilityEffectDisableTypeBusinessRules>(_abilityEffectDisableTypeRepositoryMock.Object);

        var handler = new CreateAbilityEffectDisableTypeHandler(_abilityEffectDisableTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new CreateAbilityEffectDisableTypeRequest
        {
            CreateAbilityEffectDisableTypeDto = createAbilityEffectDisableTypeDto
        };

        var abilityEffectDisableType = new AbilityEffectDisableType
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = request.CreateAbilityEffectDisableTypeDto.Name
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityEffectDisableTypeDto, abilityEffectDisableType));

        var expectedResponse = new CreateAbilityEffectDisableTypeResponse
        {
            Id = abilityEffectDisableType.Id,
            Name = request.CreateAbilityEffectDisableTypeDto.Name
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectDisableType>(request.CreateAbilityEffectDisableTypeDto))
                   .Returns(abilityEffectDisableType);

        _abilityEffectDisableTypeServiceMock.Setup(m => m.Create(abilityEffectDisableType))
                                    .ReturnsAsync(abilityEffectDisableType);

        _mapperMock.Setup(m => m.Map<CreateAbilityEffectDisableTypeResponse>(abilityEffectDisableType))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectDisableTypeServiceMock.Verify(m => m.Create(abilityEffectDisableType), Times.Once);
    }
}
