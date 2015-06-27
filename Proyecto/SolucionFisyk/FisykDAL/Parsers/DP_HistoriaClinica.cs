using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_HistoriaClinica : DTOParserSQLOracle
    {
        private int Ord_hcaId;
        private int Ord_hcaNroSesiones;
        private int Ord_hcaFecha;
        private int Ord_hca_afnId;
        private int Ord_hca_paeId;
        private int Ord_hcaCantEvaluaciones;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_hcaId = reader.GetOrdinal("hcaId");
            Ord_hcaNroSesiones = reader.GetOrdinal("hcaNroSesiones");
            Ord_hcaFecha = reader.GetOrdinal("hcaFecha");
            Ord_hca_afnId = reader.GetOrdinal("hca_afnId");
            Ord_hca_paeId = reader.GetOrdinal("hca_paeId");
            Ord_hcaCantEvaluaciones = reader.GetOrdinal("hcaCantEvaluaciones");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            HistoriaClinicaDTO HistoriaClinica = new HistoriaClinicaDTO();
            // 
            if (!reader.IsDBNull(Ord_hcaId)) { HistoriaClinica.hcaId = reader.GetInt32(Ord_hcaId); }
            // 
            if (!reader.IsDBNull(Ord_hcaNroSesiones)) { HistoriaClinica.hcaNroSesiones = reader.GetInt32(Ord_hcaNroSesiones); }
            // 
            if (!reader.IsDBNull(Ord_hcaFecha)) { HistoriaClinica.hcaFecha = reader.GetDateTime(Ord_hcaFecha); }
            // 
            if (!reader.IsDBNull(Ord_hca_afnId)) { HistoriaClinica.hca_afnId = reader.GetInt32(Ord_hca_afnId); }
            // 
            if (!reader.IsDBNull(Ord_hca_paeId)) { HistoriaClinica.hca_paeId = reader.GetInt32(Ord_hca_paeId); }
            // 
            if (!reader.IsDBNull(Ord_hcaCantEvaluaciones)) { HistoriaClinica.hcaCantEvaluaciones = reader.GetInt32(Ord_hcaCantEvaluaciones); }
            // IsNew
            HistoriaClinica.IsNew = false;

            return HistoriaClinica;
        }
    }
}

