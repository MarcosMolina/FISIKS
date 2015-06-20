using System;

namespace FisykDTO
{
    public class HistoriaClinicaDTO : DTOBase
    {
        public int hcaId { get; set; }
        public int hcaNroSesiones { get; set; }
        public DateTime hcaFecha { get; set; }
        public int hca_afnId { get; set; }
        public int hca_paeId { get; set; }
        public int hcaCantEvaluaciones { get; set; }

        public HistoriaClinicaDTO()
        {
            hcaId = Int_NullValue;
            hcaNroSesiones = Int_NullValue;
            hcaFecha = DateTime_NullValue;
            hca_afnId = Int_NullValue;
            hca_paeId = Int_NullValue;
            hcaCantEvaluaciones = Int_NullValue;
            IsNew = true;
        }
    }
}
