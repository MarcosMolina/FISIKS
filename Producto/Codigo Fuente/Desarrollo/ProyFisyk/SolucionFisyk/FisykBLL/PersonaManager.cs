using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL;

namespace FisykBLL
{
    public class PersonaManager
    {
        //________________________________________________________________________________________________________
        public static List<PersonaDto> GetPersona()
        {
            return PersonaDb.GetAll();
        }

        //________________________________________________________________________________________________________
        public static void SavePersona(PersonaDto Persona)
        {
            PersonaDb.GrabarPersonas(ref Persona);
        }
    }
}
