using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_PacienteOs : DTOParserSQLOracle
    {
        private int Ord_ospId;
        private int Ord_osp_paeId;
        private int Ord_osp_osoId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_ospId = reader.GetOrdinal("ospId");
            Ord_osp_paeId = reader.GetOrdinal("osp_paeId");
            Ord_osp_osoId = reader.GetOrdinal("osp_osoId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            PacienteOsDTO PacienteOs = new PacienteOsDTO();
            // 
            if (!reader.IsDBNull(Ord_ospId)) { PacienteOs.ospId = reader.GetInt32(Ord_ospId); }
            // 
            if (!reader.IsDBNull(Ord_osp_paeId)) { PacienteOs.osp_paeId = reader.GetInt32(Ord_osp_paeId); }
            // 
            if (!reader.IsDBNull(Ord_osp_osoId)) { PacienteOs.osp_osoId = reader.GetInt32(Ord_osp_osoId); }
            // IsNew
            PacienteOs.IsNew = false;

            return PacienteOs;
        }
    }
}
