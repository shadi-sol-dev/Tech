using MediatR;

namespace PacificApi.Application.Commands;

public class SaveImagePathCommand:IRequest<bool>  
{
    public List<SingleImage> Images { get; set; }
  
}

public record SingleImage
{
    public int Id { get; set; }
    public string Url { get; set; }
}