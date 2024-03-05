using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.CastTimeTypes;

public class RemoveCastTimeTypesCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ICastTimeTypeService> _resourceCastTimeTypeServiceMock;
    private readonly Mock<ICastTimeTypeRepository> _resourceCastTimeTypeRepositoryMock;
    private readonly Mock<CastTimeTypeBusinessRules> _resourceCastTimeTypeBusinessRulesMock;

    public RemoveCastTimeTypesCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _resourceCastTimeTypeBusinessRulesMock = new Mock<CastTimeTypeBusinessRules>();
        _resourceCastTimeTypeServiceMock = new Mock<ICastTimeTypeService>();
        _resourceCastTimeTypeRepositoryMock = new Mock<ICastTimeTypeRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task CastTimeTypesHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<CastTimeTypeBusinessRules>(_resourceCastTimeTypeRepositoryMock.Object);

        var handler = new RemoveCastTimeTypeCommandHandler(
            _resourceCastTimeTypeServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new RemoveCastTimeTypeCommandRequest
        {
             RemoveCastTimeTypeDto = new RemoveCastTimeTypeDto
             {
                Id = id
            }
        };

        var expectedCastTimeTypes = new Domain.Abilities.CastTimeType
        {
            Id = id,
            Status = false,
            IsDeleted = true
        };

        var expectedResponse = new RemoveCastTimeTypeCommandResponse
        {
            Id = id,
            Status = false,
            IsDeleted = true,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.CastTimeType>(request.RemoveCastTimeTypeDto))
                   .Returns(expectedCastTimeTypes);

        _resourceCastTimeTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(expectedCastTimeTypes);

        _resourceCastTimeTypeServiceMock.Setup(m => m.Remove(expectedCastTimeTypes))
                                    .ReturnsAsync(expectedCastTimeTypes);

        _mapperMock.Setup(m => m.Map<RemoveCastTimeTypeCommandResponse>(expectedCastTimeTypes))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _resourceCastTimeTypeServiceMock.Verify(m => m.Remove(expectedCastTimeTypes), Times.Once);

    }
}
