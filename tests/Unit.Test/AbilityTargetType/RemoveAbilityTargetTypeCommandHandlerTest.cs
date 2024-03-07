using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.AbilityTargetType;

public class RemoveAbilityTargetTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityTargetTypeService> _abilityTargetTypeServiceMock;
    private readonly Mock<IAbilityTargetTypeRepository> _abilityTargetTypeRepositoryMock;
    private readonly Mock<IAbilityRepository> _abilityRepositoryMock;
    private readonly Mock<AbilityTargetTypeBusinessRules> _abilityTargetTypeBusinessRulesMock;

    public RemoveAbilityTargetTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityTargetTypeBusinessRulesMock = new Mock<AbilityTargetTypeBusinessRules>();
        _abilityTargetTypeServiceMock = new Mock<IAbilityTargetTypeService>();
        _abilityTargetTypeRepositoryMock = new Mock<IAbilityTargetTypeRepository>();
        _abilityRepositoryMock = new Mock<IAbilityRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityTargetTypeHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityTargetTypeBusinessRules>(_abilityTargetTypeRepositoryMock.Object, _abilityRepositoryMock.Object);

        var handler = new RemoveAbilityTargetTypeCommandHandler(_mapperMock.Object, businessRuleMock.Object, _abilityTargetTypeServiceMock.Object);

        var request = new RemoveAbilityTargetTypeCommandRequest
        {
             RemoveAbilityTargetTypeDto = new RemoveAbilityTargetTypeDto
             {
                Id = id
            }
        };

        var abilityTargetType = new Domain.Abilities.AbilityTargetType
        {
            Id = id,
            IsDeleted = true,
            Status = false
        };

        var expectedResponse = new RemoveAbilityTargetTypeCommandResponse
        {
            Id = id,
            IsDeleted = true,
            Status = false

        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityTargetType>(request.RemoveAbilityTargetTypeDto))
                   .Returns(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.GetById(abilityTargetType.Id))
                            .ReturnsAsync(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.Remove(abilityTargetType))
                                    .ReturnsAsync(abilityTargetType);

        _mapperMock.Setup(m => m.Map<RemoveAbilityTargetTypeCommandResponse>(abilityTargetType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityTargetTypeServiceMock.Verify(m => m.Remove(abilityTargetType), Times.Once);
    }
}
