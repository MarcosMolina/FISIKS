using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_AntecedenteMedico : DTOParserSQLOracle
    {
        private int Ord_ameId;
        private int Ord_ameDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_ameId = reader.GetOrdinal("ameId");
            Ord_ameDescripcion = reader.GetOrdinal("ameDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            AntecedenteMedicoDTO AntecedenteMedico = new AntecedenteMedicoDTO();
            // 
            if (!reader.IsDBNull(Ord_ameId)) { AntecedenteMedico.ameId = reader.GetInt32(Ord_ameId); }
            // 
            if (!reader.IsDBNull(Ord_ameDescripcion)) { AntecedenteMedico.ameDescripcion = reader.GetString(Ord_ameDescripcion); }
            // IsNew
            AntecedenteMedico.IsNew = false;

            return AntecedenteMedico;
        }
    }
}
