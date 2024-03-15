using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityAffectUnits;

public class DeleteAbilityAffectUnitHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAffectUnitService> _abilityAffectUnitServiceMock;
    private readonly Mock<IAbilityAffectUnitRepository> _abilityAffectUnitRepositoryMock;
    private readonly Mock<AbilityAffectUnitBusinessRules> _abilityAffectUnitBusinessRulesMock;

    public DeleteAbilityAffectUnitHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAffectUnitServiceMock = new Mock<IAbilityAffectUnitService>();
        _abilityAffectUnitRepositoryMock = new Mock<IAbilityAffectUnitRepository>();
        _abilityAffectUnitBusinessRulesMock = new Mock<AbilityAffectUnitBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityActivationType_DeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityAffectUnitBusinessRules>(_abilityAffectUnitRepositoryMock.Object);

        var handler = new DeleteAbilityAffectUnitHandler(_abilityAffectUnitServiceMock.Object, _abilityAffectUnitBusinessRulesMock.Object, _mapperMock.Object);

        var request = new DeleteAbilityAffectUnitRequest
        {
            DeleteAbilityAffectUnitDto = new DeleteAbilityAffectUnitDto
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

        var expectedResponse = new DeleteAbilityAffectUnitResponse
        {
            Id = id,
            Status = !abilityAffectUnit.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityAffectUnit>(request.DeleteAbilityAffectUnitDto))
                   .Returns(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.Delete(abilityAffectUnit))
                                        .ReturnsAsync(abilityAffectUnit);

        _mapperMock.Setup(m => m.Map<DeleteAbilityAffectUnitResponse>(abilityAffectUnit))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityAffectUnitServiceMock.Verify(m => m.GetById(abilityAffectUnit.Id), Times.Once);
        _abilityAffectUnitServiceMock.Verify(m => m.Delete(abilityAffectUnit), Times.Once);
    }

}
