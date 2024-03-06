using Application.Feature.AbilityFeatures.AbilityTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.AbilityType;

public class UpdateAbilityTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityTypeService> _abilityTypeServiceMock;
    private readonly Mock<IAbilityTypeRepository> _abilityTypeRepositoryMock;
    private readonly Mock<AbilityTypeBusinessRules> _abilityTypeBusinessRulesMock;

    public UpdateAbilityTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityTypeBusinessRulesMock = new Mock<AbilityTypeBusinessRules>();
        _abilityTypeServiceMock = new Mock<IAbilityTypeService>();
        _abilityTypeRepositoryMock = new Mock<IAbilityTypeRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32", "xxx", "xxxxx")]
    public async Task AbilityTypeHandler_ValidRequest_ReturnsResponse(string id, string name, string description)
    {
        var businessRuleMock = new Mock<AbilityTypeBusinessRules>(_abilityTypeRepositoryMock.Object);

        var handler = new UpdateAbilityTypeCommandHandler(
            _abilityTypeServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new UpdateAbilityTypeCommandRequest
        {
            UpdateAbilityTypeDto = new UpdateAbilityTypeDto
            {
                Id = id,
                Name = name,
                Description = description
            }
        };

        var abilityTypes = new Domain.Abilities.AbilityType
        {
            Id = id,
            Name = name,
            Description = description,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new UpdateAbilityTypeCommandResponse
        {
            Id = id,
            Name = "vvv",
            Description = "vvvvv",
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityType>(request.UpdateAbilityTypeDto))
                   .Returns(abilityTypes);

        _abilityTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityTypes);

        _abilityTypeServiceMock.Setup(m => m.Update(abilityTypes))
                                    .ReturnsAsync(abilityTypes);

        _mapperMock.Setup(m => m.Map<UpdateAbilityTypeCommandResponse>(abilityTypes))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityTypeServiceMock.Verify(m => m.Update(abilityTypes), Times.Once);
    }
}
