using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Provincia : DTOParserSQLOracle
    {
        private int Ord_pvcId;
        private int Ord_pvcDescripcion;
        private int Ord_pvc_pasId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_pvcId = reader.GetOrdinal("pvcId");
            Ord_pvcDescripcion = reader.GetOrdinal("pvcDescripcion");
            Ord_pvc_pasId = reader.GetOrdinal("pvc_pasId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            ProvinciaDTO Provincia = new ProvinciaDTO();
            // 
            if (!reader.IsDBNull(Ord_pvcId)) { Provincia.pvcId = reader.GetInt32(Ord_pvcId); }
            // 
            if (!reader.IsDBNull(Ord_pvcDescripcion)) { Provincia.pvcDescripcion = reader.GetString(Ord_pvcDescripcion); }
            // 
            if (!reader.IsDBNull(Ord_pvc_pasId)) { Provincia.pvc_pasId = reader.GetInt32(Ord_pvc_pasId); }
            // IsNew
            Provincia.IsNew = false;

            return Provincia;
        }
    }
}