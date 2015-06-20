using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_TestTipo : DTOParserSQLOracle
    {
        private int Ord_tptId;
        private int Ord_tptDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_tptId = reader.GetOrdinal("tptId");
            Ord_tptDescripcion = reader.GetOrdinal("tptDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            TestTipoDTO TestTipo = new TestTipoDTO();
            // 
            if (!reader.IsDBNull(Ord_tptId)) { TestTipo.tptId = reader.GetInt32(Ord_tptId); }
            // 
            if (!reader.IsDBNull(Ord_tptDescripcion)) { TestTipo.tptDescripcion = reader.GetString(Ord_tptDescripcion); }
            // IsNew
            TestTipo.IsNew = false;

            return TestTipo;
        }
    }
}