using System;

namespace FisiksAppWeb
{
    public abstract class PersonaDTO : DTOBase
    {

        public int psnId { get; set; }
        public int psn_tpdId { get; set; }
        public string psnNroDcto { get; set; }//10
        public string psnNombre { get; set; }//45
        public string psnApellido { get; set; }//45
        public string psnFechaNac { get; set; }//12
        public string psnTelefono { get; set; }//20
        public string psnSexo { get; set; }//1
        public int psn_domId { get; set; }

        public PersonaDTO()
        {
            IsNew = true;
        }
    }
}
