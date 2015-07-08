using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

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
