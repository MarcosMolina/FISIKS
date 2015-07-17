using System;
using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TurneroDto : DtoBase
    {
        public int TurId { set; get; }
        public string TurTitulo { set; get; }
        public string TurDescripcion { set; get; }
        public DateTime TurFechaIni { set; get; }
        public DateTime TurFechaFin { set; get; }
        public bool TurTodoDia { set; get; }
        public int TurPaeId { set; get; }
        public int TurProId { set; get; }

        public TurneroDto(int turId, string turDescripcion, string turTitulo, bool turTodoDia, DateTime turFechaFin, 
            DateTime turFechaIni, int turPaeId, int turProId)
        {
            TurId = turId;
            TurDescripcion = turDescripcion;
            TurTitulo = turTitulo;
            TurTodoDia = turTodoDia;
            TurFechaFin = turFechaFin;
            TurFechaIni = turFechaIni;
            TurPaeId = turPaeId;
            TurProId = turProId;
        }



        public TurneroDto ()
        {
        }

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
