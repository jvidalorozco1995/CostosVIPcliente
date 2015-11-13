using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Web.Script.Services;

using Entidades;
using Bll;
using Newtonsoft.Json;



namespace WebCostos.Servicios
{
    /// <summary>
    /// Summary description for ProyectosWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProyectosWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        //llama al metodo CargarGridView, Retorna una lista.
        [ScriptMethod(ResponseFormat = ResponseFormat.Json,UseHttpGet=true)]
        public string ListaProyectos()
        {
            ProyectosBll b = new ProyectosBll();
            return JsonConvert.SerializeObject(b.ListaProyectos());

        }

        [WebMethod]
        //llama al metodo CargarGridView, Retorna una lista.
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListaProyectos2()
        {
            ProyectosBll b = new ProyectosBll();
            return JsonConvert.SerializeObject(b.ListaProyectos());

        }

    }
}
