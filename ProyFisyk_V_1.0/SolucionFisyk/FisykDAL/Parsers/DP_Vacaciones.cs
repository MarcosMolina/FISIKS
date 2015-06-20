using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Vacaciones : DTOParserSQLOracle
    {
        private int Ord_vacId;
        private int Ord_vacFechaDesde;
        private int Ord_vacFechaHasta;
        private int Ord_vac_proId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_vacId = reader.GetOrdinal("vacId");
            Ord_vacFechaDesde = reader.GetOrdinal("vacFechaDesde");
            Ord_vacFechaHasta = reader.GetOrdinal("vacFechaHasta");
            Ord_vac_proId = reader.GetOrdinal("vac_proId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            VacacionesDTO Vacaciones = new VacacionesDTO();
            // 
            if (!reader.IsDBNull(Ord_vacId)) { Vacaciones.vacId = reader.GetInt32(Ord_vacId); }
            // 
            if (!reader.IsDBNull(Ord_vacFechaDesde)) { Vacaciones.vacFechaDesde = reader.GetString(Ord_vacFechaDesde); }
            // 
            if (!reader.IsDBNull(Ord_vacFechaHasta)) { Vacaciones.vacFechaHasta = reader.GetString(Ord_vacFechaHasta); }
            // 
            if (!reader.IsDBNull(Ord_vac_proId)) { Vacaciones.vac_proId = reader.GetInt32(Ord_vac_proId); }
            // IsNew
            Vacaciones.IsNew = false;

            return Vacaciones;
        }
    }
} 