using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Entidades;
using Bll;
using System.Web.Script.Services;
using Newtonsoft.Json;

namespace WebCostos.Servicios
{
    /// <summary>
    /// Summary description for FechasWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FechasWS : System.Web.Services.WebService
    {

        /*Metodo para insertar la fecha*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int InsertarFecha(FechasDTO Cat)
        {
            
            FechasDTO Objgrabar = new FechasDTO();
            FechasBll b = new FechasBll();

            Objgrabar.Id = Cat.Id;
            Objgrabar.Proyecto = Cat.Proyecto;
            Objgrabar.Fecha = Cat.Fecha;
            Objgrabar.Tipo = Cat.Tipo;
           
            return b.insert(Objgrabar);
           
        }
        /*------------------------------------------------*/

        /*Metodo para listar las fechas*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Fechas(string Proyecto)
        {
           FechasBll b = new FechasBll();
           return JsonConvert.SerializeObject(b.ListaFechas(Proyecto));

        }
        /*------------------------------------------------*/

        /*Metodo para listar las fechas de la linea base*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string FechasLineaBase(string Proyecto)
        {
            FechasBll b = new FechasBll();
            return JsonConvert.SerializeObject(b.ListaFechasLineaBase(Proyecto));

        }
        /*------------------------------------------------*/

         /*Metodo para eliminar las fechas*/
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string EliminarFecha(int Id)
        {
            FechasBll b = new FechasBll();
            return JsonConvert.SerializeObject(b.Delete(Id));

        }
        /*------------------------------------------------*/

    }
}
