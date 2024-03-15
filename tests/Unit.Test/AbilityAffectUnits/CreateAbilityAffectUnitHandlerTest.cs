using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace Unit.Test.AbilityAffectUnits;

public class CreateAbilityAffectUnitHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityAffectUnitDtoTestData()
    {
        yield return new object[] { new CreateAbilityAffectUnitDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAffectUnitService> _abilityAffectUnitServiceMock;
    private readonly Mock<IAbilityAffectUnitRepository> _abilityAffectUnitRepositoryMock;
    private readonly Mock<AbilityAffectUnitBusinessRules> _abilityAffectUnitBusinessRulesMock;

    public CreateAbilityAffectUnitHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAffectUnitServiceMock = new Mock<IAbilityAffectUnitService>();
        _abilityAffectUnitRepositoryMock = new Mock<IAbilityAffectUnitRepository>();
        _abilityAffectUnitBusinessRulesMock = new Mock<AbilityAffectUnitBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityAffectUnitDtoTestData))]
    public async Task AbilityActivationType_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityAffectUnitDto createAbilityAffectUnitDto)
    {
        var businessRuleMock = new Mock<AbilityActivationTypeBusinessRules>(_abilityAffectUnitRepositoryMock.Object);

        var handler = new CreateAbilityAffectUnitHandler(_abilityAffectUnitServiceMock.Object, _abilityAffectUnitBusinessRulesMock.Object, _mapperMock.Object);

        var request = new CreateAbilityAffectUnitRequest
        {
            CreateAbilityAffectUnitDto = createAbilityAffectUnitDto
        };

        var abilityAffectUnit = new AbilityAffectUnit
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = request.CreateAbilityAffectUnitDto.Name
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityAffectUnitDto, abilityAffectUnit));

        var expectedResponse = new CreateAbilityActivationTypeResponse
        {
            Id = abilityAffectUnit.Id,
            Name = request.CreateAbilityAffectUnitDto.Name
        };

        _mapperMock.Setup(m => m.Map<AbilityAffectUnit>(request.CreateAbilityAffectUnitDto))
                   .Returns(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.Create(abilityAffectUnit))
                                    .ReturnsAsync(abilityAffectUnit);

        _mapperMock.Setup(m => m.Map<CreateAbilityActivationTypeResponse>(abilityAffectUnit))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Name, abilityAffectUnit.Name);

        _abilityAffectUnitServiceMock.Verify(m => m.Create(abilityAffectUnit), Times.Once);

    }
}
