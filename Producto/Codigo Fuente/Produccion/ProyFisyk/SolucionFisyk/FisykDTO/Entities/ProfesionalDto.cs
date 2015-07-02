using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class ProfesionalDto :DtoBase
    {
        public int ProId { get; set; }
        public int ProMatricula { get; set; }
        public string ProTelefonoInterno { get; set; }//20
        public int ProPsnId { get; set; }
        
        public ProfesionalDto()
        {
            ProId = IntNullValue;
            ProMatricula = IntNullValue;
            ProTelefonoInterno = StringNullValue;
            ProPsnId = IntNullValue;
            IsNew = true;
        }
    }
}
