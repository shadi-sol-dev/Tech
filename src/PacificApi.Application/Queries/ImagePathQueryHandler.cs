using System.Text.RegularExpressions;
using MediatR;
using Microsoft.Extensions.Options;
using PacificApi.Application.Interfaces;
using PacificApi.Domain.Entities;
using PacificApi.Domain.Settings;



namespace PacificApi.Application.Queries;

public class ImagePathQueryHandler:IRequestHandler<ImagePathQuery, string>  
{
private readonly IImageRepository _imageRepository;
private readonly UrlSetting _urlSetting;

public ImagePathQueryHandler(IImageRepository imageRepository,IOptions<UrlSetting> options)
{
    _imageRepository = imageRepository;
    _urlSetting = options.Value;
}

public async Task<string> Handle(ImagePathQuery request, CancellationToken cancellationToken)
    {
        string[] staticEndings = new[] {"6","7","8","9" };
        string[] dynamicEndings = new [] {"1","2","3","4","5" };
       
        if (string.IsNullOrWhiteSpace(request.UserIdentifier))
            return string.Empty;
        
        if (staticEndings.Any(request.UserIdentifier.EndsWith))
            return
                $"{_urlSetting.StaticEndingsPath}/{request.UserIdentifier.Substring(request.UserIdentifier.Length - 1)}";
              
       
        if (dynamicEndings.Any(request.UserIdentifier.EndsWith))
        {
            Images image;
            image = await  _imageRepository.GetByIdAsync(int.Parse(request.UserIdentifier.Substring(request.UserIdentifier.Length - 1)));
            return image.url;
        }
        
        if (Regex.IsMatch(request.UserIdentifier, "[aeiouAEIOU]"))
        {
            return _urlSetting.VowelPath;
        }
        
        if (Regex.IsMatch(request.UserIdentifier, "[^a-zA-Z0-9]"))
        {
            Random random = new Random();
            int randomSeed = random.Next(1, 6); 
            return $"{_urlSetting.AlphaNumericPath}={randomSeed}&size=150";
        }

        // Default case
        return _urlSetting.DefaultPath;
    }
}