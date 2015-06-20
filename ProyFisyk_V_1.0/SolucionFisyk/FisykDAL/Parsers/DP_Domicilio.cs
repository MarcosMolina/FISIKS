using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Domicilio : DTOParserSQLOracle
    {
        private int Ord_domId;
        private int Ord_domCalle;
        private int Ord_domNumero;
        private int Ord_domPiso;
        private int Ord_domDpto;
        private int Ord_dom_locId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_domId = reader.GetOrdinal("domId");
            Ord_domCalle = reader.GetOrdinal("domCalle");
            Ord_domNumero = reader.GetOrdinal("domNumero");
            Ord_domPiso = reader.GetOrdinal("domPiso");
            Ord_domDpto = reader.GetOrdinal("domDpto");
            Ord_dom_locId = reader.GetOrdinal("dom_locId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            DomicilioDTO Domicilio = new DomicilioDTO();
            // 
            if (!reader.IsDBNull(Ord_domId)) { Domicilio.domId = reader.GetInt32(Ord_domId); }
            // 
            if (!reader.IsDBNull(Ord_domCalle)) { Domicilio.domCalle = reader.GetString(Ord_domCalle); }
            // 
            if (!reader.IsDBNull(Ord_domNumero)) { Domicilio.domNumero = reader.GetInt32(Ord_domNumero); }
            // 
            if (!reader.IsDBNull(Ord_domPiso)) { Domicilio.domPiso = reader.GetString(Ord_domPiso); }
            // 
            if (!reader.IsDBNull(Ord_domDpto)) { Domicilio.domDpto = reader.GetString(Ord_domDpto); }
            // 
            if (!reader.IsDBNull(Ord_dom_locId)) { Domicilio.dom_locId = reader.GetInt32(Ord_dom_locId); }
            // IsNew
            Domicilio.IsNew = false;

            return Domicilio;
        }
    }
}
