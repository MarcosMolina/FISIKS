using System;

namespace FisiksAppWeb
{
    public class DiaTipoDTO : DTOBase
    {
        public int tdaId { get; set; }
        public string tdaDescripcion { get; set; }//45

        public DiaTipoDTO()
        {
            tdaId = Int_NullValue;
            tdaDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}

