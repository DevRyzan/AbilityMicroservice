using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityAffectUnits;

public class ChangeStatusAbilityAffectUnitHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAffectUnitService> _abilityAffectUnitServiceMock;
    private readonly Mock<IAbilityAffectUnitRepository> _abilityAffectUnitRepositoryMock;
    private readonly Mock<AbilityAffectUnitBusinessRules> _abilityAffectUnitBusinessRulesMock;

    public ChangeStatusAbilityAffectUnitHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAffectUnitServiceMock = new Mock<IAbilityAffectUnitService>();
        _abilityAffectUnitRepositoryMock = new Mock<IAbilityAffectUnitRepository>();
        _abilityAffectUnitBusinessRulesMock = new Mock<AbilityAffectUnitBusinessRules>();
    }


    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityActivationType_ChangeStatusHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityAffectUnitBusinessRules>(_abilityAffectUnitRepositoryMock.Object);

        var handler = new ChangeStatusAbilityAffectUnitHandler(_abilityAffectUnitServiceMock.Object, _abilityAffectUnitBusinessRulesMock.Object, _mapperMock.Object);

        var request = new ChangeStatusAbilityAffectUnitRequest
        {
            ChangeStatusAbilityAffectUnitDto = new ChangeStatusAbilityAffectUnitDto
            {
                Id = id
            }
        };

        var abilityAffectUnit = new AbilityAffectUnit
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new ChangeStatusAbilityAffectUnitResponse
        {
            Id = id,
            Status = !abilityAffectUnit.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityAffectUnit>(request.ChangeStatusAbilityAffectUnitDto))
                   .Returns(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.GetById(abilityAffectUnit.Id))
                                    .ReturnsAsync(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.Update(abilityAffectUnit))
                                    .ReturnsAsync(abilityAffectUnit);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityAffectUnitResponse>(abilityAffectUnit))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityAffectUnitServiceMock.Verify(m => m.GetById(abilityAffectUnit.Id), Times.Once);
        _abilityAffectUnitServiceMock.Verify(m => m.Update(abilityAffectUnit), Times.Once);

    }

}
