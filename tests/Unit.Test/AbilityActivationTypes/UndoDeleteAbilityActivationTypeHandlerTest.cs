using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityActivationTypes;

public class UndoDeleteAbilityActivationTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityActivationTypeService> _abilityActivationTypeServiceMock;
    private readonly Mock<IAbilityActivationTypeRepository> _activationTypeRepositoryMock;
    private readonly Mock<AbilityActivationTypeBusinessRules> _activationTypeBusinessRulesMock;

    public UndoDeleteAbilityActivationTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityActivationTypeServiceMock = new Mock<IAbilityActivationTypeService>();
        _activationTypeRepositoryMock = new Mock<IAbilityActivationTypeRepository>();
        _activationTypeBusinessRulesMock = new Mock<AbilityActivationTypeBusinessRules>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityActivationType_UndoDeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityActivationTypeBusinessRules>(_activationTypeRepositoryMock.Object);

        var handler = new UndoDeleteAbilityActivationTypeHandler(_abilityActivationTypeServiceMock.Object, _activationTypeBusinessRulesMock.Object, _mapperMock.Object);

        var request = new UndoDeleteAbilityActivationTypeRequest
        {
            UndoDeleteAbilityActivationTypeDto = new UndoDeleteAbilityActivationTypeDto
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

        var expectedResponse = new UndoDeleteAbilityActivationTypeResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityActivationType>(request.UndoDeleteAbilityActivationTypeDto))
                   .Returns(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.Update(abilityActivationType))
                                        .ReturnsAsync(abilityActivationType);

        _mapperMock.Setup(m => m.Map<UndoDeleteAbilityActivationTypeResponse>(abilityActivationType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityActivationTypeServiceMock.Verify(m => m.GetById(abilityActivationType.Id), Times.Once);
        _abilityActivationTypeServiceMock.Verify(m => m.Update(abilityActivationType), Times.Once);
    }
}
