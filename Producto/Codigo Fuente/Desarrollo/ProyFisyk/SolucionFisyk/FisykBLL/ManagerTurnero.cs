using System;
using System.Collections.Generic;
using FisiksAppWeb.Entities;
using FisykDAL;

namespace FisykBLL
{
    public class ManagerTurnero
    {
        //__________________________________________________________________________
        //  Lista de Turnos
        public static List<TurneroDto> ListTurnero(DateTime inicio, DateTime fin)
        {
            return TurneroDb.ListaTurnos(inicio, fin);
        }
        //__________________________________________________________________________
        //  Update de Turnos (Others)
        public static void UpdateTurnero(ref TurneroDto turno)
        {
            TurneroDb.UpdateTurno(ref turno);
        }
        //__________________________________________________________________________
        //  Update de Turnos (Times)
        public static void UpdateTurneroTime(ref TurneroDto turno)
        {
            TurneroDb.UpdateTurnoTime(ref turno);
        }
        //__________________________________________________________________________
        //  Eliminar un Turnos
        public static void DeleteTurnero(int idTurno)
        {
            TurneroDb.DeleteTurno(idTurno);
        }
        //__________________________________________________________________________
        //  Insertar Paciente
        public static int InsertaTurnero(ref TurneroDto turno)
        {
            return TurneroDb.InsertTurno(ref turno);
        }
    }
}
