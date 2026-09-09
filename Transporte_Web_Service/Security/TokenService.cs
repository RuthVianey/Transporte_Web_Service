using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Transporte_Web_Service.Security;

public sealed class TokenService
{
    private readonly JwtOptions _options;

    public TokenService(IOptions<JwtOptions> options) => _options = options.Value;

    public AuthSession Create(int idUsuario, int idEmpresa, int? idSucursal, string email, IReadOnlyList<string> roles, IReadOnlyList<string> permissions)
    {
        var expiresAt = DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, idUsuario.ToString()),
            new("empresa", idEmpresa.ToString()),
            new(ClaimTypes.Email, email),
        };
        if (idSucursal.HasValue) claims.Add(new Claim("sucursal", idSucursal.Value.ToString()));
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        claims.AddRange(permissions.Select(permission => new Claim("permission", permission)));
        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(_options.Issuer, _options.Audience, claims, expires: expiresAt, signingCredentials: credentials);
        return new AuthSession(new JwtSecurityTokenHandler().WriteToken(token), expiresAt, idUsuario, idEmpresa, idSucursal, email, roles, permissions);
    }
}
