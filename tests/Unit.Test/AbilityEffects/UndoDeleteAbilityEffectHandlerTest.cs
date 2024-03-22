using Application.Feature.AbilityFeatures.AbilityEffects.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityEffects;

public class UndoDeleteAbilityEffectHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectService> _abilityEffectServiceMock;
    private readonly Mock<IAbilityEffectRepository> _abilityEffectRepositoryMock;
    private readonly Mock<AbilityEffectBusinessRules> _abilityEffectBusinessRulesMock;

    public UndoDeleteAbilityEffectHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectServiceMock = new Mock<IAbilityEffectService>();
        _abilityEffectRepositoryMock = new Mock<IAbilityEffectRepository>();
        _abilityEffectBusinessRulesMock = new Mock<AbilityEffectBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityEffect_UndoDeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEffectBusinessRules>(_abilityEffectRepositoryMock.Object);

        var handler = new UndoDeleteAbilityEffectHandler(_abilityEffectServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UndoDeleteAbilityEffectRequest
        {
            UndoDeleteAbilityEffectDto = new UndoDeleteAbilityEffectDto
            {
                Id = id
            }
        };

        var abilityEffect = new AbilityEffect
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new UndoDeleteAbilityEffectResponse
        {
            Id = id,
            Status = !abilityEffect.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityEffect>(request.UndoDeleteAbilityEffectDto))
                   .Returns(abilityEffect);

        _abilityEffectServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityEffect);

        _abilityEffectServiceMock.Setup(m => m.Update(abilityEffect))
                                        .ReturnsAsync(abilityEffect);

        _mapperMock.Setup(m => m.Map<UndoDeleteAbilityEffectResponse>(abilityEffect))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityEffectServiceMock.Verify(m => m.GetById(abilityEffect.Id), Times.Once);
        _abilityEffectServiceMock.Verify(m => m.Update(abilityEffect), Times.Once);
    }
}
