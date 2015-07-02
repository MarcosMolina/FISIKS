using System.Collections.Generic;

namespace FisiksAppWeb.Entities
{
    public class PacienteDto : PersonaDto
    {
        public int PaeId { get; set; }
        public decimal PaePeso { get; set; }
        public int PaeAltura { get; set; }
        public string PaeActFisica { get; set; }//1
        public int PaePeriodicidad { get; set; }
        public int PaePsnId { get; set; }

        public List<PacienteOsDto> PaeListObraSocial { get; set; }
        public List<PacienteOcupacionesDto> PaeListOcupaciones { get; set; }

        public PacienteDto()
        {

        }

        public PacienteDto(int paeId, decimal paePeso, int paeAltura, string paeActFisica, int paePeriodicidad,
                            int paePsnId, List<PacienteOsDto> paeListObraSocial, List<PacienteOcupacionesDto> paeListOcupaciones)
        {
            PaeId = paeId;
            PaePeso = paePeso;
            PaeAltura = paeAltura;
            PaeActFisica = paeActFisica;
            PaePeriodicidad = paePeriodicidad;
            PaePsnId = paePsnId;
            PaeListObraSocial = paeListObraSocial;
            PaeListOcupaciones = paeListOcupaciones;
        }
    }
}
