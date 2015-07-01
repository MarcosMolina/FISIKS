using System; 

namespace FisiksAppWeb
{
    public class TestTipoDTO : DTOBase
    {
        public int tptId { get; set; }
        public string tptDescripcion { get; set; }//45
       
        public TestTipoDTO()
        {
            tptId = Int_NullValue;
            tptDescripcion = String_NullValue;
            IsNew = true;
        }
    }
}
