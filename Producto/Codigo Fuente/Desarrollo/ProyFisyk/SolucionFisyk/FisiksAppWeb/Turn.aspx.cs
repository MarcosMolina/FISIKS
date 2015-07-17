using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using FisiksAppWeb.Entities;
using FisykBLL;

namespace FisiksAppWeb
{
    public partial class Turn : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod(true)]
        public static string UpdateEvent(TurneroDto pagTurnero)
        {
            List<int> idList = (List<int>)HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(pagTurnero.TurId))
            {
                if (CheckAlphaNumeric(pagTurnero.TurTitulo) && CheckAlphaNumeric(pagTurnero.TurDescripcion))
                {
                    TurneroDto turno = new TurneroDto();
                    turno.TurId = pagTurnero.TurId;
                    turno.TurTitulo = pagTurnero.TurTitulo;
                    turno.TurDescripcion = pagTurnero.TurDescripcion;
                    turno.TurPaeId = pagTurnero.TurPaeId;
                    turno.TurProId = pagTurnero.TurProId;

                    ManagerTurnero.UpdateTurnero(ref turno);

                    return "Se actualizo el Turno Nro:" + pagTurnero.TurId;
                }
            }
            return "No se puede actualizar el Turno Nro:" + pagTurnero.TurId;
        }


        [System.Web.Services.WebMethod(true)]
        public static string UpdateEventTime(TurneroImportDto pagTurneroImp)
        {
            List<int> idList = (List<int>)HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(pagTurneroImp.TurImpId))
            {
                TurneroDto turno = new TurneroDto();
                turno.TurId = pagTurneroImp.TurImpId;
                turno.TurFechaIni = Convert.ToDateTime(pagTurneroImp.TurImpFechaIni).ToUniversalTime();
                turno.TurFechaFin = Convert.ToDateTime(pagTurneroImp.TurImpFechaFin).ToUniversalTime();
                turno.TurTodoDia = pagTurneroImp.TurImpTodoDia;

                ManagerTurnero.UpdateTurnero(ref turno);

                return "Se actualizo el Turno Nro:" + pagTurneroImp.TurImpId;
            }
            return "No se puede actualizar el Turno Nro:" + pagTurneroImp.TurImpId;
        }


        [System.Web.Services.WebMethod(true)]
        public static string DeleteEvent(int id)
        {
            List<int> idList = (List<int>)HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(id))
            {
                ManagerTurnero.DeleteTurnero(id);
                return "Se el elimino el Turno Nro:" + id;
            }
            return "No se puede eliminar el Turno Nro: " + id;
        }


        [System.Web.Services.WebMethod(true)]
        public static int AddEvent(TurneroImportDto pagTurneroImp)
        {
            TurneroDto turno = new TurneroDto();
            turno.TurTitulo = pagTurneroImp.TurImpTitulo;
            turno.TurDescripcion = pagTurneroImp.TurImpDescripcion;
            turno.TurFechaIni = Convert.ToDateTime(pagTurneroImp.TurImpFechaIni).ToUniversalTime();
            turno.TurFechaFin = Convert.ToDateTime(pagTurneroImp.TurImpFechaFin).ToUniversalTime();
            turno.TurTodoDia = pagTurneroImp.TurImpTodoDia;
            turno.TurPaeId = Convert.ToInt32(pagTurneroImp.TurImpPaeId);
            turno.TurProId = Convert.ToInt32(pagTurneroImp.TurImpProId);

            if (CheckAlphaNumeric(turno.TurTitulo) && CheckAlphaNumeric(turno.TurDescripcion))
            {
                int key = ManagerTurnero.InsertaTurnero(ref turno);

                List<int> idList = (List<int>)HttpContext.Current.Session["idList"];

                if (idList != null)
                {
                    idList.Add(key);
                }
                return key; //return the primary key of the added cevent object
            }
            return -1; //return a negative number just to signify nothing has been added
        }


        private static bool CheckAlphaNumeric(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z0-9 ]*$");
        }
    }
}