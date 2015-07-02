using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpTurno : DtoParserSqlOracle
    {
        private int _ordTrnId;
        private int _ordTrnFecha;
        private int _ordTrnHora;
        private int _ordTrnMontoCobrado;
        private int _ordTrnEstId;
        private int _ordTrnProId;
        private int _ordTrnSesId;
        private int _ordTrnPaeId;
        private int _ordTrnDatId;
        private int _ordTrnOspId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordTrnId = reader.GetOrdinal("trnId");
            _ordTrnFecha = reader.GetOrdinal("trnFecha");
            _ordTrnHora = reader.GetOrdinal("trnHora");
            _ordTrnMontoCobrado = reader.GetOrdinal("trnMontoCobrado");
            _ordTrnEstId = reader.GetOrdinal("trn_estId");
            _ordTrnProId = reader.GetOrdinal("trn_proId");
            _ordTrnSesId = reader.GetOrdinal("trn_sesId");
            _ordTrnPaeId = reader.GetOrdinal("trn_paeId");
            _ordTrnDatId = reader.GetOrdinal("trn_datId");
            _ordTrnOspId = reader.GetOrdinal("trn_ospId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var turno = new TurnoDto();
            // 
            if (!reader.IsDBNull(_ordTrnId)) { turno.TrnId = reader.GetInt32(_ordTrnId); }
            // 
            if (!reader.IsDBNull(_ordTrnFecha)) { turno.TrnFecha = reader.GetString(_ordTrnFecha); }
            // 
            if (!reader.IsDBNull(_ordTrnHora)) { turno.TrnHora = reader.GetString(_ordTrnHora); }
            // 
            if (!reader.IsDBNull(_ordTrnMontoCobrado)) { turno.TrnMontoCobrado = reader.GetInt32(_ordTrnMontoCobrado); }
            // 
            if (!reader.IsDBNull(_ordTrnEstId)) { turno.TrnEstId = reader.GetInt32(_ordTrnEstId); }
            // 
            if (!reader.IsDBNull(_ordTrnProId)) { turno.TrnProId = reader.GetInt32(_ordTrnProId); }
            // 
            if (!reader.IsDBNull(_ordTrnSesId)) { turno.TrnSesId = reader.GetInt32(_ordTrnSesId); }
            // 
            if (!reader.IsDBNull(_ordTrnPaeId)) { turno.TrnPaeId = reader.GetInt32(_ordTrnPaeId); }
            // 
            if (!reader.IsDBNull(_ordTrnDatId)) { turno.TrnDatId = reader.GetInt32(_ordTrnDatId); }
            // 
            if (!reader.IsDBNull(_ordTrnOspId)) { turno.TrnOspId = reader.GetInt32(_ordTrnOspId); }
            // IsNew
            turno.IsNew = false;

            return turno;
        }
    }
}