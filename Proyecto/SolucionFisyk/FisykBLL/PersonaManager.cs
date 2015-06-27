using FisiksAppWeb;
using FisykDAL;
using System.Collections.Generic;

namespace FisykBLL
{
    public class PersonaManager
    {
        //________________________________________________________________________________________________________
        public static List<PersonaDTO> GetPersona()
        {
            return PersonaDB.GetAll();
        }

        //________________________________________________________________________________________________________
        public static void SavePersona(PersonaDTO Persona)
        {
            PersonaDB.GrabarPersonas(ref Persona);
        }
    }
}
