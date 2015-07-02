using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;

namespace FisykDAL
{
    public class OcupacionesDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<OcupacionesDto> ListOcupaciones()
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_OCUPACIONES_SELECT");
            cmd.Parameters.Add("oCursorOcupaciones", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetDtoList<OcupacionesDto>(ref cmd);
        }

        //________________________________________________________________________________________________________
    }
}
