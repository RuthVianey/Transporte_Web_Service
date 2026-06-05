//git push origin master --force

using Microsoft.EntityFrameworkCore;
using static Transporte_Web_Service.Entity.Respuesta;

namespace Transporte_Web_Service.Entity
{
    public class MiDbContext : DbContext
    {
        public MiDbContext(DbContextOptions<MiDbContext> options)
            : base(options)
        {
        }

        //Lista de lo que regresara las base conctado a la base
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity_CargaCombustible_ListarPorViaje>().HasNoKey();
            modelBuilder.Entity<Entity_CargaCombustible_ObtenerPorId>().HasNoKey();
            modelBuilder.Entity<Entity_Dashboard_CostosPorTipo>().HasNoKey();
            modelBuilder.Entity<Entity_Dashboard_RentabilidadMensual>().HasNoKey();
            modelBuilder.Entity<Entity_Dashboard_ResumenOperativo>().HasNoKey();
            modelBuilder.Entity<Entity_Dashboard_TopClientes>().HasNoKey();
            modelBuilder.Entity<Entity_Dashboard_TopUnidades>().HasNoKey();
            modelBuilder.Entity<Entity_Dashboard_ViajesPorEstado>().HasNoKey();
            modelBuilder.Entity<Entity_Empresa_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_EstadoViaje_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_Gasto_ListarPorViaje>().HasNoKey();
            modelBuilder.Entity<Entity_Gasto_ObtenerPorId>().HasNoKey();
            modelBuilder.Entity<Entity_Listar_Roles>().HasNoKey();
            modelBuilder.Entity<Entity_Lista_Programa>().HasNoKey();
            modelBuilder.Entity<Entity_Lista_Roles>().HasNoKey();
            modelBuilder.Entity<Entity_Lista_Usuario>().HasNoKey();
            modelBuilder.Entity<Entity_MantenimientoConcepto_ObtenerPorId>().HasNoKey();
            modelBuilder.Entity<Entity_MantenimientoDetalle_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_Mantenimiento_ListarPorViaje>().HasNoKey();
            modelBuilder.Entity<Entity_Mantenimiento_ObtenerPorId>().HasNoKey();
            modelBuilder.Entity<Entity_Obtener_Cliente_PorId>().HasNoKey();
            modelBuilder.Entity<Entity_Obtienen_Datos_Empresa>().HasNoKey();
            modelBuilder.Entity<Entity_Operador_ObtenerPorId>().HasNoKey();
            modelBuilder.Entity<Entity_Programa_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_Rentabilidad_ListarViajes>().HasNoKey();
            modelBuilder.Entity<Entity_RespuestaGeneral>().HasNoKey();
            modelBuilder.Entity<Entity_RolPrograma_ListarPorRol>().HasNoKey();
            modelBuilder.Entity<Entity_RutaDetalle_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_RutaDetalle_ObtenerPorId>().HasNoKey();
            modelBuilder.Entity<Entity_Ruta_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_Ruta_ObtenerPorId>().HasNoKey();
            modelBuilder.Entity<Entity_Sucursal_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_TipoGasto_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_TipoMantenimiento_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_TipoUnidad_Listar>().HasNoKey();
            modelBuilder.Entity<Entity_Usuarios_Empresa>().HasNoKey();

        }
    }
}
