using System;

namespace FisykDTO
{
    public class EstadoDTO : DTOBase
    {
        public int estId { get; set; }
        public string estDescripcion { get; set; }//45

        public EstadoDTO()
        {
            estId = Int_NullValue;
            estDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}
