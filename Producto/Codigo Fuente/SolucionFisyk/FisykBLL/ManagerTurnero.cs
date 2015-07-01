using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FisiksAppWeb;
using FisykDAL;

namespace FisykBLL
{
    public class ManagerTurnero
    {
        //__________________________________________________________________________
        //  Lista de Turnos
        public static List<TurneroDTO> ListTurnero(DateTime inicio, DateTime fin)
        {
            return TurneroDB.ListaTurnos(inicio, fin);
        }
        //__________________________________________________________________________
        //  Update de Turnos (Others)
        public static void UpdateTurnero(ref TurneroDTO turno)
        {
            TurneroDB.UpdateTurno(ref turno);
        }
        //__________________________________________________________________________
        //  Update de Turnos (Times)
        public static void UpdateTurneroTime(ref TurneroDTO turno)
        {
            TurneroDB.UpdateTurnoTime(ref turno);
        }
        //__________________________________________________________________________
        //  Eliminar un Turnos
        public static void DeleteTurnero(int IdTurno)
        {
            TurneroDB.DeleteTurno(IdTurno);
        }
        //__________________________________________________________________________
        //  Insertar Paciente
        public static int InsertaTurnero(ref TurneroDTO turno)
        {
            return TurneroDB.InsertTurno(ref turno);
        }
    }
}
