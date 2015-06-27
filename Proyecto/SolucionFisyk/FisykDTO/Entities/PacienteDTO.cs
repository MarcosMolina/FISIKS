using System;

namespace FisiksAppWeb
{
    public class PacienteDTO : PersonaDTO
    {
        public int paeId { get; set; }
        public decimal paePeso { get; set; }
        public int paeAltura { get; set; }
        public string paeActFisica { get; set; }//1
        public int paePeriodicidad { get; set; }
        public int pae_psnId { get; set; }


        public PacienteDTO() : base()
        {

        }
    }
}
