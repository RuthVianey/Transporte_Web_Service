namespace Transporte_Web_Service.Security;

public sealed record LoginRequest(int IdEmpresa, int? IdSucursal, string Email, string Password);
public sealed record SelectSucursalRequest(int? IdSucursal);

public sealed record AuthSession(
    string Token,
    DateTime ExpiresAtUtc,
    int IdUsuario,
    int IdEmpresa,
    int? IdSucursal,
    string Email,
    IReadOnlyList<string> Roles,
    IReadOnlyList<string> Permissions);

public sealed record UserPermission(string ProgramKey, bool CanRead, bool CanWrite, bool CanDelete);
