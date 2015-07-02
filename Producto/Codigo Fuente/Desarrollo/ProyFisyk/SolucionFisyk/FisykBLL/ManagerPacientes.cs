using FisiksAppWeb.Entities;
using FisykDAL.DAL;

namespace FisykBLL
{
    public class ManagerPacientes
    {
        //__________________________________________________________________________
        //  Insertar Paciente
        public static void GrabarPaciente(ref PacienteDto paciente)
        {
            PacienteDb.GrabarPaciente(ref paciente);
        }

        //__________________________________________________________________________
        //  Existe Paciente
        //public static PacienteDTO ExistePaciente(string nroDoc)
        //{
        //    return PacienteDB.ConsultoUnPaciente(nroDoc);
        //}


    }
}
