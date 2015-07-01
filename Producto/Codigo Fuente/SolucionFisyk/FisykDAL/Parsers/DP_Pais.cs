using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Pais : DTOParserSQLOracle
    {
        private int Ord_pasId;
        private int Ord_pasDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_pasId = reader.GetOrdinal("pasId");
            Ord_pasDescripcion = reader.GetOrdinal("pasDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            PaisDTO Pais = new PaisDTO();
            // 
            if (!reader.IsDBNull(Ord_pasId)) { Pais.pasId = reader.GetInt32(Ord_pasId); }
            // 
            if (!reader.IsDBNull(Ord_pasDescripcion)) { Pais.pasDescripcion = reader.GetString(Ord_pasDescripcion); }
            // IsNew
            Pais.IsNew = false;

            return Pais;
        }
    }
}