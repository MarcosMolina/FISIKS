using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Dia : DTOParserSQLOracle
    {
        private int Ord_diaId;
        private int Ord_diaDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_diaId = reader.GetOrdinal("diaId");
            Ord_diaDescripcion = reader.GetOrdinal("diaDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            DiaDTO Dia = new DiaDTO();
            // 
            if (!reader.IsDBNull(Ord_diaId)) { Dia.diaId = reader.GetInt32(Ord_diaId); }
            // 
            if (!reader.IsDBNull(Ord_diaDescripcion)) { Dia.diaDescripcion = reader.GetString(Ord_diaDescripcion); }
            // IsNew
            Dia.IsNew = false;

            return Dia;
        }
    }
}
