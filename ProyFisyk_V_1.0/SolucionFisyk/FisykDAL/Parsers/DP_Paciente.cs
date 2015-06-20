using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Paciente : DTOParserSQLOracle
    {
        private int Ord_paeId;
        private int Ord_paePeso;
        private int Ord_paeAltura;
        private int Ord_paeActFisica;
        private int Ord_paePeriodicidad;
        private int Ord_pae_psnId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_paeId = reader.GetOrdinal("paeId");
            Ord_paePeso = reader.GetOrdinal("paePeso");
            Ord_paeAltura = reader.GetOrdinal("paeAltura");
            Ord_paeActFisica = reader.GetOrdinal("paeActFisica");
            Ord_paePeriodicidad = reader.GetOrdinal("paePeriodicidad");
            Ord_pae_psnId = reader.GetOrdinal("pae_psnId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            PacienteDTO Paciente = new PacienteDTO();
            // 
            if (!reader.IsDBNull(Ord_paeId)) { Paciente.paeId = reader.GetInt32(Ord_paeId); }
            // 
            if (!reader.IsDBNull(Ord_paePeso)) { Paciente.paePeso = reader.GetInt32(Ord_paePeso); }
            // 
            if (!reader.IsDBNull(Ord_paeAltura)) { Paciente.paeAltura = reader.GetInt32(Ord_paeAltura); }
            // 
            if (!reader.IsDBNull(Ord_paeActFisica)) { Paciente.paeActFisica = reader.GetString(Ord_paeActFisica); }
            // 
            if (!reader.IsDBNull(Ord_paePeriodicidad)) { Paciente.paePeriodicidad = reader.GetInt32(Ord_paePeriodicidad); }
            // 
            if (!reader.IsDBNull(Ord_pae_psnId)) { Paciente.pae_psnId = reader.GetInt32(Ord_pae_psnId); }
            // IsNew
            Paciente.IsNew = false;

            return Paciente;
        }
    }
}