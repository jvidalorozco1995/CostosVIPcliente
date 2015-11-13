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
    /// Summary description for InformeSemanaPasada
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class InformeSemanaPasada : System.Web.Services.WebService
    {
        /*Metodo para cargar los costos de la semana Pasada*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CargarCostosSemanaPasada(int IdFecha)
        {

            Bll.SemanaPasadaBll b = new Bll.SemanaPasadaBll();


            return b.ListaCostosPresupuestos(IdFecha);

        }
        /*----------------------------------------------------*/

        #region METODOS COSTOS INDIRECTOS PARA SACAR EL INFORME DE LA SEMANA Pasada

        /*Para traer el detalle de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DetalleCostosIndirectosSemanaPasada(int IdFecha)
        {

            Bll.SemanaPasadaBll b = new Bll.SemanaPasadaBll();

            return JsonConvert.SerializeObject(b.ListaDetalleCostosIndirectosMetodo());
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GruposCostosIndirectosSemanaPasada(int IdFecha)
        {

            Bll.SemanaPasadaBll b = new Bll.SemanaPasadaBll();

            return JsonConvert.SerializeObject(b.ListaGruposCostosIndirectosMetodo());
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsolidadoCostosIndirectosSemanaPasada(int IdFecha)
        {

            Bll.SemanaPasadaBll b = new Bll.SemanaPasadaBll();

            return JsonConvert.SerializeObject(b.ListaConsolidadoCostosIndirectosMetodo());
        }
        /*-------------------------------------------------*/
        #endregion

        #region METODOS COSTOS DIRECTOS PARA SACAR EL INFORME DE LA SEMANA Pasada
        /*Para traer el detalle de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DetalleCostosDirectosSemanaPasada(int IdFecha)
        {

            Bll.SemanaPasadaBll b = new Bll.SemanaPasadaBll();

            return JsonConvert.SerializeObject(b.ListaDetalleCostosDirectosMetodo());
        }
        /*-------------------------------------------------*/

        /*Para traer los grupos de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GruposCostosDirectosSemanaPasada(int IdFecha)
        {

            Bll.SemanaPasadaBll b = new Bll.SemanaPasadaBll();

            return JsonConvert.SerializeObject(b.ListaGruposCostosDirectosMetodo());
        }
        /*-------------------------------------------------*/

        /*Para traer el consolidado de los costos indirectos*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsolidadoCostosDirectosSemanaPasada(int IdFecha)
        {

            Bll.SemanaPasadaBll b = new Bll.SemanaPasadaBll();

            return JsonConvert.SerializeObject(b.ListaConsolidadoCostosDirectos());
        }
        /*-------------------------------------------------*/
        #endregion
      
    }
}
