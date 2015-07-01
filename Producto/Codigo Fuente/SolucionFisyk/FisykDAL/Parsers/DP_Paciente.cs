using FisiksAppWeb;
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

        private int Ord_psnId;
        private int Ord_psn_tpdId;
        private int Ord_psnNroDcto;
        private int Ord_psnNombre;
        private int Ord_psnApellido;
        private int Ord_psnFechaNac;
        private int Ord_psnTelefono;
        private int Ord_psnSexo;
        private int Ord_psn_domId;




        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_paeId = reader.GetOrdinal("paeId");
            Ord_paePeso = reader.GetOrdinal("paePeso");
            Ord_paeAltura = reader.GetOrdinal("paeAltura");
            Ord_paeActFisica = reader.GetOrdinal("paeActFisica");
            Ord_paePeriodicidad = reader.GetOrdinal("paePeriodicidad");
            Ord_pae_psnId = reader.GetOrdinal("pae_psnId");


            Ord_psnId = reader.GetOrdinal("psnId");
            Ord_psn_tpdId = reader.GetOrdinal("psn_tpdId");
            Ord_psnNroDcto = reader.GetOrdinal("psnNroDcto");
            Ord_psnNombre = reader.GetOrdinal("psnNombre");
            Ord_psnApellido = reader.GetOrdinal("psnApellido");
            Ord_psnFechaNac = reader.GetOrdinal("psnFechaNac");
            Ord_psnTelefono = reader.GetOrdinal("psnTelefono");
            Ord_psnSexo = reader.GetOrdinal("psnSexo");
            Ord_psn_domId = reader.GetOrdinal("psn_domId");
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

            if (!reader.IsDBNull(Ord_psnId)) { Paciente.psnId = reader.GetInt32(Ord_psnId); }
            // 
            if (!reader.IsDBNull(Ord_psn_tpdId)) { Paciente.psn_tpdId = reader.GetInt32(Ord_psn_tpdId); }
            // 
            if (!reader.IsDBNull(Ord_psnNroDcto)) { Paciente.psnNroDcto = reader.GetString(Ord_psnNroDcto); }
            // 
            if (!reader.IsDBNull(Ord_psnNombre)) { Paciente.psnNombre = reader.GetString(Ord_psnNombre); }
            // 
            if (!reader.IsDBNull(Ord_psnApellido)) { Paciente.psnApellido = reader.GetString(Ord_psnApellido); }
            // 
            if (!reader.IsDBNull(Ord_psnFechaNac)) { Paciente.psnFechaNac = reader.GetString(Ord_psnFechaNac); }
            // 
            if (!reader.IsDBNull(Ord_psnTelefono)) { Paciente.psnTelefono = reader.GetString(Ord_psnTelefono); }
            // 
            if (!reader.IsDBNull(Ord_psnSexo)) { Paciente.psnSexo = reader.GetString(Ord_psnSexo); }
            // 
            if (!reader.IsDBNull(Ord_psn_domId)) { Paciente.psn_domId = reader.GetInt32(Ord_psn_domId); }
            // IsNew
            Paciente.IsNew = false;
 
            return Paciente;
        }
    }
}