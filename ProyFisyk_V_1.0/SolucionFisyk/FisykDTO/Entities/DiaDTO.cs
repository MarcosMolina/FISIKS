using System;

namespace FisykDTO
{
    public class DiaDTO : DTOBase
    {
        public int diaId { get; set; }
        public string diaDescripcion { get; set; }//45

        public DiaDTO()
        {
            diaId = Int_NullValue;
            diaDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}
