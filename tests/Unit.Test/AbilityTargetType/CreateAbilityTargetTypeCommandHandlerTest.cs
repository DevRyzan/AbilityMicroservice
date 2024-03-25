using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.AbilityTargetType;

public class CreateAbilityTargetTypeCommandHandlerTest
{

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityTargetTypeService> _abilityTargetTypeServiceMock;
    private readonly Mock<IAbilityTargetTypeRepository> _abilityTargetTypeRepositoryMock;
    private readonly Mock<IAbilityRepository> _abilityRepositoryMock;
    private readonly Mock<AbilityTargetTypeBusinessRules> _abilityTargetTypeBusinessRulesMock;

    public CreateAbilityTargetTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityTargetTypeBusinessRulesMock = new Mock<AbilityTargetTypeBusinessRules>();
        _abilityTargetTypeServiceMock = new Mock<IAbilityTargetTypeService>();
        _abilityTargetTypeRepositoryMock = new Mock<IAbilityTargetTypeRepository>();
        _abilityRepositoryMock = new Mock<IAbilityRepository>();
    }



    [Theory]
    [InlineData("xxx", "xxxxxx")]
    public async Task AbilityTargetTypeHandler_ValidRequest_ReturnsResponse(string name, string description)
    {
        var businessRuleMock = new Mock<AbilityTargetTypeBusinessRules>(_abilityTargetTypeRepositoryMock.Object, _abilityRepositoryMock.Object);

        var handler = new CreateAbilityTargetTypeCommandHandler(_mapperMock.Object, businessRuleMock.Object, _abilityTargetTypeServiceMock.Object);

        var request = new CreateAbilityTargetTypeCommandRequest
        {
            CreateAbilityTargetTypeDto = new CreateAbilityTargetTypeDto
            {
                Name = name,
                Description = description
            }
        };

        var abilityTargetType = new Domain.Abilities.AbilityTargetType
        {
            Name = name,
            Description = description
        };

        var expectedResponse = new CreateAbilityTargetTypeCommandResponse
        {
            Name = name,
            Description = description
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityTargetType>(request.CreateAbilityTargetTypeDto))
                   .Returns(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.Create(abilityTargetType))
                                    .ReturnsAsync(abilityTargetType);

        _mapperMock.Setup(m => m.Map<CreateAbilityTargetTypeCommandResponse>(abilityTargetType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityTargetTypeServiceMock.Verify(m => m.Create(abilityTargetType), Times.Once);
    }

}
