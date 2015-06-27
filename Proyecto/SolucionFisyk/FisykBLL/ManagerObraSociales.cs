using FisiksAppWeb;
using FisykDAL;
using System.Collections.Generic;

namespace FisykBLL
{
    public class ManagerObraSociales
    {
        //________________________________________________________________________________________________________
        //  Lista de Obras Sociales
        public static List<ObraSocialDTO> ListObraSociales()
        {
            return ObraSocialDB.ListObraSociales();
        }
    }
}
