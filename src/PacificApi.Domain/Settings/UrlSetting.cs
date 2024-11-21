using System.Reflection.Metadata.Ecma335;

namespace PacificApi.Domain.Settings;

public class UrlSetting
{
    public string DefaultPath { get; set; }
    public string StaticEndingsPath { get; set; }
    public string VowelPath { get; set; }
    public string AlphaNumericPath { get; set; }
}