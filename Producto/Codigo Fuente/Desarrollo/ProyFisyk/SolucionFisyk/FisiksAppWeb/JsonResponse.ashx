<%@ WebHandler Language="C#" Class="JsonResponse" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using FisiksAppWeb.Entities;
using FisykBLL;

public class JsonResponse : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        DateTime start = Convert.ToDateTime(context.Request.QueryString["start"]);
        DateTime end = Convert.ToDateTime(context.Request.QueryString["end"]);

        List<int> idList = new List<int>();
        List<TurneroImportDto> tasksList = new List<TurneroImportDto>();

        //Generate JSON serializable events
        foreach (TurneroDto turno in ManagerTurnero.ListTurnero(start, end))
        {
            tasksList.Add(new TurneroImportDto( 
                turno.TurProId, 
                turno.TurTitulo, 
                turno.TurDescripcion,
                String.Format("{0:g}", turno.TurFechaIni),
                                String.Format("{0:g}", turno.TurFechaFin),
                                turno.TurTodoDia,
                               turno.TurPaeId,
                                turno.TurProId
                            )
                        );
            idList.Add(turno.TurId);
        }

        context.Session["idList"] = idList;

        //Serialize events to string
        JavaScriptSerializer oSerializer = new JavaScriptSerializer();
        string sJSON = oSerializer.Serialize(tasksList);

        //Write JSON to response object
        context.Response.Write(sJSON);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}