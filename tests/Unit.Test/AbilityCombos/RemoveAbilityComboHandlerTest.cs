using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityCombos;

public class RemoveAbilityComboHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityComboService> _abilityComboServiceMock;
    private readonly Mock<IAbilityComboRepository> _abilityComboRepositoryMock;
    private readonly Mock<AbilityComboBusinessRules> _abilityComboBusinessRulesMock;

    public RemoveAbilityComboHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityComboServiceMock = new Mock<IAbilityComboService>();
        _abilityComboRepositoryMock = new Mock<IAbilityComboRepository>();
        _abilityComboBusinessRulesMock = new Mock<AbilityComboBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityActivationType_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityComboBusinessRules>(_abilityComboRepositoryMock.Object);

        var handler = new RemoveAbilityComboCommandHandler(_abilityComboServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityComboCommandRequest
        {
            RemoveAbilityComboDto = new RemoveAbilityComboDto
            {
                Id = id
            }
        };

        var abilityCombo = new AbilityCombo
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new RemoveAbilityComboCommandResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityCombo>(request.RemoveAbilityComboDto))
                   .Returns(abilityCombo);

        _abilityComboServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityCombo);

        _abilityComboServiceMock.Setup(m => m.Remove(abilityCombo))
                                        .ReturnsAsync(abilityCombo);

        _mapperMock.Setup(m => m.Map<RemoveAbilityComboCommandResponse>(abilityCombo))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityComboServiceMock.Verify(m => m.GetById(abilityCombo.Id), Times.Once);
        _abilityComboServiceMock.Verify(m => m.Remove(abilityCombo), Times.Once);

    }

}
