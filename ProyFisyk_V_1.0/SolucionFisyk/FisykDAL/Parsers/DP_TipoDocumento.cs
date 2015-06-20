using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_TipoDocumento : DTOParserSQLOracle
    {
        private int Ord_tpdId;
        private int Ord_tpdDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_tpdId = reader.GetOrdinal("tpdId");
            Ord_tpdDescripcion = reader.GetOrdinal("tpdDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            TipoDocumentoDTO TipoDocumento = new TipoDocumentoDTO();
            // 
            if (!reader.IsDBNull(Ord_tpdId)) { TipoDocumento.tpdId = reader.GetInt32(Ord_tpdId); }
            // 
            if (!reader.IsDBNull(Ord_tpdDescripcion)) { TipoDocumento.tpdDescripcion = reader.GetString(Ord_tpdDescripcion); }
            // IsNew
            TipoDocumento.IsNew = false;

            return TipoDocumento;
        }
    }
}