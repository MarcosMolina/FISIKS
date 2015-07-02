using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpProfesional : DtoParserSqlOracle
    {
        private int _ordProId;
        private int _ordProMatricula;
        private int _ordProTelefonoInterno;
        private int _ordProPsnId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordProId = reader.GetOrdinal("proId");
            _ordProMatricula = reader.GetOrdinal("proMatricula");
            _ordProTelefonoInterno = reader.GetOrdinal("proTelefonoInterno");
            _ordProPsnId = reader.GetOrdinal("pro_psnId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var profesional = new ProfesionalDto();
            // 
            if (!reader.IsDBNull(_ordProId)) { profesional.ProId = reader.GetInt32(_ordProId); }
            // 
            if (!reader.IsDBNull(_ordProMatricula)) { profesional.ProMatricula = reader.GetInt32(_ordProMatricula); }
            // 
            if (!reader.IsDBNull(_ordProTelefonoInterno)) { profesional.ProTelefonoInterno = reader.GetString(_ordProTelefonoInterno); }
            // 
            if (!reader.IsDBNull(_ordProPsnId)) { profesional.ProPsnId = reader.GetInt32(_ordProPsnId); }
            // IsNew
            profesional.IsNew = false;

            return profesional;
        }
    }
}