using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_PacienteOcupaciones : DTOParserSQLOracle
    {
        private int Ord_opaId;
        private int Ord_opa_paeId;
        private int Ord_opa_ocuId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_opaId = reader.GetOrdinal("opaId");
            Ord_opa_paeId = reader.GetOrdinal("opa_paeId");
            Ord_opa_ocuId = reader.GetOrdinal("opa_ocuId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            PacienteOcupacionesDTO PacienteOcupaciones = new PacienteOcupacionesDTO();
            // 
            if (!reader.IsDBNull(Ord_opaId)) { PacienteOcupaciones.opaId = reader.GetInt32(Ord_opaId); }
            // 
            if (!reader.IsDBNull(Ord_opa_paeId)) { PacienteOcupaciones.opa_paeId = reader.GetInt32(Ord_opa_paeId); }
            // 
            if (!reader.IsDBNull(Ord_opa_ocuId)) { PacienteOcupaciones.opa_ocuId = reader.GetInt32(Ord_opa_ocuId); }
            // IsNew
            PacienteOcupaciones.IsNew = false;

            return PacienteOcupaciones;
        }
    }
}