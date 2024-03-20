using Application.Feature.AbilityFeatures.AbilityCombo.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityCombos;

public class ChangeStatusAbilityComboHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityComboService> _abilityComboServiceMock;
    private readonly Mock<IAbilityComboRepository> _abilityComboRepositoryMock;
    private readonly Mock<AbilityComboBusinessRules> _abilityComboBusinessRulesMock;

    public ChangeStatusAbilityComboHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityComboServiceMock = new Mock<IAbilityComboService>();
        _abilityComboRepositoryMock = new Mock<IAbilityComboRepository>();
        _abilityComboBusinessRulesMock = new Mock<AbilityComboBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityCombo_ChangeStatusHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityComboBusinessRules>(_abilityComboRepositoryMock.Object);

        var handler = new ChangeStatusAbilityComboCommandHandler(_abilityComboServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new ChangeStatusAbilityComboCommandRequest
        {
            ChangeStatusAbilityComboDto = new ChangeStatusAbilityComboDto
            {
                Id = id
            }
        };

        var abilityCombo = new AbilityCombo
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new ChangeStatusAbilityComboCommandResponse
        {
            Id = id,
            Status = !abilityCombo.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityCombo>(request.ChangeStatusAbilityComboDto))
                   .Returns(abilityCombo);

        _abilityComboServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityCombo);

        _abilityComboServiceMock.Setup(m => m.Update(abilityCombo))
                                    .ReturnsAsync(abilityCombo);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityComboCommandResponse>(abilityCombo))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityComboServiceMock.Verify(m => m.GetById(abilityCombo.Id), Times.Once);
    }
}
