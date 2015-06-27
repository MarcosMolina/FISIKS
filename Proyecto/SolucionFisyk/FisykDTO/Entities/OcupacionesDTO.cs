using System;

namespace FisiksAppWeb
{
    public class OcupacionesDTO : DTOBase
    {
        public int ocuId { get; set; }
        public string ocuDescripcion { get; set; }//45
        public string ocuSedentaria { get; set; }//1

        public OcupacionesDTO()
        {
            ocuId = Int_NullValue;
            ocuDescripcion = String_NullValue;
            ocuSedentaria = String_NullValue;
            IsNew = true;
        }
    }
}
