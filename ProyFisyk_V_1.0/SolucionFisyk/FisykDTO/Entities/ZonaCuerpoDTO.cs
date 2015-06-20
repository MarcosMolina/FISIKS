using System;

namespace FisykDTO
{
    public class ZonaCuerpoDTO : DTOBase
    {
        public int zcuId { get; set; }
        public string zcuDescripcion { get; set; }//45
        public int zcuNivel { get; set; }
        public int zcuIdPadre { get; set; }

        public ZonaCuerpoDTO()
        {
            zcuId = Int_NullValue;
            zcuDescripcion = String_NullValue;
            zcuNivel = Int_NullValue;
            zcuIdPadre = Int_NullValue;
            IsNew = true;
        }
    }
}
