using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacificApi.Application.Queries;

namespace PacificApi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagePathController(IMediator mediator, ILogger<ImagePathController> logger) : ControllerBase
{
    private readonly ILogger<ImagePathController> _logger = logger;

    [HttpGet("/image")]
    public async Task<JsonResult> Get(string userIdentifier)
    {
        var query = new ImagePathQuery(userIdentifier);
        string? path = await mediator.Send(query);
        return new JsonResult(new {url = path});
    }
    
}