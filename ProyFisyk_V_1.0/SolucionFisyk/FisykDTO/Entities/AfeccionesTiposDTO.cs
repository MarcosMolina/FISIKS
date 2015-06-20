using System;

namespace FisykDTO
{
    public class AfeccionesTiposDTO : DTOBase
    {
        public int tafId { get; set; }
        public string tafDescripcion { get; set; }//45

        public AfeccionesTiposDTO()
        {
            tafId = Int_NullValue;
            tafDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}
