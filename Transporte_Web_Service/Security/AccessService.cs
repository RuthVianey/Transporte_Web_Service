using Transporte_Web_Service.Data;

namespace Transporte_Web_Service.Security;

public sealed class AccessService
{
    private readonly RolesDAL _rolesDal;
    public AccessService(RolesDAL rolesDal) => _rolesDal = rolesDal;

    public async Task<(IReadOnlyList<string> Roles, IReadOnlyList<string> Permissions)> GetForUser(int idEmpresa, int idUsuario)
    {
        var roles = (await _rolesDal.Dal_UsuarioRol_ListarPorUsuario(idUsuario, idEmpresa))
            .Select(item => item?.Rol?.Trim()).Where(role => !string.IsNullOrWhiteSpace(role)).Cast<string>()
            .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        if (roles.Any(role => role.Equals("Administrador", StringComparison.OrdinalIgnoreCase))) return (roles, new[] { "*" });
        var permissions = (await _rolesDal.Dal_PermisosUsuario(idEmpresa, idUsuario))
            .SelectMany(item => new[] { item.CanRead ? $"{item.ProgramKey}:R" : null, item.CanWrite ? $"{item.ProgramKey}:W" : null, item.CanDelete ? $"{item.ProgramKey}:D" : null })
            .Where(permission => permission is not null).Cast<string>().Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        return (roles, permissions);
    }
}
