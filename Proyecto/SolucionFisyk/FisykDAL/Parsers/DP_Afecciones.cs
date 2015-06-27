using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Afecciones : DTOParserSQLOracle
    {
        private int Ord_afnId;
        private int Ord_afnDescripcion;
        private int Ord_afn_tafId;
        private int Ord_afn_zcuId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_afnId = reader.GetOrdinal("afnId");
            Ord_afnDescripcion = reader.GetOrdinal("afnDescripcion");
            Ord_afn_tafId = reader.GetOrdinal("afn_tafId");
            Ord_afn_zcuId = reader.GetOrdinal("afn_zcuId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            AfeccionesDTO Afecciones = new AfeccionesDTO();
            // 
            if (!reader.IsDBNull(Ord_afnId)) { Afecciones.afnId = reader.GetInt32(Ord_afnId); }
            // 
            if (!reader.IsDBNull(Ord_afnDescripcion)) { Afecciones.afnDescripcion = reader.GetString(Ord_afnDescripcion); }
            // 
            if (!reader.IsDBNull(Ord_afn_tafId)) { Afecciones.afn_tafId = reader.GetInt32(Ord_afn_tafId); }
            // 
            if (!reader.IsDBNull(Ord_afn_zcuId)) { Afecciones.afn_zcuId = reader.GetInt32(Ord_afn_zcuId); }
            // IsNew
            Afecciones.IsNew = false;

            return Afecciones;
        }
    }
}
