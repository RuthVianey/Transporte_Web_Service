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
            modelBuilder.Entity<ResultadoSP>().HasNoKey();
            modelBuilder.Entity<Obtienen_Datos_Empresa>().HasNoKey();
            modelBuilder.Entity<Usuarios_Empresa>().HasNoKey();
            modelBuilder.Entity<Lista_Roles>().HasNoKey();
            modelBuilder.Entity<Lista_Usuario>().HasNoKey();
            modelBuilder.Entity<Lista_Programa>().HasNoKey();
        }





        //Lista de lo que regresara las base
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ResultadoSP> ResultadoSP { get; set; }
        public DbSet<Obtienen_Datos_Empresa> Obtienen_Datos_Empresa { get; set; }
        public DbSet<Usuarios_Empresa> Usuarios_Empresa { get; set; }
        public DbSet<Lista_Roles> Lista_Roles { get; set; }
        public DbSet<Lista_Usuario> Lista_Usuario { get; set; }
        public DbSet<Lista_Programa> Lista_Programa { get; set; }
    }
    
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }


}
