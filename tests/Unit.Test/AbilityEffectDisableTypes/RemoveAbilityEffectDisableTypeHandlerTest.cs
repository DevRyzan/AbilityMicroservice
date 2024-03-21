using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffectDisableTypes;

public class RemoveAbilityEffectDisableTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectDisableTypeService> _abilityEffectDisableTypeServiceMock;
    private readonly Mock<IAbilityEffectDisableTypeRepository> _abilityEffectDisableTypeRepositoryMock;
    private readonly Mock<AbilityEffectDisableTypeBusinessRules> _abilityEffectDisableTypeBusinessRulesMock;

    public RemoveAbilityEffectDisableTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectDisableTypeServiceMock = new Mock<IAbilityEffectDisableTypeService>();
        _abilityEffectDisableTypeRepositoryMock = new Mock<IAbilityEffectDisableTypeRepository>();
        _abilityEffectDisableTypeBusinessRulesMock = new Mock<AbilityEffectDisableTypeBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityDamageType_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEffectDisableTypeBusinessRules>(_abilityEffectDisableTypeRepositoryMock.Object);

        var handler = new RemoveAbilityEffectDisableTypeHandler(_abilityEffectDisableTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityEffectDisableTypeRequest
        {
            RemoveAbilityEffectDisableTypeDto = new RemoveAbilityEffectDisableTypeDto
            {
                Id = id
            }
        };

        var abilityEffectDisableType = new AbilityEffectDisableType
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new RemoveAbilityEffectDisableTypeResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectDisableType>(request.RemoveAbilityEffectDisableTypeDto))
                   .Returns(abilityEffectDisableType);

        _abilityEffectDisableTypeServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityEffectDisableType);

        _abilityEffectDisableTypeServiceMock.Setup(m => m.Remove(abilityEffectDisableType))
                                        .ReturnsAsync(abilityEffectDisableType);

        _mapperMock.Setup(m => m.Map<RemoveAbilityEffectDisableTypeResponse>(abilityEffectDisableType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectDisableTypeServiceMock.Verify(m => m.GetById(abilityEffectDisableType.Id), Times.Once);
        _abilityEffectDisableTypeServiceMock.Verify(m => m.Remove(abilityEffectDisableType), Times.Once);
    }
}
