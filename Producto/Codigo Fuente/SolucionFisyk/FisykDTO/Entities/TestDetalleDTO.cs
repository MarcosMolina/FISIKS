using System;

namespace FisiksAppWeb
{
    public class TestDetalleDTO : DTOBase
    {
        public int detId { get; set; }
        public int det_tstId { get; set; }

        public TestDetalleDTO()
        {
            detId = Int_NullValue;
            det_tstId = Int_NullValue;
            IsNew = true;
        }
    }
}
