using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebCostos.Servicios
{
    /// <summary>
    /// Summary description for InformeSemanaActual
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class InformeSemanaActual : System.Web.Services.WebService
    {
        /*Metodo para cargar los costos de la semana actual*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CargarCostosSemanaActual(int IdFecha)
        {

            Bll.SemanaActualBll b = new Bll.SemanaActualBll();


            return b.ListaCostosPresupuestos(IdFecha);

        }
        /*----------------------------------------------------*/

        #region METODOS COSTOS INDIRECTOS PARA SACAR EL INFORME DE LA SEMANA ACTUAL

        /*Para traer el detalle de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DetalleCostosIndirectosSemanaActual(int IdFecha, string Proyecto)
        {

            Bll.SemanaActualBll b = new Bll.SemanaActualBll();

            return JsonConvert.SerializeObject(b.ListaDetalleCostosIndirectosMetodo(Proyecto));
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GruposCostosIndirectosSemanaActual(int IdFecha, string Proyecto)
        {

            Bll.SemanaActualBll b = new Bll.SemanaActualBll();

            return JsonConvert.SerializeObject(b.ListaGruposCostosIndirectosMetodo(Proyecto));
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsolidadoCostosIndirectosSemanaActual(int IdFecha, string Proyecto)
        {

            Bll.SemanaActualBll b = new Bll.SemanaActualBll();

            return JsonConvert.SerializeObject(b.ListaConsolidadoCostosIndirectosMetodo(Proyecto));
        }
        /*-------------------------------------------------*/
        #endregion

        #region METODOS COSTOS DIRECTOS PARA SACAR EL INFORME DE LA SEMANA ACTUAL
        /*Para traer el detalle de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DetalleCostosDirectosSemanaActual(int IdFecha, string Proyecto)
        {

            Bll.SemanaActualBll b = new Bll.SemanaActualBll();

            return JsonConvert.SerializeObject(b.ListaDetalleCostosDirectosMetodo(Proyecto));
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GruposCostosDirectosSemanaActual(int IdFecha)
        {

            Bll.SemanaActualBll b = new Bll.SemanaActualBll();

            return JsonConvert.SerializeObject(b.ListaGruposCostosDirectosMetodo());
        }
        /*-------------------------------------------------*/

        /*Para traer el consolidado de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsolidadoCostosDirectosSemanaActual(int IdFecha, string Proyecto)
        {

            Bll.SemanaActualBll b = new Bll.SemanaActualBll();

            return JsonConvert.SerializeObject(b.ListaConsolidadoCostosDirectos(Proyecto));
        }
        /*-------------------------------------------------*/

        /*Para traer el consolidado de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListaConsolidadoGlobal(int IdFecha, string Proyecto)
        {

            Bll.SemanaActualBll b = new Bll.SemanaActualBll();

            return JsonConvert.SerializeObject(b.ListaConsolidadoGlobal(Proyecto));
        }
        /*-------------------------------------------------*/
       #endregion

    }
}
