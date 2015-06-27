using System;

namespace FisiksAppWeb
{
    public class SesionDetalleDTO : DTOBase
    {
        public int desId { get; set; }
        public string desObservacion { get; set; }//200
        public int des_traId { get; set; }
        public int des_sesId { get; set; }
        public int dse_traId { get; set; }
        public int dse_afnId { get; set; }

        public SesionDetalleDTO()
        {
            desId = Int_NullValue;
            desObservacion = String_NullValue;
            des_traId = Int_NullValue;
            des_sesId = Int_NullValue;
            dse_traId = Int_NullValue;
            dse_afnId = Int_NullValue;
            IsNew = true;
        }
    }
}