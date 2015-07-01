using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Test : DTOParserSQLOracle
    {
        private int Ord_tstId;
        private int Ord_tstObservacion;
        private int Ord_tst_zcuId;
        private int Ord_tst_tptId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_tstId = reader.GetOrdinal("tstId");
            Ord_tstObservacion = reader.GetOrdinal("tstObservacion");
            Ord_tst_zcuId = reader.GetOrdinal("tst_zcuId");
            Ord_tst_tptId = reader.GetOrdinal("tst_tptId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            TestDTO Test = new TestDTO();
            // 
            if (!reader.IsDBNull(Ord_tstId)) { Test.tstId = reader.GetInt32(Ord_tstId); }
            // 
            if (!reader.IsDBNull(Ord_tstObservacion)) { Test.tstObservacion = reader.GetString(Ord_tstObservacion); }
            // 
            if (!reader.IsDBNull(Ord_tst_zcuId)) { Test.tst_zcuId = reader.GetInt32(Ord_tst_zcuId); }
            // 
            if (!reader.IsDBNull(Ord_tst_tptId)) { Test.tst_tptId = reader.GetInt32(Ord_tst_tptId); }
            // IsNew
            Test.IsNew = false;

            return Test;
        }
    }
}