using Application.Feature.AbilityFeatures.AbilityTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.AbilityType;

public class DeleteAbilityTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityTypeService> _abilityTypeServiceMock;
    private readonly Mock<IAbilityTypeRepository> _abilityTypeRepositoryMock;
    private readonly Mock<AbilityTypeBusinessRules> _abilityTypeBusinessRulesMock;

    public DeleteAbilityTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityTypeBusinessRulesMock = new Mock<AbilityTypeBusinessRules>();
        _abilityTypeServiceMock = new Mock<IAbilityTypeService>();
        _abilityTypeRepositoryMock = new Mock<IAbilityTypeRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityTypeHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityTypeBusinessRules>(_abilityTypeRepositoryMock.Object);

        var handler = new DeleteAbilityTypeCommandHandler(
            _abilityTypeServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new DeleteAbilityTypeCommandRequest
        {
            DeleteAbilityTypeDto = new DeleteAbilityTypeDto
            {
                Id = id
            }
        };

        var abilityTypes = new Domain.Abilities.AbilityType
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new DeleteAbilityTypeCommandResponse
        {
            Id = id,
            Status = false,
            IsDeleted = true,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityType>(request.DeleteAbilityTypeDto))
                   .Returns(abilityTypes);

        _abilityTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityTypes);

        _abilityTypeServiceMock.Setup(m => m.Delete(abilityTypes))
                                    .ReturnsAsync(abilityTypes);

        _mapperMock.Setup(m => m.Map<DeleteAbilityTypeCommandResponse>(abilityTypes))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityTypeServiceMock.Verify(m => m.GetById(abilityTypes.Id), Times.Once);
    }
}
