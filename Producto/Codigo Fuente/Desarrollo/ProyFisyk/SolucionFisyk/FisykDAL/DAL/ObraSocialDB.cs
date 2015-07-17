using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class ObraSocialDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<ObraSocialDto> ListObraSociales()
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_OBRASOCIALES_SELECT");
            cmd.Parameters.Add("oCursorOSocial", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetDtoList<ObraSocialDto>(ref cmd);
        }

        //________________________________________________________________________________________________________
        public static List<PacienteOsDto> ListObraSocialesPaciente(int paeId)
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_PACIENTEOS_SELECT_FILTRO");
            cmd.Parameters.Add(CreateParameter("iPAEID", paeId));//VARCHAR
            cmd.Parameters.Add("oCursorOSocial", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetDtoList<PacienteOsDto>(ref cmd);
        }
    }
}
