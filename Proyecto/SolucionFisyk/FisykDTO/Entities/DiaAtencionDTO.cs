using System;

namespace FisiksAppWeb
{
    public class DiaAtencionDTO : DTOBase
    {
        public int datId { get; set; }
        public int dat_tdaId { get; set; }

        public DiaAtencionDTO()
        {
            datId = Int_NullValue;
            dat_tdaId = Int_NullValue;
            IsNew = true;
        }
    }
}
