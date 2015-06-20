using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_AfeccionesTipos : DTOParserSQLOracle
    {
        private int Ord_tafId;
        private int Ord_tafDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_tafId = reader.GetOrdinal("tafId");
            Ord_tafDescripcion = reader.GetOrdinal("tafDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            AfeccionesTiposDTO AfeccionesTipos = new AfeccionesTiposDTO();
            // 
            if (!reader.IsDBNull(Ord_tafId)) { AfeccionesTipos.tafId = reader.GetInt32(Ord_tafId); }
            // 
            if (!reader.IsDBNull(Ord_tafDescripcion)) { AfeccionesTipos.tafDescripcion = reader.GetString(Ord_tafDescripcion); }
            // IsNew
            AfeccionesTipos.IsNew = false;

            return AfeccionesTipos;
        }
    }
}
