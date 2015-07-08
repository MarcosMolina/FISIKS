using System.Collections.Generic;
using System.Data;
using FisiksAppWeb.Entities;
using Oracle.DataAccess.Client;

namespace FisykDAL.DAL
{
    public class AntecendenteMedicoDb : DalBase
    {
        //________________________________________________________________________________________________________
        public static List<AntecedenteMedicoDto> ListAntecedenteMedico()
        {
            OracleCommand cmd = GetDbSprocCommand("PRC_ANTECEDENTESMEDICOS_SELECT");
            cmd.Parameters.Add("oCursorAteMed", OracleDbType.RefCursor, ParameterDirection.Output);//CURSOR
            return GetDtoList<AntecedenteMedicoDto>(ref cmd);
        }

        //________________________________________________________________________________________________________
    }
}