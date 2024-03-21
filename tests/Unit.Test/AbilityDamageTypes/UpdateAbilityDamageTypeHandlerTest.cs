using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityDamageTypes;

public class UpdateAbilityDamageTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityDamageTypeService> _abilityDamageTypeServiceMock;
    private readonly Mock<IAbilityDamageTypeRepository> _abilityDamageTypeRepositoryMock;
    private readonly Mock<AbilityDamageTypeBusinessRules> _abilityDamageTypeBusinessRulesMock;

    public UpdateAbilityDamageTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityDamageTypeServiceMock = new Mock<IAbilityDamageTypeService>();
        _abilityDamageTypeRepositoryMock = new Mock<IAbilityDamageTypeRepository>();
        _abilityDamageTypeBusinessRulesMock = new Mock<AbilityDamageTypeBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32", "xxx", "xxxxx")]
    public async Task AbilityTargetTypeHandler_ValidRequest_ReturnsResponse(string id, string name, string description)
    {
        var businessRuleMock = new Mock<AbilityDamageTypeBusinessRules>(_abilityDamageTypeRepositoryMock.Object);

        var handler = new UpdateAbilityDamageTypeHandler(_abilityDamageTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityDamageTypeRequest
        {
            UpdateAbilityDamageTypeDto = new UpdateAbilityDamageTypeDto
            {
                Id = id,
                Name = name,
                Description = description
            }
        };

        var abilityDamageType = new AbilityDamageType
        {
            Id = id,
            Name = name,
            Description = description,
            IsDeleted = true,
            Status = false
        };

        var expectedResponse = new UpdateAbilityDamageTypeResponse
        {
            Id = id,
            Name = name,
            Description = description,
            IsDeleted = true,
            Status = false

        };

        _mapperMock.Setup(m => m.Map<AbilityDamageType>(request.UpdateAbilityDamageTypeDto))
                   .Returns(abilityDamageType);

        _abilityDamageTypeServiceMock.Setup(m => m.GetById(abilityDamageType.Id))
                            .ReturnsAsync(abilityDamageType);

        _abilityDamageTypeServiceMock.Setup(m => m.Update(abilityDamageType))
                                    .ReturnsAsync(abilityDamageType);

        _mapperMock.Setup(m => m.Map<UpdateAbilityDamageTypeResponse>(abilityDamageType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityDamageTypeServiceMock.Verify(m => m.GetById(abilityDamageType.Id), Times.Once);
        _abilityDamageTypeServiceMock.Verify(m => m.Update(abilityDamageType), Times.Once);
    }

}
