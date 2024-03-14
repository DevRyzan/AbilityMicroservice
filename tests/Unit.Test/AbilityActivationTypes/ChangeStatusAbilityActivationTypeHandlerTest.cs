using Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityActivationTypes;

public class ChangeStatusAbilityActivationTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityActivationTypeService> _abilityActivationTypeServiceMock;
    private readonly Mock<IAbilityActivationTypeRepository> _ActivationTypeRepositoryMock;
    private readonly Mock<AbilityActivationTypeBusinessRules> _activationTypeBusinessRulesMock;

    public ChangeStatusAbilityActivationTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityActivationTypeServiceMock = new Mock<IAbilityActivationTypeService>();
        _ActivationTypeRepositoryMock = new Mock<IAbilityActivationTypeRepository>();
        _activationTypeBusinessRulesMock = new Mock<AbilityActivationTypeBusinessRules>();
    }


    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityActivationType_ChangeStatusHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityActivationTypeBusinessRules>(_ActivationTypeRepositoryMock.Object);

        var handler = new ChangeStatusAbilityActivationTypeHandler(_abilityActivationTypeServiceMock.Object, _activationTypeBusinessRulesMock.Object, _mapperMock.Object);

        var request = new ChangeStatusAbilityActivationTypeRequest
        {
            ChangeStatusAbilityActivationTypeDto = new ChangeStatusAbilityActivationTypeDto
            {
                Id = id
            }
        };

        var abilityActivationType = new AbilityActivationType
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new ChangeStatusAbilityActivationTypeResponse
        {
            Id = id,
            Status = !abilityActivationType.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityActivationType>(request.ChangeStatusAbilityActivationTypeDto))
                   .Returns(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.GetById(abilityActivationType.Id))
                                    .ReturnsAsync(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.Update(abilityActivationType))
                                    .ReturnsAsync(abilityActivationType);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityActivationTypeResponse>(abilityActivationType))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityActivationTypeServiceMock.Verify(m => m.GetById(abilityActivationType.Id), Times.Once);

    }
}
