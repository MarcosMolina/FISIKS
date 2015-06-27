using FisiksAppWeb;
using Oracle.DataAccess.Client;
using System;
using System.Data;

namespace FisykDAL
{
    public class PacienteDB : DALBase
    {
        //________________________________________________________________________________________________________
        // Grabar Paciente
        public static void GrabarPaciente(ref PacienteDTO Paciente)
        {
            OracleConnection con = DALBase.GetConn();
            con.Open();
            OracleTransaction tran = con.BeginTransaction();
            try
            {
                #region INSERT PERSONA  -------------------------------------------------------------------

                OracleCommand cmdPer = new OracleCommand("PRC_PERSONA_INSERT");
                cmdPer.CommandType = CommandType.StoredProcedure;
                cmdPer.Connection = con;


                cmdPer.Parameters.Add(CreateParameter("iPSNNRODCTO", Paciente.psnNroDcto, 9));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNNOMBRE", Paciente.psnNombre, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNAPELLIDO", Paciente.psnApellido, 45));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNFECHANAC", Paciente.psnFechaNac, 12));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNTELEFONO", Paciente.psnTelefono, 20));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSNSEXO", Paciente.psnSexo, 1));//VARCHAR
                cmdPer.Parameters.Add(CreateParameter("iPSN_DOMID", Paciente.psn_domId));//VARCHAR
                cmdPer.Parameters.Add(CrearParametroSalida("oPSNID", OracleDbType.Int32));//NUMBER

                cmdPer.Transaction = tran;
                cmdPer.ExecuteNonQuery();

                object xxxx = cmdPer.Parameters["oPSNID"].Value;

                Paciente.psnId = Convert.ToInt16(xxxx.ToString());

                #endregion

                #region INSERT PACIENTE -------------------------------------------------------------------

                OracleCommand cmdPac = new OracleCommand("PRC_PACIENTE_INSERT");
                cmdPac.CommandType = CommandType.StoredProcedure;
                cmdPac.Connection = con;

                cmdPac.Parameters.Add(CreateParameter("iPAEPESO", Paciente.paePeso));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAEALTURA", Paciente.paeAltura));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAEACTFISICA", Paciente.paeActFisica, 1));//VARCHAR
                cmdPac.Parameters.Add(CreateParameter("iPAEPERIODICIDAD", Paciente.paePeriodicidad));//NUMBER
                cmdPac.Parameters.Add(CreateParameter("iPAE_PSNID", Paciente.psnId));//NUMBER

                cmdPac.Transaction = tran;
                cmdPac.ExecuteNonQuery();//EJECUTO CONSULTA

                #endregion

                tran.Commit();//COMMIT LA TRANSACCION

                cmdPer.Connection.Close();//CERRAR
                cmdPer.Connection.Dispose();

                cmdPac.Connection.Close();//CERRAR
                cmdPac.Connection.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //________________________________________________________________________________________________________
        // Consulto un Paciente
        public static PacienteDTO ConsultoUnPaciente(string nroDoc)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_PACIENTE_SELECT");
            cmd.Parameters.Add(CreateParameter("iPsnnrodcto", nroDoc, 9));//VARCHAR
            cmd.Parameters.Add("oCursorPersona", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetSingleDTO<PacienteDTO>(ref cmd);
        }
    }
}
