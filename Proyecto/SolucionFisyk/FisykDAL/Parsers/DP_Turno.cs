using FisiksAppWeb;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    internal class DP_Turno : DTOParserSQLOracle
    {
        private int Ord_trnId;
        private int Ord_trnFecha;
        private int Ord_trnHora;
        private int Ord_trnMontoCobrado;
        private int Ord_trn_estId;
        private int Ord_trn_proId;
        private int Ord_trn_sesId;
        private int Ord_trn_paeId;
        private int Ord_trn_datId;
        private int Ord_trn_ospId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            Ord_trnId = reader.GetOrdinal("trnId");
            Ord_trnFecha = reader.GetOrdinal("trnFecha");
            Ord_trnHora = reader.GetOrdinal("trnHora");
            Ord_trnMontoCobrado = reader.GetOrdinal("trnMontoCobrado");
            Ord_trn_estId = reader.GetOrdinal("trn_estId");
            Ord_trn_proId = reader.GetOrdinal("trn_proId");
            Ord_trn_sesId = reader.GetOrdinal("trn_sesId");
            Ord_trn_paeId = reader.GetOrdinal("trn_paeId");
            Ord_trn_datId = reader.GetOrdinal("trn_datId");
            Ord_trn_ospId = reader.GetOrdinal("trn_ospId");
        }

        internal override DTOBase PopulateDTO(OracleDataReader reader)
        {
            TurnoDTO Turno = new TurnoDTO();
            // 
            if (!reader.IsDBNull(Ord_trnId)) { Turno.trnId = reader.GetInt32(Ord_trnId); }
            // 
            if (!reader.IsDBNull(Ord_trnFecha)) { Turno.trnFecha = reader.GetString(Ord_trnFecha); }
            // 
            if (!reader.IsDBNull(Ord_trnHora)) { Turno.trnHora = reader.GetString(Ord_trnHora); }
            // 
            if (!reader.IsDBNull(Ord_trnMontoCobrado)) { Turno.trnMontoCobrado = reader.GetInt32(Ord_trnMontoCobrado); }
            // 
            if (!reader.IsDBNull(Ord_trn_estId)) { Turno.trn_estId = reader.GetInt32(Ord_trn_estId); }
            // 
            if (!reader.IsDBNull(Ord_trn_proId)) { Turno.trn_proId = reader.GetInt32(Ord_trn_proId); }
            // 
            if (!reader.IsDBNull(Ord_trn_sesId)) { Turno.trn_sesId = reader.GetInt32(Ord_trn_sesId); }
            // 
            if (!reader.IsDBNull(Ord_trn_paeId)) { Turno.trn_paeId = reader.GetInt32(Ord_trn_paeId); }
            // 
            if (!reader.IsDBNull(Ord_trn_datId)) { Turno.trn_datId = reader.GetInt32(Ord_trn_datId); }
            // 
            if (!reader.IsDBNull(Ord_trn_ospId)) { Turno.trn_ospId = reader.GetInt32(Ord_trn_ospId); }
            // IsNew
            Turno.IsNew = false;

            return Turno;
        }
    }
}