namespace Transporte_Web_Service.Entity
{
    public class Entity_SatCatalogoProdServ
    {
        public int IdCatalogo { get; set; }
        public string ClaveProdServ { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? IncluirIvaTraslado { get; set; }
        public bool? IncluirIepsTraslado { get; set; }
    }

    public class Entity_SatCatalogoRegimenFiscal
    {
        public int IdRegimenFiscal { get; set; }
        public string ClaveRegimenFis { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public byte? TipoPersona { get; set; }
    }

    public class Entity_SatCatalogoUM
    {
        public int IdUnidadMedida { get; set; }
        public string ClaveUnidad { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
