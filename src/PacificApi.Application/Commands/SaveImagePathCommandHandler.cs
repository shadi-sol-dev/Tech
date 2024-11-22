using MediatR;
using PacificApi.Application.Interfaces;
using PacificApi.Domain.Entities;

namespace PacificApi.Application.Commands;

public class SaveImagePathCommandHandler : IRequestHandler<SaveImagePathCommand, bool>
{
    private readonly IImageRepository _repository;  
    public SaveImagePathCommandHandler(IImageRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(SaveImagePathCommand request, CancellationToken cancellationToken)
    {
        foreach (var imagePath in request.Images)   
        await _repository.AddAsync(new Images(){id = imagePath.Id, url = imagePath.Url});
        return true;
    }
}