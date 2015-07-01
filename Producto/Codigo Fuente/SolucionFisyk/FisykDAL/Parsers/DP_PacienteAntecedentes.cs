using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_PacienteAntecedentes : DTOParserSQLOracle
    {
        private int Ord_apaId;
        private int Ord_apa_paeId;
        private int Ord_apa_ameId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_apaId = reader.GetOrdinal("apaId");
            Ord_apa_paeId = reader.GetOrdinal("apa_paeId");
            Ord_apa_ameId = reader.GetOrdinal("apa_ameId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            PacienteAntecedentesDTO PacienteAntecedentes = new PacienteAntecedentesDTO();
            // 
            if (!reader.IsDBNull(Ord_apaId)) { PacienteAntecedentes.apaId = reader.GetInt32(Ord_apaId); }
            // 
            if (!reader.IsDBNull(Ord_apa_paeId)) { PacienteAntecedentes.apa_paeId = reader.GetInt32(Ord_apa_paeId); }
            // 
            if (!reader.IsDBNull(Ord_apa_ameId)) { PacienteAntecedentes.apa_ameId = reader.GetInt32(Ord_apa_ameId); }
            // IsNew
            PacienteAntecedentes.IsNew = false;

            return PacienteAntecedentes;
        }
    }
}