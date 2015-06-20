using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Tratamiento : DTOParserSQLOracle
    {
        private int Ord_traId;
        private int Ord_traDescripcion;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_traId = reader.GetOrdinal("traId");
            Ord_traDescripcion = reader.GetOrdinal("traDescripcion");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            TratamientoDTO Tratamiento = new TratamientoDTO();
            // 
            if (!reader.IsDBNull(Ord_traId)) { Tratamiento.traId = reader.GetInt32(Ord_traId); }
            // 
            if (!reader.IsDBNull(Ord_traDescripcion)) { Tratamiento.traDescripcion = reader.GetString(Ord_traDescripcion); }
            // IsNew
            Tratamiento.IsNew = false;

            return Tratamiento;
        }
    }
}