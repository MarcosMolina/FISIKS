using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Agenda : DTOParserSQLOracle
    {
        private int Ord_ageId;
        private int Ord_ageHoraDesde;
        private int Ord_ageHoraHasta;
        private int Ord_age_proId;
        private int Ord_age_diaId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_ageId = reader.GetOrdinal("ageId");
            Ord_ageHoraDesde = reader.GetOrdinal("ageHoraDesde");
            Ord_ageHoraHasta = reader.GetOrdinal("ageHoraHasta");
            Ord_age_proId = reader.GetOrdinal("age_proId");
            Ord_age_diaId = reader.GetOrdinal("age_diaId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            AgendaDTO Agenda = new AgendaDTO();
            // 
            if (!reader.IsDBNull(Ord_ageId)) { Agenda.ageId = reader.GetInt32(Ord_ageId); }
            // 
            if (!reader.IsDBNull(Ord_ageHoraDesde)) { Agenda.ageHoraDesde = reader.GetDateTime(Ord_ageHoraDesde); }
            // 
            if (!reader.IsDBNull(Ord_ageHoraHasta)) { Agenda.ageHoraHasta = reader.GetDateTime(Ord_ageHoraHasta); }
            // 
            if (!reader.IsDBNull(Ord_age_proId)) { Agenda.age_proId = reader.GetInt32(Ord_age_proId); }
            // 
            if (!reader.IsDBNull(Ord_age_diaId)) { Agenda.age_diaId = reader.GetInt32(Ord_age_diaId); }
            // IsNew
            Agenda.IsNew = false;

            return Agenda;
        }
    }
}

