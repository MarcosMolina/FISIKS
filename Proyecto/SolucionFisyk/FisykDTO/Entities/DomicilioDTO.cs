using System;

namespace FisiksAppWeb
{
    public class DomicilioDTO : DTOBase
    {
        public int domId { get; set; }
        public string domCalle { get; set; }//45
        public int domNumero { get; set; }
        public string domPiso { get; set; }//5
        public string domDpto { get; set; }//5
        public int dom_locId { get; set; }

        public DomicilioDTO()
        {
            domId = Int_NullValue;
            domCalle = String_NullValue;
            domNumero = Int_NullValue;
            domPiso = String_NullValue;
            domDpto = String_NullValue;
            dom_locId = Int_NullValue;
            IsNew = true;
        }
    }
}
