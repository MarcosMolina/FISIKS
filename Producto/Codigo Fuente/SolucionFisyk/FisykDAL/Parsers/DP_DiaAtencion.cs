using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_DiaAtencion : DTOParserSQLOracle
    {
        private int Ord_datId;
        private int Ord_dat_tdaId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_datId = reader.GetOrdinal("datId");
            Ord_dat_tdaId = reader.GetOrdinal("dat_tdaId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            DiaAtencionDTO DiaAtencion = new DiaAtencionDTO();
            // 
            if (!reader.IsDBNull(Ord_datId)) { DiaAtencion.datId = reader.GetInt32(Ord_datId); }
            // 
            if (!reader.IsDBNull(Ord_dat_tdaId)) { DiaAtencion.dat_tdaId = reader.GetInt32(Ord_dat_tdaId); }
            // IsNew
            DiaAtencion.IsNew = false;

            return DiaAtencion;
        }
    }
}
