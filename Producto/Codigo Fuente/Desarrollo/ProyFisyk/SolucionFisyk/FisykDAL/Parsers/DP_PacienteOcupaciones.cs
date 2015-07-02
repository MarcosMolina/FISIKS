using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpPacienteOcupaciones : DtoParserSqlOracle
    {
        private int _ordOpaId;
        private int _ordOpaPaeId;
        private int _ordOpaOcuId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordOpaId = reader.GetOrdinal("opaId");
            _ordOpaPaeId = reader.GetOrdinal("opa_paeId");
            _ordOpaOcuId = reader.GetOrdinal("opa_ocuId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var pacienteOcupaciones = new PacienteOcupacionesDto();
            // 
            if (!reader.IsDBNull(_ordOpaId)) { pacienteOcupaciones.OpaId = reader.GetInt32(_ordOpaId); }
            // 
            if (!reader.IsDBNull(_ordOpaPaeId)) { pacienteOcupaciones.OpaPaeId = reader.GetInt32(_ordOpaPaeId); }
            // 
            if (!reader.IsDBNull(_ordOpaOcuId)) { pacienteOcupaciones.OpaOcuId = reader.GetInt32(_ordOpaOcuId); }
            // IsNew
            pacienteOcupaciones.IsNew = false;

            return pacienteOcupaciones;
        }
    }
}