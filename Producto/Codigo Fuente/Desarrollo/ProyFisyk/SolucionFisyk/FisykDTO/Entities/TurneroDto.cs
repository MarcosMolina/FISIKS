using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TurneroDto : DtoBase
    {
        public int TurId;
        public string TurTitulo;
        public string TurDescripcion;
        public DateTime TurFechaIni;
        public DateTime TurFechaFin;
        public bool TurTodoDia ;
        public int TurPaeId;
        public int TurProId;

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
