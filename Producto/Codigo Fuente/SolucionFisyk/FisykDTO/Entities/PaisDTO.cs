using System;

namespace FisiksAppWeb
{
    public class PaisDTO : DTOBase
    {
        public int pasId { get; set; }
        public string pasDescripcion { get; set; }//45

        public PaisDTO()
        {
            pasId = Int_NullValue;
            pasDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}
