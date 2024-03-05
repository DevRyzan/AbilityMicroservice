using Application.Feature.AbilityFeatures.ResourceCostType.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Delete;
using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.ResourceCostType;

public class DeleteResourceCostTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IResourceCostTypeService> _resourceCostTypeServiceMock;
    private readonly Mock<IResourceCostTypeRepository> _resourceCostTypeRepositoryMock;
    private readonly Mock<ResourceCostTypeBusinessRules> _resourceCostTypeBusinessRulesMock;

    public DeleteResourceCostTypeCommandHandlerTest()
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

        var handler = new DeleteResourceCostTypeCommandHandler(
            _mapperMock.Object,
            _resourceCostTypeServiceMock.Object,
            businessRuleMock.Object
        );

        var request = new DeleteResourceCostTypeCommandRequest
        {
             DeleteResourcesCostTypeDto = new DeleteResourcesCostTypeDto
             {
                Id = id
            }
        };

        var expectedResourceCostType = new Domain.Abilities.ResourceCostType
        {
            Id = id,
            Name = "xxxxxxxxxx",
            Code = "19805-GBIT-272",
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new DeleteResourceCostTypeCommandResponse
        {
            Id = id,
            Name = "xxxxxxxxxx",
            Code = "19805-GBIT-272",
            Status = expectedResourceCostType.Status,
            IsDeleted = true,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.ResourceCostType>(request.DeleteResourcesCostTypeDto))
                   .Returns(expectedResourceCostType);

        _resourceCostTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(expectedResourceCostType);

        _resourceCostTypeServiceMock.Setup(m => m.Delete(expectedResourceCostType))
                                    .ReturnsAsync(expectedResourceCostType);

        _mapperMock.Setup(m => m.Map<DeleteResourceCostTypeCommandResponse>(expectedResourceCostType))
                   .Returns(expectedResponse);


        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.IsDeleted, response.IsDeleted);

        _resourceCostTypeServiceMock.Verify(m => m.Delete(expectedResourceCostType), Times.Once);
    }
}
