using System;
using FisykDTO;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_ObraSocial : DTOParserSQLOracle
    {
        private int Ord_osoId;
        private int Ord_osoDescripcion;
        private int Ord_osoCoseguro;
        private int Ord_osoContacto;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_osoId = reader.GetOrdinal("osoId");
            Ord_osoDescripcion = reader.GetOrdinal("osoDescripcion");
            Ord_osoCoseguro = reader.GetOrdinal("osoCoseguro");
            Ord_osoContacto = reader.GetOrdinal("osoContacto");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            ObraSocialDTO ObraSocial = new ObraSocialDTO();
            // 
            if (!reader.IsDBNull(Ord_osoId)) { ObraSocial.osoId = reader.GetInt32(Ord_osoId); }
            // 
            if (!reader.IsDBNull(Ord_osoDescripcion)) { ObraSocial.osoDescripcion = reader.GetString(Ord_osoDescripcion); }
            // 
            if (!reader.IsDBNull(Ord_osoCoseguro)) { ObraSocial.osoCoseguro = reader.GetInt32(Ord_osoCoseguro); }
            // 
            if (!reader.IsDBNull(Ord_osoContacto)) { ObraSocial.osoContacto = reader.GetString(Ord_osoContacto); }
            // IsNew
            ObraSocial.IsNew = false;

            return ObraSocial;
        }
    }
}