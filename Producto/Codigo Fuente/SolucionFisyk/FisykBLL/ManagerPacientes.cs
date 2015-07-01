using FisykDAL;
using FisiksAppWeb;
using System.Collections.Generic;

namespace FisykBLL
{
    public class ManagerPacientes
    {
        //__________________________________________________________________________
        //  Insertar Paciente
        public static void GrabarPaciente(ref PacienteDTO pac)
        {
            PacienteDB.GrabarPaciente(ref pac);
        }

        //__________________________________________________________________________
        //  Existe Paciente
        public static PacienteDTO ExistePaciente(string nroDoc)
        {
            return PacienteDB.ConsultoUnPaciente(nroDoc);
        }


    }
}
