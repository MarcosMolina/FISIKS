using FisykDAL;
using FisiksAppWeb;
using System.Collections.Generic;

namespace FisykBLL
{
    public class ManagerOcupaciones
    {
        //________________________________________________________________________________________________________
        //  Lista de Ocupaciones
        public static List<OcupacionesDTO> ListOcupaciones()
        {
            return OcupacionesDB.ListOcupaciones();
        }
    }
}
