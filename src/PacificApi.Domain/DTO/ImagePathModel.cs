namespace PacificApi.Domain.DTO;

public record ImagePathModel
{
    public List<SingleImage> Images { get; set; }

   
}

public record SingleImage
{
    public int Id { get; set; }
    public string Url { get; set; }
}
