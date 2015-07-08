using System;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class PacienteDb : DalBase
    {
        //________________________________________________________________________________________________________
        // Grabar Paciente
        public static void GrabarPaciente(ref PacienteDto paciente)
        {
            OracleConnection con = GetConn();
            con.Open();
            OracleTransaction tran = con.BeginTransaction();

            #region INSERT PERSONA  -------------------------------------------------------------------

            OracleCommand cmdPer = new OracleCommand("PRC_PERSONA_INSERT");
            cmdPer.CommandType = CommandType.StoredProcedure;
            cmdPer.Connection = con;


            cmdPer.Parameters.Add(CreateParameter("iPSNNRODCTO", paciente.PsnNroDcto, 9));//VARCHAR
            cmdPer.Parameters.Add(CreateParameter("iPSNNOMBRE", paciente.PsnNombre, 45));//VARCHAR
            cmdPer.Parameters.Add(CreateParameter("iPSNAPELLIDO", paciente.PsnApellido, 45));//VARCHAR
            cmdPer.Parameters.Add(CreateParameter("iPSNFECHANAC", paciente.PsnFechaNac, 12));//VARCHAR
            cmdPer.Parameters.Add(CreateParameter("iPSNTELEFONO", paciente.PsnTelefono, 20));//VARCHAR
            cmdPer.Parameters.Add(CreateParameter("iPSNSEXO", paciente.PsnSexo, 1));//VARCHAR
            cmdPer.Parameters.Add(CreateParameter("iPSNDOMICILIO", paciente.PsnDomicilio, 50));//VARCHAR
            cmdPer.Parameters.Add(CrearParametroSalida("oPSNID", OracleDbType.Int32));//NUMBER

            cmdPer.Transaction = tran;
            cmdPer.ExecuteNonQuery();

            var varPsnid = cmdPer.Parameters["oPSNID"].Value;
            paciente.PsnId = Convert.ToInt16(varPsnid.ToString());

            #endregion

            #region INSERT PACIENTE -------------------------------------------------------------------

            OracleCommand cmdPac = new OracleCommand("PRC_PACIENTE_INSERT");
            cmdPac.CommandType = CommandType.StoredProcedure;
            cmdPac.Connection = con;

            cmdPac.Parameters.Add(CreateParameter("iPAEPESO", paciente.PaePeso));//NUMBER
            cmdPac.Parameters.Add(CreateParameter("iPAEALTURA", paciente.PaeAltura));//NUMBER
            cmdPac.Parameters.Add(CreateParameter("iPAEACTFISICA", paciente.PaeActFisica, 1));//VARCHAR
            cmdPac.Parameters.Add(CreateParameter("iPAEPERIODICIDAD", paciente.PaePeriodicidad));//NUMBER
            cmdPac.Parameters.Add(CreateParameter("iPAE_OCUID", paciente.PaeOcuId));//NUMBER
            cmdPac.Parameters.Add(CreateParameter("iPAE_PSNID", paciente.PsnId));//NUMBER
            cmdPac.Parameters.Add(CrearParametroSalida("oPAEID", OracleDbType.Int32));//NUMBER

            cmdPac.Transaction = tran;
            cmdPac.ExecuteNonQuery();//EJECUTO CONSULTA

            var varPaeid = cmdPac.Parameters["oPAEID"].Value;
            paciente.PaeId = Convert.ToInt16(varPaeid.ToString());

            #endregion

            #region INSERT OBRAS SOCIALES -------------------------------------------------------------

            OracleCommand cmdObSoc = null; 
            foreach (PacienteOsDto oPos in paciente.PaeListObraSocial)
            {
                //    ------------------------------------------------------------------------------
                //     Consulta Text
                //    ------------------------------------------------------------------------------
                string querystring = "INSERT INTO PACIENTEOS ( OSP_PAEID,    OSP_OSOID,   OSPNROSOCIO) " +
                                                    " VALUES (:iOSP_PAEID, :iOSP_OSOID, :iOSPNROSOCIO) ";
                cmdObSoc = new OracleCommand(querystring);
                cmdObSoc.Connection = con;
                cmdObSoc.CommandType = CommandType.Text;

                cmdObSoc.Parameters.Add(CreateParameter(":iOSP_PAEID", paciente.PaeId));//NUMBER
                cmdObSoc.Parameters.Add(CreateParameter(":iOSP_OSOID", oPos.OspOsoId));//NUMBER
                cmdObSoc.Parameters.Add(new OracleParameter(":iOSPNROSOCIO", oPos.OspNroSocio));//NUMBER        

                cmdObSoc.Transaction = tran;
                cmdObSoc.ExecuteNonQuery();//EJECUTO CONSULTA

                //cmdObSoc = new OracleCommand("PRC_PACIENTEOS_INSERT");
                //cmdObSoc.CommandType = CommandType.StoredProcedure;
                //cmdObSoc.Connection = con;
            }

            #endregion


            tran.Commit();//COMMIT LA TRANSACCION

            cmdPer.Connection.Close();//CERRAR
            cmdPer.Connection.Dispose();

            cmdPac.Connection.Close();//CERRAR
            cmdPac.Connection.Dispose();

            if (cmdObSoc != null)
            {
                cmdObSoc.Connection.Close();//CERRAR
                cmdObSoc.Connection.Dispose();
            }

        }

        //________________________________________________________________________________________________________
        // Consulto un Paciente
        public static PacienteDto ConsultoUnPaciente(string nroDoc)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_PACIENTE_SELECT");
            cmd.Parameters.Add(CreateParameter("iPsnnrodcto", nroDoc, 9));//VARCHAR
            cmd.Parameters.Add("oCursorPersona", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetSingleDto<PacienteDto>(ref cmd);
        }
    }
}
