using System;

namespace FisykDTO
{
    public class PacienteDTO : DTOBase
    {
        public int paeId { get; set; }
        public float paePeso { get; set; }
        public int paeAltura { get; set; }
        public string paeActFisica { get; set; }//1
        public int paePeriodicidad { get; set; }
        public int pae_psnId { get; set; }

        public PacienteDTO()
        {
            paeId = Int_NullValue;
            paePeso = Float_NullValue;
            paeAltura = Int_NullValue;
            paeActFisica = String_NullValue;
            paePeriodicidad = Int_NullValue;
            pae_psnId = Int_NullValue;
            IsNew = true;
        }
    }
}
