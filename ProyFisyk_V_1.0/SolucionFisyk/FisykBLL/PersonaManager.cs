using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FisykDTO;
using FisykDAL;

namespace FisykBLL
{
    public class PersonaManager
    {
        public static List<PersonaDTO> GetPersona()
        {
            return PersonaDB.GetAll();
        }

        public static void SavePersona(PersonaDTO Persona)
        {
            PersonaDB.GrabarPersonas(ref Persona);
        }
    }
}
