using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class CombustibleBussines
    {
        private string sBaseDatos;
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Sistema_Gestion_Transporte";


        private readonly CombustibleDAL _dal;

        public CombustibleBussines(CombustibleDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Dal_CargaCombustible(int IdCarga, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_CargaCombustible(IdCarga, IdEmpresa);
                
                if (listaDatos != null && listaDatos.Count > 0)
                {
                    // Pasamos el objeto anónimo directamente, sin serializar a texto todavía
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se encontraron datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }

            return resp; // Regresamos el objeto C# limpio
        }
    }
}
