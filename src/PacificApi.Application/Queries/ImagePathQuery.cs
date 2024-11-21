using MediatR;

namespace PacificApi.Application.Queries;

public  class ImagePathQuery : IRequest<string>
{
    public ImagePathQuery(string userIdentifier)
    {
        UserIdentifier = userIdentifier;
    }

    public string UserIdentifier { get; set; }
}