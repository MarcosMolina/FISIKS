using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_ZonaCuerpo : DTOParserSQLOracle
    {
        private int Ord_zcuId;
        private int Ord_zcuDescripcion;
        private int Ord_zcuNivel;
        private int Ord_zcuIdPadre;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_zcuId = reader.GetOrdinal("zcuId");
            Ord_zcuDescripcion = reader.GetOrdinal("zcuDescripcion");
            Ord_zcuNivel = reader.GetOrdinal("zcuNivel");
            Ord_zcuIdPadre = reader.GetOrdinal("zcuIdPadre");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            ZonaCuerpoDTO ZonaCuerpo = new ZonaCuerpoDTO();
            // 
            if (!reader.IsDBNull(Ord_zcuId)) { ZonaCuerpo.zcuId = reader.GetInt32(Ord_zcuId); }
            // 
            if (!reader.IsDBNull(Ord_zcuDescripcion)) { ZonaCuerpo.zcuDescripcion = reader.GetString(Ord_zcuDescripcion); }
            // 
            if (!reader.IsDBNull(Ord_zcuNivel)) { ZonaCuerpo.zcuNivel = reader.GetInt32(Ord_zcuNivel); }
            // 
            if (!reader.IsDBNull(Ord_zcuIdPadre)) { ZonaCuerpo.zcuIdPadre = reader.GetInt32(Ord_zcuIdPadre); }
            // IsNew
            ZonaCuerpo.IsNew = false;

            return ZonaCuerpo;
        }
    }
}