using FisykBLL;
using FisiksAppWeb;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FisiksAppWeb
{
    public partial class Turn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod(true)]
        public static string UpdateEvent(TurneroDTO pagTurnero)
        {
            List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(pagTurnero.turId))
            {
                if (CheckAlphaNumeric(pagTurnero.turTitulo) && CheckAlphaNumeric(pagTurnero.turDescripcion))
                {
                    TurneroDTO turno = new TurneroDTO();
                    turno.turId = pagTurnero.turId;
                    turno.turTitulo = pagTurnero.turTitulo;
                    turno.turDescripcion = pagTurnero.turDescripcion;
                    turno.tur_paeId = pagTurnero.tur_paeId;
                    turno.tur_proId = pagTurnero.tur_proId;

                    ManagerTurnero.UpdateTurnero(ref turno);

                    return "Se actualizo el Turno Nro:" + pagTurnero.turId;
                }
            }
            return "No se puede actualizar el Turno Nro:" + pagTurnero.turId;
        }


        [System.Web.Services.WebMethod(true)]
        public static string UpdateEventTime(TurneroImportDTO pagTurneroImp)
        {
            List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(pagTurneroImp.turImpId))
            {
                TurneroDTO turno = new TurneroDTO();
                turno.turId = pagTurneroImp.turImpId;
                turno.turFechaIni = Convert.ToDateTime(pagTurneroImp.turImpFechaIni).ToUniversalTime();
                turno.turFechaFin = Convert.ToDateTime(pagTurneroImp.turImpFechaFin).ToUniversalTime();
                turno.turTodoDia = pagTurneroImp.turImpTodoDia;

                ManagerTurnero.UpdateTurnero(ref turno);

                return "Se actualizo el Turno Nro:" + pagTurneroImp.turImpId;
            }
            return "No se puede actualizar el Turno Nro:" + pagTurneroImp.turImpId;
        }


        [System.Web.Services.WebMethod(true)]
        public static String deleteEvent(int id)
        {
            List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(id))
            {
                ManagerTurnero.DeleteTurnero(id);
                return "Se el elimino el Turno Nro:" + id;
            }
            return "No se puede eliminar el Turno Nro: " + id;
        }


        [System.Web.Services.WebMethod]
        public static int addEvent(TurneroImportDTO pagTurneroImp)
        {
            TurneroDTO turno = new TurneroDTO();
            turno.turTitulo = pagTurneroImp.turImpTitulo;
            turno.turDescripcion = pagTurneroImp.turImpDescripcion;
            turno.turFechaIni = Convert.ToDateTime(pagTurneroImp.turImpFechaIni).ToUniversalTime();
            turno.turFechaFin = Convert.ToDateTime(pagTurneroImp.turImpFechaFin).ToUniversalTime();
            turno.turTodoDia = pagTurneroImp.turImpTodoDia;
            turno.tur_paeId = Convert.ToInt32(pagTurneroImp.turImp_paeId);
            turno.tur_proId = Convert.ToInt32(pagTurneroImp.turImp_proId);

            if (CheckAlphaNumeric(turno.turTitulo) && CheckAlphaNumeric(turno.turDescripcion))
            {
                int key = ManagerTurnero.InsertaTurnero(ref turno);

                List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];

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