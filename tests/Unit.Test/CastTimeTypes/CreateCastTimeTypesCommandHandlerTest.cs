using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Create;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.CastTimeTypes;

public class CreateCastTimeTypesCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ICastTimeTypeService> _resourceCastTimeTypeServiceMock;
    private readonly Mock<ICastTimeTypeRepository> _resourceCastTimeTypeRepositoryMock;
    private readonly Mock<CastTimeTypeBusinessRules> _resourceCastTimeTypeBusinessRulesMock;

    public CreateCastTimeTypesCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _resourceCastTimeTypeBusinessRulesMock = new Mock<CastTimeTypeBusinessRules>();
        _resourceCastTimeTypeServiceMock = new Mock<ICastTimeTypeService>();
        _resourceCastTimeTypeRepositoryMock = new Mock<ICastTimeTypeRepository>();
    }

    [Fact]
    public async Task CastTimeTypesHandler_ValidRequest_ReturnsResponse()
    {
        var businessRuleMock = new Mock<CastTimeTypeBusinessRules>(_resourceCastTimeTypeRepositoryMock.Object);

        var handler = new CreateCastTimeTypeCommandHandler(
            _resourceCastTimeTypeServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new CreateCastTimeTypeCommandRequest
        {
            CreateCastTimeTypeDto = new CreateCastTimeTypeDto
            {

                Name = "xxxxx",
                Description = "xxxx"

            }
        };

        var expectedCastTimeTypes = new Domain.Abilities.CastTimeType
        {
            Id = null,
            Name = request.CreateCastTimeTypeDto.Name,
            Description = request.CreateCastTimeTypeDto.Description,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new CreateCastTimeTypeCommandResponse
        {
            Id = null,
            Name = request.CreateCastTimeTypeDto.Name,
            Description = request.CreateCastTimeTypeDto.Description
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.CastTimeType>(request.CreateCastTimeTypeDto))
                   .Returns(expectedCastTimeTypes);

        _resourceCastTimeTypeServiceMock.Setup(m => m.Create(expectedCastTimeTypes))
                                    .ReturnsAsync(expectedCastTimeTypes);

        _mapperMock.Setup(m => m.Map<CreateCastTimeTypeCommandResponse>(expectedCastTimeTypes))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _resourceCastTimeTypeServiceMock.Verify(m => m.Create(expectedCastTimeTypes), Times.Once);
    }
}
