using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_SesionDetalle : DTOParserSQLOracle
    {
        private int Ord_desId;
        private int Ord_desObservacion;
        private int Ord_des_traId;
        private int Ord_des_sesId;
        private int Ord_dse_traId;
        private int Ord_dse_afnId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_desId = reader.GetOrdinal("desId");
            Ord_desObservacion = reader.GetOrdinal("desObservacion");
            Ord_des_traId = reader.GetOrdinal("des_traId");
            Ord_des_sesId = reader.GetOrdinal("des_sesId");
            Ord_dse_traId = reader.GetOrdinal("dse_traId");
            Ord_dse_afnId = reader.GetOrdinal("dse_afnId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            SesionDetalleDTO SesionDetalle = new SesionDetalleDTO();
            // 
            if (!reader.IsDBNull(Ord_desId)) { SesionDetalle.desId = reader.GetInt32(Ord_desId); }
            // 
            if (!reader.IsDBNull(Ord_desObservacion)) { SesionDetalle.desObservacion = reader.GetString(Ord_desObservacion); }
            // 
            if (!reader.IsDBNull(Ord_des_traId)) { SesionDetalle.des_traId = reader.GetInt32(Ord_des_traId); }
            // 
            if (!reader.IsDBNull(Ord_des_sesId)) { SesionDetalle.des_sesId = reader.GetInt32(Ord_des_sesId); }
            // 
            if (!reader.IsDBNull(Ord_dse_traId)) { SesionDetalle.dse_traId = reader.GetInt32(Ord_dse_traId); }
            // 
            if (!reader.IsDBNull(Ord_dse_afnId)) { SesionDetalle.dse_afnId = reader.GetInt32(Ord_dse_afnId); }
            // IsNew
            SesionDetalle.IsNew = false;

            return SesionDetalle;
        }
    }
}