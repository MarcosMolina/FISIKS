using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TurneroDto : DtoBase
    {
        public int TurId { get; set; }
        public string TurTitulo { get; set; }
        public string TurDescripcion { get; set; }
        public DateTime TurFechaIni { get; set; }
        public DateTime TurFechaFin { get; set; }
        public bool TurTodoDia { get; set; }
        public int TurPaeId { get; set; }
        public int TurProId { get; set; }

        //public TurneroDTO()
        //{
        //    turId = Int_NullValue;
        //    turTitulo = String_NullValue;
        //    turDescripcion = String_NullValue;
        //    turFechaIni = DateTime_NullValue;
        //    turFechaFin = DateTime_NullValue;
        //    turTodoDia = Bool_NullValue;
        //    tur_paeId = Int_NullValue;
        //    tur_proId = Int_NullValue;

        //    IsNew = true;
        //}
    }
}
