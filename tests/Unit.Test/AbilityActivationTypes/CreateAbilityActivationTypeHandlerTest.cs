using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace Unit.Test.AbilityActivationTypes;

public class CreateAbilityActivationTypeHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityActivationTypeDtoTestData()
    {
        yield return new object[] { new CreateAbilityActivationTypeDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityActivationTypeService> _abilityActivationTypeServiceMock;
    private readonly Mock<IAbilityActivationTypeRepository> _activationTypeRepositoryMock;
    private readonly Mock<AbilityActivationTypeBusinessRules> _activationTypeBusinessRulesMock;

    public CreateAbilityActivationTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityActivationTypeServiceMock = new Mock<IAbilityActivationTypeService>();
        _activationTypeRepositoryMock = new Mock<IAbilityActivationTypeRepository>();
        _activationTypeBusinessRulesMock = new Mock<AbilityActivationTypeBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityActivationTypeDtoTestData))]
    public async Task AbilityActivationType_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityActivationTypeDto createAbilityActivationTypeDto)
    {
        var businessRuleMock = new Mock<AbilityActivationTypeBusinessRules>(_activationTypeRepositoryMock.Object);

        var handler = new CreateAbilityActivationTypeHandler(_abilityActivationTypeServiceMock.Object, _activationTypeBusinessRulesMock.Object, _mapperMock.Object);

        var request = new CreateAbilityActivationTypeRequest
        {
            CreateAbilityActivationTypeDto = createAbilityActivationTypeDto
        };

        var abilityActivationType = new AbilityActivationType
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = request.CreateAbilityActivationTypeDto.Name,
            Description = request.CreateAbilityActivationTypeDto.Description,
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityActivationTypeDto, abilityActivationType));

        var expectedResponse = new CreateAbilityActivationTypeResponse
        {
            Id = abilityActivationType.Id,
            Name = request.CreateAbilityActivationTypeDto.Name,
            Description = request.CreateAbilityActivationTypeDto.Description,
        };

        _mapperMock.Setup(m => m.Map<AbilityActivationType>(request.CreateAbilityActivationTypeDto))
                   .Returns(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.Create(abilityActivationType))
                                    .ReturnsAsync(abilityActivationType);

        _mapperMock.Setup(m => m.Map<CreateAbilityActivationTypeResponse>(abilityActivationType))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Name, abilityActivationType.Name);

        _abilityActivationTypeServiceMock.Verify(m => m.Create(abilityActivationType), Times.Once);

    }

}
