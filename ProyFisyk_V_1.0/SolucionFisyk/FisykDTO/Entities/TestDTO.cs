using System;

namespace FisykDTO
{
    public class TestDTO : DTOBase
    {
        public int tstId { get; set; }
        public string tstObservacion { get; set; }//45
        public int tst_zcuId { get; set; }
        public int tst_tptId { get; set; }

        public TestDTO()
        {
            tstId = Int_NullValue;
            tstObservacion = String_NullValue;
            tst_zcuId = Int_NullValue;
            tst_tptId = Int_NullValue;
            IsNew = true;
        }
    }
}

