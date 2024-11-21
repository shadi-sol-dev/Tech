using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacificApi.Application.Queries;

namespace PacificApi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagePathController : ControllerBase
{
    IMediator _mediator;
    private readonly ILogger<ImagePathController> _logger;

    public ImagePathController(IMediator mediator, ILogger<ImagePathController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

   [HttpGet("/image/{userIdentifier}")]
    public async Task<JsonResult> Get(string userIdentifier)
    {
        var query = new ImagePathQuery(userIdentifier);
        string? path = await _mediator.Send(query);
        return !string.IsNullOrWhiteSpace(path) ? new JsonResult(Ok(path)) : new JsonResult(NotFound());
    }
}