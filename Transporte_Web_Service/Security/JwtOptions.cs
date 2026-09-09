namespace Transporte_Web_Service.Security;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";
    public string Issuer { get; init; } = "Transporte.Web.Service";
    public string Audience { get; init; } = "Transporte.Frontend";
    public string Key { get; init; } = string.Empty;
    public int ExpirationMinutes { get; init; } = 480;
}
