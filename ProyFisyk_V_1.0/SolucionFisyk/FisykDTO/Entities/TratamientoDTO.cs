using System;

namespace FisykDTO
{
    public class TratamientoDTO :DTOBase
    {
        public int traId { get; set; }
        public string traDescripcion { get; set; }//45

        public TratamientoDTO()
        {
            traId = Int_NullValue;
            traDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}
