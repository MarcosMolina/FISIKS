using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class AgendaDto : DtoBase
    {
        public int AgeId { get; set; }
        public DateTime AgeHoraDesde { get; set; }
        public DateTime AgeHoraHasta { get; set; }
        public int AgeProId { get; set; }
        public int AgeDiaId { get; set; }

        public AgendaDto()
        {
            AgeId = IntNullValue;
            AgeHoraDesde = DateTimeNullValue;
            AgeHoraHasta = DateTimeNullValue;
            AgeProId = IntNullValue;
            AgeDiaId = IntNullValue;
            IsNew = true;
        }
    }
}

