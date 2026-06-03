namespace Transporte_Web_Service.Entity
{
    public class Entity_TipoUnidad_Listar
    {
        public int IdTipoUnidad {  get; set; }
        public int IdEmpresa { get; set; }
        public string? Descripcion { get; set; }
        public byte Activo { get; set; }
    }
}
