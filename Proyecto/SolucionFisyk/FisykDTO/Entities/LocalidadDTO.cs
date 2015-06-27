using System;

namespace FisiksAppWeb
{
    public class LocalidadDTO : DTOBase
    {
        public int locId { get; set; }
        public string locDescripcion { get; set; }//45
        public int loc_pvcId { get; set; }

        public LocalidadDTO()
        {
            locId = Int_NullValue;
            locDescripcion = String_NullValue;
            loc_pvcId = Int_NullValue;
            IsNew = true;
        }
    }
}
