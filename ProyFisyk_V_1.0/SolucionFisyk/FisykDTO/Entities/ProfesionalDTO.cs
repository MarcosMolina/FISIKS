using System;

namespace FisykDTO
{
    public class ProfesionalDTO :DTOBase
    {
        public int proId { get; set; }
        public int proMatricula { get; set; }
        public string proTelefonoInterno { get; set; }//20
        public int pro_psnId { get; set; }
        
        public ProfesionalDTO()
        {
            proId = Int_NullValue;
            proMatricula = Int_NullValue;
            proTelefonoInterno = String_NullValue;
            pro_psnId = Int_NullValue;
            IsNew = true;
        }
    }
}
