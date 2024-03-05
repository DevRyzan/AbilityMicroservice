using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Delete;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Remove;
using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.ResourceCostType;

public class RemoveResourceCostTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IResourceCostTypeService> _resourceCostTypeServiceMock;
    private readonly Mock<IResourceCostTypeRepository> _resourceCostTypeRepositoryMock;
    private readonly Mock<ResourceCostTypeBusinessRules> _resourceCostTypeBusinessRulesMock;

    public RemoveResourceCostTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _resourceCostTypeBusinessRulesMock = new Mock<ResourceCostTypeBusinessRules>();
        _resourceCostTypeServiceMock = new Mock<IResourceCostTypeService>();
        _resourceCostTypeRepositoryMock = new Mock<IResourceCostTypeRepository>();
    }


    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task ResourceCostTypeHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<ResourceCostTypeBusinessRules>(_resourceCostTypeRepositoryMock.Object);

        var handler = new RemoveResourceCostTypeCommandHandler(
            _mapperMock.Object,
            _resourceCostTypeServiceMock.Object,
            businessRuleMock.Object
        );

        var request = new RemoveResourceCostTypeCommandRequest
        {
             RemoveResourcesCostTypeDto = new RemoveResourcesCostTypeDto
             {
                Id = id
            }
        };

        var expectedResourceCostType = new Domain.Abilities.ResourceCostType
        {
            Id = id,
            Name = "xxxxxxxxxx",
            Code = "19805-GBIT-272",
            Status = false,
            IsDeleted = true
        };

        var expectedResponse = new RemoveResourceCostTypeCommandResponse
        {
            Id = id,
            Name = "xxxxxxxxxx",
            Code = "19805-GBIT-272",
            Status = false,
            IsDeleted = true,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.ResourceCostType>(request.RemoveResourcesCostTypeDto))
                   .Returns(expectedResourceCostType);

        _resourceCostTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(expectedResourceCostType);

        _resourceCostTypeServiceMock.Setup(m => m.Remove(expectedResourceCostType))
                                    .ReturnsAsync(expectedResourceCostType);

        _mapperMock.Setup(m => m.Map<RemoveResourceCostTypeCommandResponse>(expectedResourceCostType))
                   .Returns(expectedResponse);


        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _resourceCostTypeServiceMock.Verify(m => m.Remove(expectedResourceCostType), Times.Once);
    }
}
