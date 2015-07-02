using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class PacienteOcupacionesDto : DtoBase
    {
        public int OpaId { get; set; }
        public int OpaPaeId { get; set; }
        public int OpaOcuId { get; set; }

        public PacienteOcupacionesDto(int opaOcuId)
        {
            OpaOcuId = opaOcuId;
        }

        public PacienteOcupacionesDto()
        {
            OpaId = IntNullValue;
            OpaPaeId = IntNullValue;
            OpaOcuId = IntNullValue;
            IsNew = true;
        }
    }
}
