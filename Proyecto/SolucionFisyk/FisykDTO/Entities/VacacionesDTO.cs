using System;

namespace FisiksAppWeb
{
    public class VacacionesDTO : DTOBase
    {
        public int vacId { get; set; }
        public string vacFechaDesde { get; set; }//12
        public string vacFechaHasta { get; set; }//12
        public int vac_proId { get; set; }

        public VacacionesDTO()
        {
            vacId = Int_NullValue;
            vacFechaDesde = String_NullValue;
            vacFechaHasta = String_NullValue;
            vac_proId = Int_NullValue;
            IsNew = true;
        }
    }
}