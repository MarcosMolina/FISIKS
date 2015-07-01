using System;
using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Profesional : DTOParserSQLOracle
    {
        private int Ord_proId;
        private int Ord_proMatricula;
        private int Ord_proTelefonoInterno;
        private int Ord_pro_psnId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_proId = reader.GetOrdinal("proId");
            Ord_proMatricula = reader.GetOrdinal("proMatricula");
            Ord_proTelefonoInterno = reader.GetOrdinal("proTelefonoInterno");
            Ord_pro_psnId = reader.GetOrdinal("pro_psnId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            ProfesionalDTO Profesional = new ProfesionalDTO();
            // 
            if (!reader.IsDBNull(Ord_proId)) { Profesional.proId = reader.GetInt32(Ord_proId); }
            // 
            if (!reader.IsDBNull(Ord_proMatricula)) { Profesional.proMatricula = reader.GetInt32(Ord_proMatricula); }
            // 
            if (!reader.IsDBNull(Ord_proTelefonoInterno)) { Profesional.proTelefonoInterno = reader.GetString(Ord_proTelefonoInterno); }
            // 
            if (!reader.IsDBNull(Ord_pro_psnId)) { Profesional.pro_psnId = reader.GetInt32(Ord_pro_psnId); }
            // IsNew
            Profesional.IsNew = false;

            return Profesional;
        }
    }
}