using System;

namespace FisykDTO
{
    public class SexoDTO : DTOBase
    {
        //sexId INT NOT NULL,
        //sexDescripcion VARCHAR(45) NULL,
        public int sexId { get; set; }
        public string sexDescripcion { get; set; }

        public SexoDTO()
        {
            sexId = Int_NullValue;
            sexDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}
