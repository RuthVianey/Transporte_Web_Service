namespace Transporte_Web_Service.Entity
{
    public class Entity_Listar_Roles
    {
        public int IdRol { set; get; }
        public int IdEmpresa { set; get; }
        public string? Nombre { set; get; }
        public byte Activo { set; get; }
    }

    public class Entity_RolPrograma_ListarPorRol
    {
        public int IdRolPrograma { set; get; }
        public int IdRol { set; get; }
        public string? Rol { set; get; }
        public int IdPrograma { set; get; }
        public string? Programa { set; get; }
        public string? Clave { set; get; }
        public byte PuedeLeer { set; get; }
        public byte PuedeEscribir { set; get; }
        public byte PuedeEliminar { set; get; }
    }
    public class Entity_UsuarioRol_ListarPorUsuario
    {
        public int IdUsuarioRol { get; set; }
        public int IdUsuario { get; set; }
        public string? Usuario { get; set; }
        public int IdRol { get; set; }
        public string? Rol { get; set; }
    }
}