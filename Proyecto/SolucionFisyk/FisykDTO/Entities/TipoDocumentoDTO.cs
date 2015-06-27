using System;

namespace FisiksAppWeb
{
    public class TipoDocumentoDTO : DTOBase
    {
        public int tpdId { get; set; }
        public string tpdDescripcion { get; set; }//20
       
        public TipoDocumentoDTO()
        {
            tpdId = Int_NullValue;
            tpdDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}