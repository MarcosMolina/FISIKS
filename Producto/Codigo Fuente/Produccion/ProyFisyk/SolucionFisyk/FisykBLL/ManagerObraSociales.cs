using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL;

namespace FisykBLL
{
    public class ManagerObraSociales
    {
        //________________________________________________________________________________________________________
        //  Lista de Obras Sociales
        public static List<ObraSocialDto> ListObraSociales()
        {
            return ObraSocialDb.ListObraSociales();
        }
    }
}
