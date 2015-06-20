using System;

namespace FisykDTO
{
    public class ObraSocialDTO : DTOBase
    {
        public int osoId { get; set; }
        public string osoDescripcion { get; set; }//45
        public int osoCoseguro { get; set; }
        public string osoContacto { get; set; }//20

        public ObraSocialDTO()
        {
            osoId = Int_NullValue;
            osoDescripcion = String_NullValue;
            osoCoseguro = Int_NullValue;
            osoContacto = String_NullValue;
            IsNew = true;
        }
    }
}
