using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityCombos;

public class UpdateAbilityComboHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityComboDtoTestData()
    {
        yield return new object[] { new UpdateAbilityComboDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityComboService> _abilityComboServiceMock;
    private readonly Mock<IAbilityComboRepository> _abilityComboRepositoryMock;
    private readonly Mock<AbilityComboBusinessRules> _abilityComboBusinessRulesMock;

    public UpdateAbilityComboHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityComboServiceMock = new Mock<IAbilityComboService>();
        _abilityComboRepositoryMock = new Mock<IAbilityComboRepository>();
        _abilityComboBusinessRulesMock = new Mock<AbilityComboBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityComboDtoTestData))]
    public async Task AbilityAllyEffectStat_UpdateHandler_ValidRequest_ReturnsResponse(UpdateAbilityComboDto updateAbilityComboDto)
    {
        var businessRuleMock = new Mock<AbilityComboBusinessRules>(_abilityComboRepositoryMock.Object);

        var handler = new UpdateAbilityComboCommandHandler(_abilityComboServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityComboCommandRequest
        {
            UpdateAbilityComboDto = updateAbilityComboDto
        };

        var abilityCombo = new AbilityCombo
        {
            Id = request.UpdateAbilityComboDto.Id,
            AbilityId = request.UpdateAbilityComboDto.AbilityId
        };

        var expectedResponse = new UpdateAbilityComboCommandResponse
        {
            Id = request.UpdateAbilityComboDto.Id,
            AbilityId = request.UpdateAbilityComboDto.AbilityId
        };

        _mapperMock.Setup(m => m.Map<AbilityCombo>(request.UpdateAbilityComboDto))
                   .Returns(abilityCombo);

        _abilityComboServiceMock.Setup(m => m.GetById(abilityCombo.Id))
                                    .ReturnsAsync(abilityCombo);

        _abilityComboServiceMock.Setup(m => m.Update(abilityCombo))
                                    .ReturnsAsync(abilityCombo);

        _mapperMock.Setup(m => m.Map<UpdateAbilityComboCommandResponse>(abilityCombo))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityComboServiceMock.Verify(m => m.GetById(abilityCombo.Id), Times.Once);
        _abilityComboServiceMock.Verify(m => m.Update(abilityCombo), Times.Once);
    }
}