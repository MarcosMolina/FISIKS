using System;

namespace FisykDTO
{
    public class ProvinciaDTO : DTOBase
    {
        public int pvcId { get; set; }
        public string pvcDescripcion { get; set; }
        public int pvc_pasId { get; set; }

        public ProvinciaDTO()
        {
            pvcId = Int_NullValue;
            pvcDescripcion = String_NullValue;
            pvc_pasId = Int_NullValue;
            IsNew = true;
        }
    }
}
