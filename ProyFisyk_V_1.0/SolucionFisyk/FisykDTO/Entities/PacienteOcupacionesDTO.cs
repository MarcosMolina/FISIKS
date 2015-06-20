using System;

namespace FisykDTO
{
    public class PacienteOcupacionesDTO : DTOBase
    {
        public int opaId { get; set; }
        public int opa_paeId { get; set; }
        public int opa_ocuId { get; set; }

        public PacienteOcupacionesDTO()
        {
            opaId = Int_NullValue;
            opa_paeId = Int_NullValue;
            opa_ocuId = Int_NullValue;
            IsNew = true;
        }
    }
}
