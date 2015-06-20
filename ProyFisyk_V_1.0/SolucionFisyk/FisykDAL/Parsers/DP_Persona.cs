using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Persona : DTOParserSQLOracle
    {
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
            PersonaDTO Persona = new PersonaDTO();
            // 
            if (!reader.IsDBNull(Ord_psnId)) { Persona.psnId = reader.GetInt32(Ord_psnId); }
            // 
            if (!reader.IsDBNull(Ord_psn_tpdId)) { Persona.psn_tpdId = reader.GetInt32(Ord_psn_tpdId); }
            // 
            if (!reader.IsDBNull(Ord_psnNroDcto)) { Persona.psnNroDcto = reader.GetInt32(Ord_psnNroDcto); }
            // 
            if (!reader.IsDBNull(Ord_psnNombre)) { Persona.psnNombre = reader.GetString(Ord_psnNombre); }
            // 
            if (!reader.IsDBNull(Ord_psnApellido)) { Persona.psnApellido = reader.GetString(Ord_psnApellido); }
            // 
            if (!reader.IsDBNull(Ord_psnFechaNac)) { Persona.psnFechaNac = reader.GetString(Ord_psnFechaNac); }
            // 
            if (!reader.IsDBNull(Ord_psnTelefono)) { Persona.psnTelefono = reader.GetString(Ord_psnTelefono); }
            // 
            if (!reader.IsDBNull(Ord_psnSexo)) { Persona.psnSexo = reader.GetString(Ord_psnSexo); }
            // 
            if (!reader.IsDBNull(Ord_psn_domId)) { Persona.psn_domId = reader.GetInt32(Ord_psn_domId); }
            // IsNew
            Persona.IsNew = false;

            return Persona;
        }
    }
}