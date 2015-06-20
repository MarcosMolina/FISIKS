using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_DiaTipo : DTOParserSQLOracle
    {
        private int Ord_tdaId;
        private int Ord_tdaDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_tdaId = reader.GetOrdinal("tdaId");
            Ord_tdaDescripcion = reader.GetOrdinal("tdaDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            DiaTipoDTO DiaTipo = new DiaTipoDTO();
            // 
            if (!reader.IsDBNull(Ord_tdaId)) { DiaTipo.tdaId = reader.GetInt32(Ord_tdaId); }
            // 
            if (!reader.IsDBNull(Ord_tdaDescripcion)) { DiaTipo.tdaDescripcion = reader.GetString(Ord_tdaDescripcion); }
            // IsNew
            DiaTipo.IsNew = false;

            return DiaTipo;
        }
    }
}