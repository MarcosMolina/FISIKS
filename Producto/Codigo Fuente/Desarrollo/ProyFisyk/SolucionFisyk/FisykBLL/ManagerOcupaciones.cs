using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL;

namespace FisykBLL
{
    public class ManagerOcupaciones
    {
        //________________________________________________________________________________________________________
        //  Lista de Ocupaciones
        public static List<OcupacionesDto> ListOcupaciones()
        {
            return OcupacionesDb.ListOcupaciones();
        }
    }
}
