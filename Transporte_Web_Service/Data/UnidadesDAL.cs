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
    public class UnidadesDAL
    {
        private readonly MiDbContext _context;

        public UnidadesDAL(MiDbContext context)
        {
            _context = context;
        }
    }
}
