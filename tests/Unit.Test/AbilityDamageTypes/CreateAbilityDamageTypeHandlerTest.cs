using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityDamageTypes;

public class CreateAbilityDamageTypeHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityDamageTypeDtoTestData()
    {
        yield return new object[] { new CreateAbilityDamageTypeDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityDamageTypeService> _abilityDamageTypeServiceMock;
    private readonly Mock<IAbilityDamageTypeRepository> _abilityDamageTypeRepositoryMock;
    private readonly Mock<AbilityDamageTypeBusinessRules> _abilityDamageTypeBusinessRulesMock;

    public CreateAbilityDamageTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityDamageTypeServiceMock = new Mock<IAbilityDamageTypeService>();
        _abilityDamageTypeRepositoryMock = new Mock<IAbilityDamageTypeRepository>();
        _abilityDamageTypeBusinessRulesMock = new Mock<AbilityDamageTypeBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityDamageTypeDtoTestData))]
    public async Task AbilityDamageType_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityDamageTypeDto createAbilityDamageTypeDto)
    {
        var businessRuleMock = new Mock<AbilityDamageTypeBusinessRules>(_abilityDamageTypeRepositoryMock.Object);

        var handler = new CreateAbilityDamageTypeHandler(_abilityDamageTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new CreateAbilityDamageTypeRequest
        {
            CreateAbilityDamageTypeDto = createAbilityDamageTypeDto
        };

        var abilityDamageType = new AbilityDamageType
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = request.CreateAbilityDamageTypeDto.Name
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityDamageTypeDto, abilityDamageType));

        var expectedResponse = new CreateAbilityDamageTypeResponse
        {
            Id = abilityDamageType.Id,
            Name = request.CreateAbilityDamageTypeDto.Name
        };

        _mapperMock.Setup(m => m.Map<AbilityDamageType>(request.CreateAbilityDamageTypeDto))
                   .Returns(abilityDamageType);

        _abilityDamageTypeServiceMock.Setup(m => m.Create(abilityDamageType))
                                    .ReturnsAsync(abilityDamageType);

        _mapperMock.Setup(m => m.Map<CreateAbilityDamageTypeResponse>(abilityDamageType))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityDamageTypeServiceMock.Verify(m => m.Create(abilityDamageType), Times.Once);
    }
}
