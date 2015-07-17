using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerPacientes
    {
        //__________________________________________________________________________
        //  Insertar Paciente
        public static void GrabarPacienteInsert(ref PacienteDto paciente)
        {
            PacienteDb.GrabarPacienteInsert(ref paciente);
        }

        //__________________________________________________________________________
        //  Update Paciente
        public static void GrabarPacienteUpdate(ref PacienteDto paciente)
        {
            PacienteDb.GrabarPacienteUpdate(ref paciente);
        }

        //__________________________________________________________________________
        //  Existe Paciente
        public static PacienteDto ExistePaciente(string nroDoc)
        {
            return PacienteDb.ConsultoUnPaciente(nroDoc);
        }


    }
}
