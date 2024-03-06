using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.AbilityTargetType;

public class DeleteAbilityTargetTypeCommandHandlerTest
{

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityTargetTypeService> _abilityTargetTypeServiceMock;
    private readonly Mock<IAbilityTargetTypeRepository> _abilityTargetTypeRepositoryMock;
    private readonly Mock<IAbilityRepository> _abilityRepositoryMock;
    private readonly Mock<AbilityTargetTypeBusinessRules> _abilityTargetTypeBusinessRulesMock;

    public DeleteAbilityTargetTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityTargetTypeBusinessRulesMock = new Mock<AbilityTargetTypeBusinessRules>();
        _abilityTargetTypeServiceMock = new Mock<IAbilityTargetTypeService>();
        _abilityTargetTypeRepositoryMock = new Mock<IAbilityTargetTypeRepository>();
        _abilityRepositoryMock = new Mock<IAbilityRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityTargetTypeHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityTargetTypeBusinessRules>(_abilityTargetTypeRepositoryMock.Object, _abilityRepositoryMock.Object);

        var handler = new DeleteAbilityTargetTypeCommandHandler(_mapperMock.Object, businessRuleMock.Object, _abilityTargetTypeServiceMock.Object);

        var request = new DeleteAbilityTargetTypeCommandRequest
        {
            DeleteAbilityTargetTypeDto = new DeleteAbilityTargetTypeDto
            {
                Id = id
            }
        };

        var abilityTargetType = new Domain.Abilities.AbilityTargetType
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new DeleteAbilityTargetTypeCommandResponse
        {
            Id = id,
            IsDeleted = false,
            Status = true

        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityTargetType>(request.DeleteAbilityTargetTypeDto))
                   .Returns(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.GetById(abilityTargetType.Id))
                            .ReturnsAsync(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.Delete(abilityTargetType))
                                    .ReturnsAsync(abilityTargetType);

        _mapperMock.Setup(m => m.Map<DeleteAbilityTargetTypeCommandResponse>(abilityTargetType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityTargetTypeServiceMock.Verify(m => m.Delete(abilityTargetType), Times.Once);
    }
}
