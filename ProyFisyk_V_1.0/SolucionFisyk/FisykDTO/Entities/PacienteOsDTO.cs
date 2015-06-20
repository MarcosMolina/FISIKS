using System;

namespace FisykDTO
{
    public class PacienteOsDTO : DTOBase
    {
        public int ospId { get; set; }
        public int osp_paeId { get; set; }
        public int osp_osoId { get; set; }

        public PacienteOsDTO()
        {
            ospId = Int_NullValue;
            osp_paeId = Int_NullValue;
            osp_osoId = Int_NullValue;
            IsNew = true;
        }
    }
}

