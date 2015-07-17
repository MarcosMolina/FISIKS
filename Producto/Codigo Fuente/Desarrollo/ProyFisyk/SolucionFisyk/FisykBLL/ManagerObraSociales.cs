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

        //________________________________________________________________________________________________________
        //  Lista de Obras Sociales por Paciente
        public static List<PacienteOsDto> ListObraSocialesPaciente(int paeId)
        {
            return ObraSocialDb.ListObraSocialesPaciente(paeId);
        }
    }
}
