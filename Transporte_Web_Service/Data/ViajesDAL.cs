using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Transporte_Web_Service.Entity;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Transporte_Web_Service.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Transporte_Web_Service.Data
{
    public class ViajesDAL
    {
        private readonly MiDbContext _context;

        public ViajesDAL(MiDbContext context)
        {
            _context = context;
        }

        public List<RespuestaGeneral> Dal_EstadoViaje_Guardar(int IdEstadoViaje, string Descripcion)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdEstadoViaje = new SqlParameter("@IdEstadoViaje", (object)IdEstadoViaje);
                var _Descripcion = new SqlParameter("@Descripcion", (object)Descripcion);

                object[] parametros = new object[] { _IdEstadoViaje, _Descripcion };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_EstadoViaje_Guardar @IdEstadoViaje, @Descripcion", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_EstadoViaje_Listar> Dal_EstadoViaje_Listar()
        {
            List<Ent_EstadoViaje_Listar> listaDatos = new List<Ent_EstadoViaje_Listar>();
            try
            {
                object[] parametros = new object[] {  };

                listaDatos = _context.Set<Ent_EstadoViaje_Listar>()
                             .FromSqlRaw("EXEC sp_EstadoViaje_Listar ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_EstadoViaje_Listar> Dal_EstadoViaje_ObtenerPorId(int IdEstadoViaje)
        {
            List<Ent_EstadoViaje_Listar> listaDatos = new List<Ent_EstadoViaje_Listar>();
            try
            {
                var _IdEstadoViaje = new SqlParameter("@IdEstadoViaje", (object)IdEstadoViaje);

                object[] parametros = new object[] { _IdEstadoViaje };

                listaDatos = _context.Set<Ent_EstadoViaje_Listar>()
                             .FromSqlRaw("EXEC sp_EstadoViaje_ObtenerPorId @IdEstadoViaje ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
    }
}
