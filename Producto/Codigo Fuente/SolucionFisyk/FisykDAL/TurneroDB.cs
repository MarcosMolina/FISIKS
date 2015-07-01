using FisiksAppWeb;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace FisykDAL
{
    public class TurneroDB : DALBase
    {
        public static List<TurneroDTO> ListaTurnos(DateTime pStart, DateTime pEnd)
        {
            List<TurneroDTO> ListaTurnos = new List<TurneroDTO>();
            try
            {
                OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_SELECT");
                cmd.BindByName = true;
                cmd.Parameters.Add(CreateParameter("iTurFechaIni", pStart));//FECHA
                cmd.Parameters.Add(CreateParameter("iTurFechaFin", pEnd));//FECHA
                cmd.Parameters.Add("oCursorTurnero", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR

                cmd.Connection.Open();
                OracleDataReader odr = cmd.ExecuteReader();
                while (odr.Read())
                {
                    TurneroDTO objTur = new TurneroDTO();

                    objTur.turId = Convert.ToInt32(odr[0]);
                    objTur.turTitulo = odr[1].ToString();
                    objTur.turDescripcion = odr[2].ToString();
                    objTur.turFechaIni = Convert.ToDateTime(odr[3]);
                    objTur.turFechaFin = Convert.ToDateTime(odr[4]);
                    string varOV = odr[5].ToString();  Boolean varTD = false; if (varOV == "1") { varTD = true; }
                    objTur.turTodoDia = varTD;
                    objTur.tur_paeId = Convert.ToInt32(odr[6]);
                    objTur.tur_proId = Convert.ToInt32(odr[7]);

                    ListaTurnos.Add(objTur);
                }

                cmd.Connection.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaTurnos;
        }

        public static void UpdateTurno(ref TurneroDTO turno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_UPDATE");
            cmd.Parameters.Add(CreateParameter("iTURID", turno.turId));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTURTITULO", turno.turTitulo, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURDESCRIPCION", turno.turDescripcion, 255));//VARCHAR
            //cmd.Parameters.Add(CreateParameter("iTURFECHAINI", turno.turFechaIni));//DATETIME
            //cmd.Parameters.Add(CreateParameter("iTURFECHAFIN", turno.turFechaFin));//DATETIME
            //cmd.Parameters.Add(new OracleParameter("iTURTODODIA", turno.turTodoDia));//BOOL
            cmd.Parameters.Add(CreateParameter("iTUR_PAEID", turno.tur_paeId));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTUR_PROID", turno.tur_proId));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
            cmd.Dispose();
        }

        public static void UpdateTurnoTime(ref TurneroDTO turno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_UPDATE");
            cmd.Parameters.Add(CreateParameter("iTURID", turno.turId));//NUMBER
            //cmd.Parameters.Add(CreateParameter("iTURTITULO", turno.turTitulo, 45));//VARCHAR
            //cmd.Parameters.Add(CreateParameter("iTURDESCRIPCION", turno.turDescripcion, 255));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURFECHAINI", turno.turFechaIni));//DATETIME
            cmd.Parameters.Add(CreateParameter("iTURFECHAFIN", turno.turFechaFin));//DATETIME
            cmd.Parameters.Add(new OracleParameter("iTURTODODIA", turno.turTodoDia));//BOOL
            //cmd.Parameters.Add(CreateParameter("iTUR_PAEID", turno.tur_paeId));//NUMBER
            //cmd.Parameters.Add(CreateParameter("iTUR_PROID", turno.tur_proId));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
            cmd.Dispose();
        }

        public static void DeleteTurno(int IdTurno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_DELETE");
            cmd.Parameters.Add(CreateParameter("iTURID", IdTurno));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
        }

        public static int InsertTurno(ref TurneroDTO turno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_INSERT");

            cmd.Parameters.Add(CreateParameter("iTURTITULO", turno.turTitulo, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURDESCRIPCION", turno.turDescripcion, 255));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURFECHAINI", turno.turFechaIni));//DATETIME
            cmd.Parameters.Add(CreateParameter("iTURFECHAFIN", turno.turFechaFin));//DATETIME
            cmd.Parameters.Add(new OracleParameter("iTURTODODIA", turno.turTodoDia));//BOOL
            cmd.Parameters.Add(CreateParameter("iTUR_PAEID", turno.tur_paeId));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTUR_PROID", turno.tur_proId));//NUMBER

            cmd.Parameters.Add(CrearParametroSalida("oTURID", OracleDbType.Int32));//NUMBER

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            object xxxx = cmd.Parameters["oPSNID"].Value;
            turno.turId = Convert.ToInt16(xxxx.ToString());
            int key = 0;
            key = turno.turId;

            cmd.Connection.Close();
            cmd.Dispose();

            return key;
        }
    }
}
