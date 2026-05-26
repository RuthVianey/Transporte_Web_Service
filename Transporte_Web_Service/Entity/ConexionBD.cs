using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Entity
{
    public class ConexionBD
    {
        ////private readonly IConfiguration _config;

        ////public ConexionBD(IConfiguration config)
        ////{
        ////    _config = config;
        ////}

        ////public string ObtenerConexion(string nombre)
        ////{
        ////    return _config.GetConnectionString(nombre);
        ////}

        //private readonly IConfiguration _config;

        //public ConexionBD(IConfiguration config)
        //{
        //    _config = config;
        //}

        //public string ObtenerConexion(string nombre)
        //{
        //    return _config.GetConnectionString(nombre);
        //}

        protected string CONEXION;

        public ConexionBD(string bd)
        {
            this.CONEXION = "ConexionEntity_" + bd;
        }

        protected string ConectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[CONEXION].ConnectionString;
            }
        }
    }

}

