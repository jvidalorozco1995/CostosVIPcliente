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
    /// Summary description for InformeSemanaLineaBase
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class InformeSemanaLineaBase : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CargarCostosSemanaLineaBase(int IdFecha)
        {

            Bll.SemanaLineaBaseBll b = new Bll.SemanaLineaBaseBll();


            return b.ListaCostosPresupuestos(IdFecha);

        }
        /*----------------------------------------------------*/

        #region METODOS COSTOS INDIRECTOS PARA SACAR EL INFORME DE LA SEMANA Pasada

        /*Para traer el detalle de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DetalleCostosIndirectosSemanaLineaBase(int IdFecha, string Proyecto)
        {

            Bll.SemanaLineaBaseBll b = new Bll.SemanaLineaBaseBll();

            return JsonConvert.SerializeObject(b.ListaDetalleCostosIndirectosMetodo(Proyecto));
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GruposCostosIndirectosSemanaLineaBase(int IdFecha, string Proyecto)
        {

            Bll.SemanaLineaBaseBll b = new Bll.SemanaLineaBaseBll();

            return JsonConvert.SerializeObject(b.ListaGruposCostosIndirectosMetodo(Proyecto));
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsolidadoCostosIndirectosSemanaLineaBase(int IdFecha, string Proyecto)
        {

            Bll.SemanaLineaBaseBll b = new Bll.SemanaLineaBaseBll();

            return JsonConvert.SerializeObject(b.ListaConsolidadoCostosIndirectosMetodo(Proyecto));
        }
        /*-------------------------------------------------*/
        #endregion

        #region METODOS COSTOS DIRECTOS PARA SACAR EL INFORME DE LA SEMANA Pasada
        /*Para traer el detalle de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DetalleCostosDirectosSemanaLineaBase(int IdFecha, string Proyecto)
        {

            Bll.SemanaLineaBaseBll b = new Bll.SemanaLineaBaseBll();

            return JsonConvert.SerializeObject(b.ListaDetalleCostosDirectosMetodo(Proyecto));
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GruposCostosDirectosSemanaLineaBase(int IdFecha)
        {

            Bll.SemanaLineaBaseBll b = new Bll.SemanaLineaBaseBll();

            return JsonConvert.SerializeObject(b.ListaGruposCostosDirectosMetodo());
        }
        /*-------------------------------------------------*/

        /*Para traer el consolidado de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsolidadoCostosDirectosSemanaLineaBase(int IdFecha, string Proyecto)
        {

            Bll.SemanaLineaBaseBll b = new Bll.SemanaLineaBaseBll();

            return JsonConvert.SerializeObject(b.ListaConsolidadoCostosDirectos(Proyecto));
        }
        /*-------------------------------------------------*/
        #endregion
    }
}
