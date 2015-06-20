using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Localidad : DTOParserSQLOracle
    {
        private int Ord_locId;
        private int Ord_locDescripcion;
        private int Ord_loc_pvcId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_locId = reader.GetOrdinal("locId");
            Ord_locDescripcion = reader.GetOrdinal("locDescripcion");
            Ord_loc_pvcId = reader.GetOrdinal("loc_pvcId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            LocalidadDTO Localidad = new LocalidadDTO();
            // 
            if (!reader.IsDBNull(Ord_locId)) { Localidad.locId = reader.GetInt32(Ord_locId); }
            // 
            if (!reader.IsDBNull(Ord_locDescripcion)) { Localidad.locDescripcion = reader.GetString(Ord_locDescripcion); }
            // 
            if (!reader.IsDBNull(Ord_loc_pvcId)) { Localidad.loc_pvcId = reader.GetInt32(Ord_loc_pvcId); }
            // IsNew
            Localidad.IsNew = false;

            return Localidad;
        }
    }
}