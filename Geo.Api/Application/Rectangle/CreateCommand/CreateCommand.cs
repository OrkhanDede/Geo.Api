using Geo.Api.Application.Configurations.Commands;

namespace Geo.Api.Application.Rectangle.CreateCommand;

public class CreateCommand : CommandBase<CreateResponse>
{
    public CreateRequest Request { get; }

    public CreateCommand(CreateRequest request)
    {
        Request = request ?? throw new ArgumentNullException(nameof(request));
    }
}