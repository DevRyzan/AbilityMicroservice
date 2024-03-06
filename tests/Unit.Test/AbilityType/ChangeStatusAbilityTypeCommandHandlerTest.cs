using Application.Feature.AbilityFeatures.AbilityTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using Application.Service.AbilityServices.CastTimeTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.AbilityType;

public class ChangeStatusAbilityTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityTypeService> _abilityTypeServiceMock;
    private readonly Mock<IAbilityTypeRepository> _abilityTypeRepositoryMock;
    private readonly Mock<AbilityTypeBusinessRules> _abilityTypeBusinessRulesMock;

    public ChangeStatusAbilityTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityTypeBusinessRulesMock = new Mock<AbilityTypeBusinessRules>();
        _abilityTypeServiceMock = new Mock<IAbilityTypeService>();
        _abilityTypeRepositoryMock = new Mock<IAbilityTypeRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityTypeHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityTypeBusinessRules>(_abilityTypeRepositoryMock.Object);

        var handler = new ChangeStatusAbilityTypeCommandHandler(
            _abilityTypeServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new ChangeStatusAbilityTypeCommandRequest
        {
             ChangeStatusAbilityTypeDto = new ChangeStatusAbilityTypeDto
             {
                Id = id
            }
        };

        var abilityTypes = new Domain.Abilities.AbilityType
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new ChangeStatusAbilityTypeCommandResponse
        {
            Id = id,
            Status = !abilityTypes.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityType>(request.ChangeStatusAbilityTypeDto))
                   .Returns(abilityTypes);

        _abilityTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityTypes);

        _abilityTypeServiceMock.Setup(m => m.Update(abilityTypes))
                                    .ReturnsAsync(abilityTypes);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityTypeCommandResponse>(abilityTypes))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityTypeServiceMock.Verify(m => m.GetById(abilityTypes.Id), Times.Once);
    }
}
