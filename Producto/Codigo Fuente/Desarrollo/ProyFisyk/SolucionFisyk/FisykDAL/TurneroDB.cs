using System;
using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    public class TurneroDb : DalBase
    {
        public static List<TurneroDto> ListaTurnos(DateTime pStart, DateTime pEnd)
        {
            List<TurneroDto> listaTurnos = new List<TurneroDto>();
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
                    TurneroDto objTur = new TurneroDto();

                    objTur.TurId = Convert.ToInt32(odr[0]);
                    objTur.TurTitulo = odr[1].ToString();
                    objTur.TurDescripcion = odr[2].ToString();
                    objTur.TurFechaIni = Convert.ToDateTime(odr[3]);
                    objTur.TurFechaFin = Convert.ToDateTime(odr[4]);
                    string varOv = odr[5].ToString();  Boolean varTd = false; if (varOv == "1") { varTd = true; }
                    objTur.TurTodoDia = varTd;
                    objTur.TurPaeId = Convert.ToInt32(odr[6]);
                    objTur.TurProId = Convert.ToInt32(odr[7]);

                    listaTurnos.Add(objTur);
                }

                cmd.Connection.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaTurnos;
        }

        public static void UpdateTurno(ref TurneroDto turno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_UPDATE");
            cmd.Parameters.Add(CreateParameter("iTURID", turno.TurId));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTURTITULO", turno.TurTitulo, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURDESCRIPCION", turno.TurDescripcion, 255));//VARCHAR
            //cmd.Parameters.Add(CreateParameter("iTURFECHAINI", turno.turFechaIni));//DATETIME
            //cmd.Parameters.Add(CreateParameter("iTURFECHAFIN", turno.turFechaFin));//DATETIME
            //cmd.Parameters.Add(new OracleParameter("iTURTODODIA", turno.turTodoDia));//BOOL
            cmd.Parameters.Add(CreateParameter("iTUR_PAEID", turno.TurPaeId));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTUR_PROID", turno.TurProId));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
            cmd.Dispose();
        }

        public static void UpdateTurnoTime(ref TurneroDto turno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_UPDATE");
            cmd.Parameters.Add(CreateParameter("iTURID", turno.TurId));//NUMBER
            //cmd.Parameters.Add(CreateParameter("iTURTITULO", turno.turTitulo, 45));//VARCHAR
            //cmd.Parameters.Add(CreateParameter("iTURDESCRIPCION", turno.turDescripcion, 255));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURFECHAINI", turno.TurFechaIni));//DATETIME
            cmd.Parameters.Add(CreateParameter("iTURFECHAFIN", turno.TurFechaFin));//DATETIME
            cmd.Parameters.Add(new OracleParameter("iTURTODODIA", turno.TurTodoDia));//BOOL
            //cmd.Parameters.Add(CreateParameter("iTUR_PAEID", turno.tur_paeId));//NUMBER
            //cmd.Parameters.Add(CreateParameter("iTUR_PROID", turno.tur_proId));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
            cmd.Dispose();
        }

        public static void DeleteTurno(int idTurno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_DELETE");
            cmd.Parameters.Add(CreateParameter("iTURID", idTurno));//NUMBER

            cmd.Connection.Open();//ABRO
            cmd.ExecuteNonQuery();//EJECUTO CONSULTA
            cmd.Connection.Close();//CERRAR
        }

        public static int InsertTurno(ref TurneroDto turno)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_TURNERO_INSERT");

            cmd.Parameters.Add(CreateParameter("iTURTITULO", turno.TurTitulo, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURDESCRIPCION", turno.TurDescripcion, 255));//VARCHAR
            cmd.Parameters.Add(CreateParameter("iTURFECHAINI", turno.TurFechaIni));//DATETIME
            cmd.Parameters.Add(CreateParameter("iTURFECHAFIN", turno.TurFechaFin));//DATETIME
            cmd.Parameters.Add(new OracleParameter("iTURTODODIA", turno.TurTodoDia));//BOOL
            cmd.Parameters.Add(CreateParameter("iTUR_PAEID", turno.TurPaeId));//NUMBER
            cmd.Parameters.Add(CreateParameter("iTUR_PROID", turno.TurProId));//NUMBER

            cmd.Parameters.Add(CrearParametroSalida("oTURID", OracleDbType.Int32));//NUMBER

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            object xxxx = cmd.Parameters["oPSNID"].Value;
            turno.TurId = Convert.ToInt16(xxxx.ToString());
            int key = 0;
            key = turno.TurId;

            cmd.Connection.Close();
            cmd.Dispose();

            return key;
        }
    }
}
