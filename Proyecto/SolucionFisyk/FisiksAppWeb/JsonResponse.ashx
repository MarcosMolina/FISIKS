<%@ WebHandler Language="C#" Class="JsonResponse" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.SessionState;
using FisykDTO;
using FisykBLL;

public class JsonResponse : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        DateTime start = Convert.ToDateTime(context.Request.QueryString["start"]);
        DateTime end = Convert.ToDateTime(context.Request.QueryString["end"]);

        List<int> idList = new List<int>();
        List<TurneroImportDTO> tasksList = new List<TurneroImportDTO>();

        //Generate JSON serializable events
        foreach (TurneroDTO turno in ManagerTurnero.ListTurnero(start, end))
        {
            tasksList.Add(new TurneroImportDTO
                            {
                                turImpId = turno.turId,
                                turImpTitulo = turno.turTitulo,
                                turImpDescripcion = turno.turDescripcion,
                                turImpFechaIni = String.Format("{0:g}", turno.turFechaIni),
                                turImpFechaFin = String.Format("{0:g}", turno.turFechaFin),
                                turImpTodoDia = turno.turTodoDia,
                                turImp_paeId = turno.tur_paeId,
                               turImp_proId = turno.tur_proId
                            }
                        );
            idList.Add(turno.turId);
        }

        context.Session["idList"] = idList;

        //Serialize events to string
        System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        string sJSON = oSerializer.Serialize(tasksList);

        //Write JSON to response object
        context.Response.Write(sJSON);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}