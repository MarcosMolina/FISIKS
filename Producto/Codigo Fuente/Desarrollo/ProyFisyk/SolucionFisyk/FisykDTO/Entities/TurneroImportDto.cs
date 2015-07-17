namespace FisiksAppWeb.Entities
{
    
    public class TurneroImportDto
    {
        public int TurImpId { get; set; }
        public string TurImpTitulo { get; set; }
        public string TurImpDescripcion { get; set; }
        public string TurImpFechaIni { get; set; }
        public string TurImpFechaFin { get; set; }
        public bool TurImpTodoDia { get; set; }
        public int TurImpPaeId { get; set; }
        public int TurImpProId { get; set; }

        public TurneroImportDto(int turImpId, string turImpTitulo, string turImpDescripcion, string turImpFechaIni, string turImpFechaFin, bool turImpTodoDia, int turImpProId, int turImpPaeId)
        {
            TurImpId = turImpId;
            TurImpTitulo = turImpTitulo;
            TurImpDescripcion = turImpDescripcion;
            TurImpFechaIni = turImpFechaIni;
            TurImpFechaFin = turImpFechaFin;
            TurImpTodoDia = turImpTodoDia;
            TurImpProId = turImpProId;
            TurImpPaeId = turImpPaeId;
        }

        public TurneroImportDto()
        {
        }

    }
}
