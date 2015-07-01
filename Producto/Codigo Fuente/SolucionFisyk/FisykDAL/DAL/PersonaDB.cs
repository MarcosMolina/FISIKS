using FisiksAppWeb;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace FisykDAL
{
    public class PersonaDB : DALBase
    {
        //________________________________________________________________________________________________________
        // GetAll
        public static List<PersonaDTO> GetAll()
        {
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = GetConn();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "PKG_PERSONA.InsertPersona";
                    
            //cmd.Parameters.Add(new OracleParameter(
            //    "c_per", OracleDbType.RefCursor, ParameterDirection.Output);

            //Datardr = cmd.ExecuteReader();
            //While (rdr.Read())
            //    REM do something with the values
            //End While

            //rdr.Close()
            
            List<PersonaDTO> ClientList = new List<PersonaDTO>();
            //try
            //{
            //    command.Connection.Open();
            //    OracleDataReader rd = cmd.ExecuteReader();
            //    SqlDataReader reader = command.ExecuteReader();
            //    PersonaDTO ObjClient;
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            PersonaDTO = new PersonaDTO();
            //            ObjClient.IDClient = reader.GetInt32(0);
            //            ObjClient.FirstName = reader.GetString(1);
            //            ObjClient.LastName = reader.GetString(2);
            //            ObjClient.IsNew = false;
            //            ClientList.Add(ObjClient);
            //        }
            //        reader.Close();
            //    }
            //    else
            //    {
            //        // Whenver there's no data, we return null.
            //        //dtoList = null;
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Error populating data", e);
            //}
            //finally
            //{
            //    command.Connection.Close();
            //    command.Connection.Dispose();
            //}
            return ClientList;
        }
        
        //________________________________________________________________________________________________________
        // GetPersonaByID
        public static PersonaDTO GetPersonaByID(string psnId)
        {
            OracleCommand cmd = GetDbSprocCommand("usp_Persona_GetByID");
            cmd.Parameters.Add(CreateParameter("@psnId", psnId, 15));
            return GetSingleDTO<PersonaDTO>(ref cmd);
        }

        //________________________________________________________________________________________________________
        // GetPersonaByDNI
        public static PersonaDTO GetPersonaByDNI(int psnNroDcto)
        {
            OracleCommand cmd = GetDbSprocCommand("usp_Persona_GetPersonaByDNI");
            cmd.Parameters.Add(CreateParameter("@psnNroDcto", psnNroDcto));
            return GetSingleDTO<PersonaDTO>(ref cmd);
        }

        //________________________________________________________________________________________________________
        // ExistByID
        public static bool ExistByID(int psnId)
        {
            OracleCommand cmd = GetDbSprocCommand("usp_Persona_ExistByID");
            cmd.Parameters.Add(CreateParameter("@psnId", psnId));
            cmd.Parameters.Add(CrearParametroSalida("@Exist", OracleDbType.Byte));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            if ((bool)cmd.Parameters["@Exist"].Value )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //________________________________________________________________________________________________________
        // SavePersona
        public static void GrabarPersonas(ref PersonaDTO Persona)
        {

            //#region Insert New Persona
            //OracleCommand cmd = new OracleCommand();
            //try
            //{
            //    ------------------------------------------------------------------------------
            //     Consulta Text
            //    ------------------------------------------------------------------------------
                string querystring = "INSERT INTO PERSONA ( psnNombre) VALUES (:psnNombre)";
                OracleCommand cmd = new OracleCommand(querystring);
                cmd.Connection = GetConn();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new OracleParameter(":psnNombre", Persona.psnNombre));

                //------------------------------------------------------------------------------
                // Consulta StoredProcedure
                //------------------------------------------------------------------------------
                //cmd.Connection = GetConn();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "PKG_PERSONA.InsertPersona";

                //cmd.Parameters.Add(CreateParameter("psn_tpdId", Persona.psn_tpdId));//NUMBER
                //cmd.Parameters.Add(CreateParameter("psnNroDcto", Persona.psnNroDcto));//NUMBER
                //cmd.Parameters.Add(CreateParameter("psnNombre", Persona.psnNombre, 45));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psnApellido", Persona.psnApellido, 45));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psnFechaNac", Persona.psnFechaNac, 12));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psnTelefono", Persona.psnTelefono, 20));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psnSexo", Persona.psnSexo, 1));//VARCHAR
                //cmd.Parameters.Add(CreateParameter("psn_domId", Persona.psn_domId));//NUMBER
                
                // Run the command.
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            //}
            //catch(Exception ex)
            //{ 
            //    throw ex; 
            //}
            //finally
            //{
            //    cmd.Connection.Close();
            //}
            //#endregion

            /*
            if (Persona.IsNew)
            {
                cmd = GetDbSprocCommand("usp_Persona_Insert");
                cmd.Parameters.Add(CreateOutputParameter("@psnId", OracleDbType.Int16));
            }
            else
            {
                cmd = GetDbSprocCommand("usp_Persona_Update");
                cmd.Parameters.Add(CreateParameter("@psnId", Persona.psnId));
            }

            cmd.Parameters.Add(CreateParameter("@psn_tpdId", Persona.psn_tpdId));//NUMBER
            cmd.Parameters.Add(CreateParameter("@psnNroDcto", Persona.psnNroDcto));//NUMBER
            cmd.Parameters.Add(CreateParameter("@psnNombre", Persona.psnNombre,45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psnApellido", Persona.psnApellido, 45));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psnFechaNac", Persona.psnFechaNac, 12));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psnTelefono", Persona.psnTelefono, 20));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psn_sexId", Persona.psn_sexId, 1));//VARCHAR
            cmd.Parameters.Add(CreateParameter("@psn_domId", Persona.psn_domId));//NUMBER
            
            // Run the command.
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
 * */
        }
    }
   
}

