using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffectDisableTypes;

public class ChangeStatusAbilityEffectDisableTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectDisableTypeService> _abilityEffectDisableTypeServiceMock;
    private readonly Mock<IAbilityEffectDisableTypeRepository> _abilityEffectDisableTypeRepositoryMock;
    private readonly Mock<AbilityEffectDisableTypeBusinessRules> _abilityEffectDisableTypeBusinessRulesMock;

    public ChangeStatusAbilityEffectDisableTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectDisableTypeServiceMock = new Mock<IAbilityEffectDisableTypeService>();
        _abilityEffectDisableTypeRepositoryMock = new Mock<IAbilityEffectDisableTypeRepository>();
        _abilityEffectDisableTypeBusinessRulesMock = new Mock<AbilityEffectDisableTypeBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityEffectDisableType_ChangeStatusHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEffectDisableTypeBusinessRules>(_abilityEffectDisableTypeRepositoryMock.Object);

        var handler = new ChangeStatusAbilityEffectDisableTypeHandler(_abilityEffectDisableTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new ChangeStatusAbilityEffectDisableTypeRequest
        {
            ChangeStatusAbilityEffectDisableTypeDto = new ChangeStatusAbilityEffectDisableTypeDto
            {
                Id = id
            }
        };

        var abilityEffectDisableType = new AbilityEffectDisableType
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new ChangeStatusAbilityEffectDisableTypeResponse
        {
            Id = id,
            Status = !abilityEffectDisableType.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectDisableType>(request.ChangeStatusAbilityEffectDisableTypeDto))
                   .Returns(abilityEffectDisableType);

        _abilityEffectDisableTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityEffectDisableType);

        _abilityEffectDisableTypeServiceMock.Setup(m => m.Update(abilityEffectDisableType))
                                    .ReturnsAsync(abilityEffectDisableType);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityEffectDisableTypeResponse>(abilityEffectDisableType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityEffectDisableTypeServiceMock.Verify(m => m.GetById(abilityEffectDisableType.Id), Times.Once);
        _abilityEffectDisableTypeServiceMock.Verify(m => m.Update(abilityEffectDisableType), Times.Once);
    }
}
