using FisiksAppWeb;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace FisykDAL
{
    public class ObraSocialDB : DALBase
    {
        //________________________________________________________________________________________________________
        public static List<ObraSocialDTO> ListObraSociales()
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_OBRASOCIALES_SELECT");
            cmd.Parameters.Add("oCursorOSocial", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetDTOList<ObraSocialDTO>(ref cmd);
        }

        //________________________________________________________________________________________________________
    }
}
