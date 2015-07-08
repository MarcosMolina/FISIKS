using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerAntecedentesMedicos
    {
        //________________________________________________________________________________________________________
        //  Lista de Antecedentes Medicos
        public static List<AntecedenteMedicoDto> ListAntecedenteMedico()
        {
            return AntecendenteMedicoDb.ListAntecedenteMedico();
        }
    }
}
