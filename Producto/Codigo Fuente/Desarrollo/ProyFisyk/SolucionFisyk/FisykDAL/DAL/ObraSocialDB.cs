using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;

namespace FisykDAL
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
    }
}
