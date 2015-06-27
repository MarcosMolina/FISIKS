using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_AfeccionesTratamientos : DTOParserSQLOracle
    {
        private int Ord_atsId;
        private int Ord_ats_traId;
        private int Ord_ats_afnId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_atsId = reader.GetOrdinal("atsId");
            Ord_ats_traId = reader.GetOrdinal("ats_traId");
            Ord_ats_afnId = reader.GetOrdinal("ats_afnId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            AfeccionesTratamientosDTO AfeccionesTratamientos = new AfeccionesTratamientosDTO();
            // 
            if (!reader.IsDBNull(Ord_atsId)) { AfeccionesTratamientos.atsId = reader.GetInt32(Ord_atsId); }
            // 
            if (!reader.IsDBNull(Ord_ats_traId)) { AfeccionesTratamientos.ats_traId = reader.GetInt32(Ord_ats_traId); }
            // 
            if (!reader.IsDBNull(Ord_ats_afnId)) { AfeccionesTratamientos.ats_afnId = reader.GetInt32(Ord_ats_afnId); }
            // IsNew
            AfeccionesTratamientos.IsNew = false;

            return AfeccionesTratamientos;
        }
    }
}
