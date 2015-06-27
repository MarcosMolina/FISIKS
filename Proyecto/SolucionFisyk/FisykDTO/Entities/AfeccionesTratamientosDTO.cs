using System;

namespace FisiksAppWeb
{
    public class AfeccionesTratamientosDTO : DTOBase
    {
        public int atsId { get; set; }
        public int ats_traId { get; set; }
        public int ats_afnId { get; set; }

        public AfeccionesTratamientosDTO()
        {
            atsId = Int_NullValue;
            ats_traId = Int_NullValue;
            ats_afnId = Int_NullValue;

            IsNew = true;
        }
    }
}
