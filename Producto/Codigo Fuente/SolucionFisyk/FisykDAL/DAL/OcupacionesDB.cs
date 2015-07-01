using FisiksAppWeb;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace FisykDAL
{
    public class OcupacionesDB : DALBase
    {
        //________________________________________________________________________________________________________
        public static List<OcupacionesDTO> ListOcupaciones()
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_OCUPACIONES_SELECT");
            cmd.Parameters.Add("oCursorOcupaciones", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetDTOList<OcupacionesDTO>(ref cmd);
        }

        //________________________________________________________________________________________________________
    }
}
