using System;

namespace FisiksAppWeb
{
    
    public class TurneroImportDTO
    {
        public int turImpId { get; set; }
        public string turImpTitulo { get; set; }
        public string turImpDescripcion { get; set; }
        public string turImpFechaIni { get; set; }
        public string turImpFechaFin { get; set; }
        public bool turImpTodoDia { get; set; }
        public int turImp_paeId { get; set; }
        public int turImp_proId { get; set; }
    }
}
