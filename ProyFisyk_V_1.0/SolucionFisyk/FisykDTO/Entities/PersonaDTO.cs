using System;

namespace FisykDTO
{
    public class PersonaDTO : DTOBase
    {
        public int psnId { get; set; }
        public int psn_tpdId { get; set; }
        public int psnNroDcto { get; set; }//38
        public string psnNombre { get; set; }//45
        public string psnApellido { get; set; }//45
        public string psnFechaNac { get; set; }//12
        public string psnTelefono { get; set; }//20
        public string psnSexo { get; set; }//1
        public int psn_domId { get; set; }
        
        public PersonaDTO()
        {
            psnId = Int_NullValue;
            psnNroDcto = Int_NullValue;
            psnNombre = String_NullValue;
            psnApellido = String_NullValue;
            psnFechaNac = String_NullValue;
            psnTelefono = String_NullValue;
            psnSexo = String_NullValue;
            psn_domId = Int_NullValue;
            psn_tpdId = Int_NullValue;
            IsNew = true;
        }
    }
}
