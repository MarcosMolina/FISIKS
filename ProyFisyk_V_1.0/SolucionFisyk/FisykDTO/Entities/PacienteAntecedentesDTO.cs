using System;

namespace FisykDTO
{
    public class PacienteAntecedentesDTO : DTOBase
    {
        public int apaId { get; set; }
        public int apa_paeId { get; set; }
        public int apa_ameId { get; set; }

        public PacienteAntecedentesDTO()
        {
            apaId = Int_NullValue;
            apa_paeId = Int_NullValue;
            apa_ameId = Int_NullValue;
            IsNew = true;
        }
    }
}

