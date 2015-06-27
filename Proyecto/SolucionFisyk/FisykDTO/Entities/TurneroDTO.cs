using System;

namespace FisiksAppWeb
{
    public class TurneroDTO : DTOBase
    {
        public int turId { get; set; }
        public string turTitulo { get; set; }
        public string turDescripcion { get; set; }
        public DateTime turFechaIni { get; set; }
        public DateTime turFechaFin { get; set; }
        public bool turTodoDia { get; set; }
        public int tur_paeId { get; set; }
        public int tur_proId { get; set; }

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
