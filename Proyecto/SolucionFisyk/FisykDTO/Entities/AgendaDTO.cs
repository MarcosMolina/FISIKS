using System;

namespace FisiksAppWeb
{
    public class AgendaDTO : DTOBase
    {
        public int ageId { get; set; }
        public DateTime ageHoraDesde { get; set; }
        public DateTime ageHoraHasta { get; set; }
        public int age_proId { get; set; }
        public int age_diaId { get; set; }

        public AgendaDTO()
        {
            ageId = Int_NullValue;
            ageHoraDesde = DateTime_NullValue;
            ageHoraHasta = DateTime_NullValue;
            age_proId = Int_NullValue;
            age_diaId = Int_NullValue;
            IsNew = true;
        }
    }
}

