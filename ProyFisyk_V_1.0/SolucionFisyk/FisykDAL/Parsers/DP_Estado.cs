using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Estado : DTOParserSQLOracle
    {
        private int Ord_estId;
        private int Ord_estDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_estId = reader.GetOrdinal("estId");
            Ord_estDescripcion = reader.GetOrdinal("estDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            EstadoDTO Estado = new EstadoDTO();
            // 
            if (!reader.IsDBNull(Ord_estId)) { Estado.estId = reader.GetInt32(Ord_estId); }
            // 
            if (!reader.IsDBNull(Ord_estDescripcion)) { Estado.estDescripcion = reader.GetString(Ord_estDescripcion); }
            // IsNew
            Estado.IsNew = false;

            return Estado;
        }
    }
}

