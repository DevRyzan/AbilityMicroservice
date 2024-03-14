using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityActivationTypes;

public  class UpdateAbilityActivationTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityActivationTypeService> _abilityActivationTypeServiceMock;
    private readonly Mock<IAbilityActivationTypeRepository> _activationTypeRepositoryMock;
    private readonly Mock<AbilityActivationTypeBusinessRules> _activationTypeBusinessRulesMock;

    public UpdateAbilityActivationTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityActivationTypeServiceMock = new Mock<IAbilityActivationTypeService>();
        _activationTypeRepositoryMock = new Mock<IAbilityActivationTypeRepository>();
        _activationTypeBusinessRulesMock = new Mock<AbilityActivationTypeBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32", "xxx", "xxxxx")]
    public async Task AbilityActivationType_UpdateHandler_ValidRequest_ReturnsResponse(string id, string name, string description)
    {
        var businessRuleMock = new Mock<AbilityActivationTypeBusinessRules>(_activationTypeRepositoryMock.Object);

        var handler = new UpdateAbilityActivationTypeHandler(
            _abilityActivationTypeServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new UpdateAbilityActivationTypeRequest
        {
            UpdateAbilityActivationTypeDto = new UpdateAbilityActivationTypeDto
            {
                Id = id,
                Name = name,
                Description = description
            }
        };

        var abilityActivationType = new AbilityActivationType
        {
            Id = id,
            Name = name,
            Description = description,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new UpdateAbilityActivationTypeResponse
        {
            Id = id,
            Name = "vvv",
            Description = "vvvvv",
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityActivationType>(request.UpdateAbilityActivationTypeDto))
                   .Returns(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityActivationType);

        _abilityActivationTypeServiceMock.Setup(m => m.Update(abilityActivationType))
                                    .ReturnsAsync(abilityActivationType);

        _mapperMock.Setup(m => m.Map<UpdateAbilityActivationTypeResponse>(abilityActivationType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityActivationTypeServiceMock.Verify(m => m.Update(abilityActivationType), Times.Once);
    }


}
