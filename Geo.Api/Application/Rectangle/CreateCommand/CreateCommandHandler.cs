using Geo.Api.Application.Configurations.Commands;
using Geo.Api.DataAccess;
using ValidationException = Geo.Api.Exceptions.ValidationException;

namespace Geo.Api.Application.Rectangle.CreateCommand;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly ApplicationDbContext _context;

    public CreateCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponse> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var validator = new Validators.CreateRequestValidator();
        var result = validator.Validate(command.Request);
        if (!result.IsValid)
        {
            throw new ValidationException(result);
        }

        var polygon = request.MapToGeometry();

        var rectangle = new Entities.Rectangle
        {
            Id = Guid.NewGuid(),
            Polygon = polygon
        };
        _context.Add(rectangle);
        await _context.SaveChangesAsync(cancellationToken);
        return new CreateResponse();
    }
}