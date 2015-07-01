using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Sesion : DTOParserSQLOracle
    {
        private int Ord_sesId;
        private int Ord_sesNumero;
        private int Ord_sesObservacion;
        private int Ord_sesFecha;
        private int Ord_sesHoraInicio;
        private int Ord_sesHoraFin;
        private int Ord_sesUltima;
        private int Ord_ses_hcaId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_sesId = reader.GetOrdinal("sesId");
            Ord_sesNumero = reader.GetOrdinal("sesNumero");
            Ord_sesObservacion = reader.GetOrdinal("sesObservacion");
            Ord_sesFecha = reader.GetOrdinal("sesFecha");
            Ord_sesHoraInicio = reader.GetOrdinal("sesHoraInicio");
            Ord_sesHoraFin = reader.GetOrdinal("sesHoraFin");
            Ord_sesUltima = reader.GetOrdinal("sesUltima");
            Ord_ses_hcaId = reader.GetOrdinal("ses_hcaId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            SesionDTO Sesion = new SesionDTO();
            // 
            if (!reader.IsDBNull(Ord_sesId)) { Sesion.sesId = reader.GetInt32(Ord_sesId); }
            // 
            if (!reader.IsDBNull(Ord_sesNumero)) { Sesion.sesNumero = reader.GetInt32(Ord_sesNumero); }
            // 
            if (!reader.IsDBNull(Ord_sesObservacion)) { Sesion.sesObservacion = reader.GetString(Ord_sesObservacion); }
            // 
            if (!reader.IsDBNull(Ord_sesFecha)) { Sesion.sesFecha = reader.GetString(Ord_sesFecha); }
            // 
            if (!reader.IsDBNull(Ord_sesHoraInicio)) { Sesion.sesHoraInicio = reader.GetString(Ord_sesHoraInicio); }
            // 
            if (!reader.IsDBNull(Ord_sesHoraFin)) { Sesion.sesHoraFin = reader.GetString(Ord_sesHoraFin); }
            // 
            if (!reader.IsDBNull(Ord_sesUltima)) { Sesion.sesUltima = reader.GetString(Ord_sesUltima); }
            // 
            if (!reader.IsDBNull(Ord_ses_hcaId)) { Sesion.ses_hcaId = reader.GetInt32(Ord_ses_hcaId); }
            // IsNew
            Sesion.IsNew = false;

            return Sesion;
        }
    }
}