using System;

namespace FisykDTO
{
    public class TurnoDTO : DTOBase
    {
        public int trnId { get; set; }
        public string trnFecha { get; set; }//12
        public string trnHora { get; set; }//5
        public float trnMontoCobrado { get; set; }//6,2
        public int trn_estId { get; set; }
        public int trn_proId { get; set; }
        public int trn_sesId { get; set; }
        public int trn_paeId { get; set; }
        public int trn_datId { get; set; }
        public int trn_ospId { get; set; }

        public TurnoDTO()
        {
            trnId = Int_NullValue;
            trnFecha = String_NullValue;
            trnHora = String_NullValue;
            trnMontoCobrado = Float_NullValue;
            trn_estId = Int_NullValue;
            trn_proId = Int_NullValue;
            trn_sesId = Int_NullValue;
            trn_paeId = Int_NullValue;
            trn_datId = Int_NullValue;
            trn_ospId = Int_NullValue;
            IsNew = true;
        }
    }
}