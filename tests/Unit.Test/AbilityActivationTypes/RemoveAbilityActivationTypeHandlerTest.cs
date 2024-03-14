using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityActivationTypes;

public class RemoveAbilityActivationTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityActivationTypeService> _abilityActivationTypeServiceMock;
    private readonly Mock<IAbilityActivationTypeRepository> _activationTypeRepositoryMock;
    private readonly Mock<AbilityActivationTypeBusinessRules> _activationTypeBusinessRulesMock;

    public RemoveAbilityActivationTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityActivationTypeServiceMock = new Mock<IAbilityActivationTypeService>();
        _activationTypeRepositoryMock = new Mock<IAbilityActivationTypeRepository>();
        _activationTypeBusinessRulesMock = new Mock<AbilityActivationTypeBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityActivationType_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityActivationTypeBusinessRules>(_activationTypeRepositoryMock.Object);

        var handler = new RemoveAbilityActivationTypeHandler(_abilityActivationTypeServiceMock.Object, _activationTypeBusinessRulesMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityActivationTypeRequest
        {
            RemoveAbilityActivationTypeDto = new RemoveAbilityActivationTypeDto
            {
                Id = id
            }
        };

        var abilityActivationType = new AbilityActivationType
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new RemoveAbilityActivationTypeResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityActivationType>(request.RemoveAbilityActivationTypeDto))
                   .Returns(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.Remove(abilityActivationType))
                                        .ReturnsAsync(abilityActivationType);

        _mapperMock.Setup(m => m.Map<RemoveAbilityActivationTypeResponse>(abilityActivationType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityActivationTypeServiceMock.Verify(m => m.GetById(abilityActivationType.Id), Times.Once);
        _abilityActivationTypeServiceMock.Verify(m => m.Remove(abilityActivationType), Times.Once);
    }
}
