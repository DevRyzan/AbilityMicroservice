using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityDamageTypes;

public class UndoDeleteAbilityDamageTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityDamageTypeService> _abilityDamageTypeServiceMock;
    private readonly Mock<IAbilityDamageTypeRepository> _abilityDamageTypeRepositoryMock;
    private readonly Mock<AbilityDamageTypeBusinessRules> _abilityDamageTypeBusinessRulesMock;

    public UndoDeleteAbilityDamageTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityDamageTypeServiceMock = new Mock<IAbilityDamageTypeService>();
        _abilityDamageTypeRepositoryMock = new Mock<IAbilityDamageTypeRepository>();
        _abilityDamageTypeBusinessRulesMock = new Mock<AbilityDamageTypeBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityAttackStat_UndoDeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityDamageTypeBusinessRules>(_abilityDamageTypeRepositoryMock.Object);

        var handler = new UndoDeleteAbilityDamageTypeHandler(_abilityDamageTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UndoDeleteAbilityDamageTypeRequest
        {
            UndoDeleteAbilityDamageTypeDto = new UndoDeleteAbilityDamageTypeDto
            {
                Id = id
            }
        };

        var abilityDamageType = new AbilityDamageType
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new UndoDeleteAbilityDamageTypeResponse
        {
            Id = id,
            Status = !abilityDamageType.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityDamageType>(request.UndoDeleteAbilityDamageTypeDto))
                   .Returns(abilityDamageType);

        _abilityDamageTypeServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityDamageType);

        _abilityDamageTypeServiceMock.Setup(m => m.Update(abilityDamageType))
                                        .ReturnsAsync(abilityDamageType);

        _mapperMock.Setup(m => m.Map<UndoDeleteAbilityDamageTypeResponse>(abilityDamageType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityDamageTypeServiceMock.Verify(m => m.GetById(abilityDamageType.Id), Times.Once);
        _abilityDamageTypeServiceMock.Verify(m => m.Update(abilityDamageType), Times.Once);
    }

}
