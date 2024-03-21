using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityEffectDisableTypes;

public class UpdateAbilityEffectDisableTypeHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityEffectDisableTypeDtoTestData()
    {
        yield return new object[] { new UpdateAbilityEffectDisableTypeDto {
            Name = "name",
            Description = "description"
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectDisableTypeService> _abilityEffectDisableTypeServiceMock;
    private readonly Mock<IAbilityEffectDisableTypeRepository> _abilityEffectDisableTypeRepositoryMock;
    private readonly Mock<AbilityEffectDisableTypeBusinessRules> _abilityEffectDisableTypeBusinessRulesMock;

    public UpdateAbilityEffectDisableTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectDisableTypeServiceMock = new Mock<IAbilityEffectDisableTypeService>();
        _abilityEffectDisableTypeRepositoryMock = new Mock<IAbilityEffectDisableTypeRepository>();
        _abilityEffectDisableTypeBusinessRulesMock = new Mock<AbilityEffectDisableTypeBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityEffectDisableTypeDtoTestData))]
    public async Task AbilityEffectDisableType_UpdateHandler_ValidRequest_ReturnsResponse(UpdateAbilityEffectDisableTypeDto updateAbilityEffectDisableTypeDto)
    {
        var businessRuleMock = new Mock<AbilityEffectDisableTypeBusinessRules>(_abilityEffectDisableTypeRepositoryMock.Object);

        var handler = new UpdateAbilityEffectDisableTypeHandler(_abilityEffectDisableTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityEffectDisableTypeRequest
        {
            UpdateAbilityEffectDisableTypeDto = updateAbilityEffectDisableTypeDto
        };

        var abilityEffectDisableType = new AbilityEffectDisableType
        {
            Id = request.UpdateAbilityEffectDisableTypeDto.Id,
            Name = request.UpdateAbilityEffectDisableTypeDto.Name
        };

        var expectedResponse = new UpdateAbilityEffectDisableTypeResponse
        {
            Id = request.UpdateAbilityEffectDisableTypeDto.Id,
            Name = request.UpdateAbilityEffectDisableTypeDto.Name
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectDisableType>(request.UpdateAbilityEffectDisableTypeDto))
                   .Returns(abilityEffectDisableType);

        _abilityEffectDisableTypeServiceMock.Setup(m => m.GetById(abilityEffectDisableType.Id))
                                    .ReturnsAsync(abilityEffectDisableType);

        _abilityEffectDisableTypeServiceMock.Setup(m => m.Update(abilityEffectDisableType))
                                    .ReturnsAsync(abilityEffectDisableType);

        _mapperMock.Setup(m => m.Map<UpdateAbilityEffectDisableTypeResponse>(abilityEffectDisableType))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectDisableTypeServiceMock.Verify(m => m.GetById(abilityEffectDisableType.Id), Times.Once);
        _abilityEffectDisableTypeServiceMock.Verify(m => m.Update(abilityEffectDisableType), Times.Once);
    }

}
