using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_TestDetalle : DTOParserSQLOracle
    {
        private int Ord_detId;
        private int Ord_det_tstId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_detId = reader.GetOrdinal("detId");
            Ord_det_tstId = reader.GetOrdinal("det_tstId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            TestDetalleDTO TestDetalle = new TestDetalleDTO();
            // 
            if (!reader.IsDBNull(Ord_detId)) { TestDetalle.detId = reader.GetInt32(Ord_detId); }
            // 
            if (!reader.IsDBNull(Ord_det_tstId)) { TestDetalle.det_tstId = reader.GetInt32(Ord_det_tstId); }
            // IsNew
            TestDetalle.IsNew = false;

            return TestDetalle;
        }
    }
}

