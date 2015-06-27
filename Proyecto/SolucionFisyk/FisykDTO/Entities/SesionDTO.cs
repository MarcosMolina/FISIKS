using System;

namespace FisiksAppWeb
{
    public class SesionDTO : DTOBase
    {
        public int sesId { get; set; }
        public int sesNumero { get; set; }
        public string sesObservacion { get; set; }//500
        public string sesFecha { get; set; }//12
        public string sesHoraInicio { get; set; }//5
        public string sesHoraFin { get; set; }//5
        public string sesUltima { get; set; }//1
        public int ses_hcaId { get; set; }

        public SesionDTO()
        {
            sesId = Int_NullValue;
            sesNumero = Int_NullValue;
            sesObservacion = String_NullValue;
            sesFecha = String_NullValue;
            sesHoraInicio = String_NullValue;
            sesHoraFin = String_NullValue;
            sesUltima = String_NullValue;
            ses_hcaId = Int_NullValue;
            IsNew = true;
        }
    }
}
