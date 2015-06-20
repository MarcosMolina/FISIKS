using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Ocupaciones : DTOParserSQLOracle
    {
        private int Ord_ocuId;
        private int Ord_ocuDescripcion;
        private int Ord_ocuSedentaria;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_ocuId = reader.GetOrdinal("ocuId");
            Ord_ocuDescripcion = reader.GetOrdinal("ocuDescripcion");
            Ord_ocuSedentaria = reader.GetOrdinal("ocuSedentaria");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            OcupacionesDTO Ocupaciones = new OcupacionesDTO();
            // 
            if (!reader.IsDBNull(Ord_ocuId)) { Ocupaciones.ocuId = reader.GetInt32(Ord_ocuId); }
            // 
            if (!reader.IsDBNull(Ord_ocuDescripcion)) { Ocupaciones.ocuDescripcion = reader.GetString(Ord_ocuDescripcion); }
            // 
            if (!reader.IsDBNull(Ord_ocuSedentaria)) { Ocupaciones.ocuSedentaria = reader.GetString(Ord_ocuSedentaria); }
            // IsNew
            Ocupaciones.IsNew = false;

            return Ocupaciones;
        }
    }
}

