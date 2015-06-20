using System;

namespace FisykDTO
{
    public class AntecedenteMedicoDTO : DTOBase
    {
        public int ameId { get; set; }
        public string ameDescripcion { get; set; }//45

        public AntecedenteMedicoDTO()
        {
            ameId = Int_NullValue;
            ameDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}
