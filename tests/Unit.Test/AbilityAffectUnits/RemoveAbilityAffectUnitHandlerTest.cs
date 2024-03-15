using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAffectUnits;

public class RemoveAbilityAffectUnitHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAffectUnitService> _abilityAffectUnitServiceMock;
    private readonly Mock<IAbilityAffectUnitRepository> _abilityAffectUnitRepositoryMock;
    private readonly Mock<AbilityAffectUnitBusinessRules> _abilityAffectUnitBusinessRulesMock;

    public RemoveAbilityAffectUnitHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAffectUnitServiceMock = new Mock<IAbilityAffectUnitService>();
        _abilityAffectUnitRepositoryMock = new Mock<IAbilityAffectUnitRepository>();
        _abilityAffectUnitBusinessRulesMock = new Mock<AbilityAffectUnitBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityActivationType_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityAffectUnitBusinessRules>(_abilityAffectUnitRepositoryMock.Object);

        var handler = new RemoveAbilityAffectUnitHandler(_abilityAffectUnitServiceMock.Object, _abilityAffectUnitBusinessRulesMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityAffectUnitRequest
        {
            RemoveAbilityAffectUnitDto = new RemoveAbilityAffectUnitDto
            {
                Id = id
            }
        };

        var abilityAffectUnit = new AbilityAffectUnit
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new RemoveAbilityAffectUnitResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityAffectUnit>(request.RemoveAbilityAffectUnitDto))
                   .Returns(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.Remove(abilityAffectUnit))
                                        .ReturnsAsync(abilityAffectUnit);

        _mapperMock.Setup(m => m.Map<RemoveAbilityAffectUnitResponse>(abilityAffectUnit))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityAffectUnitServiceMock.Verify(m => m.GetById(abilityAffectUnit.Id), Times.Once);
        _abilityAffectUnitServiceMock.Verify(m => m.Remove(abilityAffectUnit), Times.Once);

    }

}