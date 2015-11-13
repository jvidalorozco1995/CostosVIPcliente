using Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;

using BllJsonCal;
using System.ComponentModel;

namespace WebCostos.Servicios
{
    /// <summary>
    /// Summary description for Recibir
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Recibir : System.Web.Services.WebService
    {

       [WebMethod]
       [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
       public string ListaOrdenes()
        {

            Bll.OrdenesBll b = new Bll.OrdenesBll();

            return JsonConvert.SerializeObject(b.ListaOrdenes(2));

        }

       [WebMethod]
        public string InsertarAreas(string dtBuildSQL)
        {
           try
            {
                var theString = dtBuildSQL;
                var aStringBuilder = new StringBuilder(theString);

                theString = aStringBuilder.ToString().TrimEnd('"');
                theString = theString.TrimStart('"');

                System.IO.File.WriteAllText(@"F:\Usuarios\jvidal\Documents\Log\Areas.json", Holsa.RemoveWhitespace(theString));
                Utilidades cn = new Utilidades();
                string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
                SqlBulkCopy copia = new SqlBulkCopy(sConnectionString);
                copia.BulkCopyTimeout = 900000;
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(theString, typeof(DataTable));
                DataTable TablaCopia = dt;
                copia.DestinationTableName = "Areas";
                copia.WriteToServer(TablaCopia);
                TablaCopia.Dispose();

            }
            catch (Exception ex) {

                /*si hubo un error me envia este mensaje*/
                return "No Insertado Areas"+ex;
            }
           /*si tuvo exito me envia este mensaje de error*/
            return "Ok Areas";
        }

       [WebMethod]
       public string InsertarTablaSalidas(string dtBuildSQL)
        {
           try
            {
                /*Metodo que llena la lista de salidas para poder calcular el archivo de costos*/
                List<SalidasDTO> i = CostosPptoProgJSON.CargarSalidas(dtBuildSQL);


                /*Metodo que llena un datatable salidas y lo inserta en la base de datos*/
                var theString = dtBuildSQL;
                var aStringBuilder = new StringBuilder(theString);
                theString = aStringBuilder.ToString().TrimEnd('"');
                theString = theString.TrimStart('"');
                System.IO.File.WriteAllText(@"F:\Usuarios\jvidal\Documents\Log\Salidas.json", Holsa.RemoveWhitespace(theString));
                Utilidades cn = new Utilidades();
                string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
                SqlBulkCopy copia = new SqlBulkCopy(sConnectionString);
                copia.BulkCopyTimeout = 900000;
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(theString, typeof(DataTable));
                DataTable TablaCopia = dt;
                copia.DestinationTableName = "Salidas";
                copia.WriteToServer(TablaCopia);
                TablaCopia.Dispose();


            }
            catch (Exception ex) {
              
                /*si hubo un error me envia este mensaje*/
                return "No Insertado Salidas"+ex;
            }
            /*si tuvo exito me envia este mensaje de error*/
            return "Ok salidas";
        }


       [WebMethod]
       public string InsertarTablaCostoEntrado(string dtBuildSQL)
       {
           try
           {
               var theString = dtBuildSQL;
               var aStringBuilder = new StringBuilder(theString);
               theString = aStringBuilder.ToString().TrimEnd('"');
               theString = theString.TrimStart('"');
               /*Metodo que llena la lista ordenes para poder calcular el archivo de costos*/
               List<CostoEntradoDTO> i = CostosPptoProgJSON.CargarCostoEntrado(Holsa.RemoveWhitespace(theString));

             
                   /*Metodo que llena un datatable costoentrado y lo inserta en la base de datos*/
              
                   System.IO.File.WriteAllText(@"F:\Usuarios\jvidal\Documents\Log\CostoEntrado.json", Holsa.RemoveWhitespace(theString));
                   Utilidades cn = new Utilidades();
                   string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
                   SqlBulkCopy copia = new SqlBulkCopy(sConnectionString);
                   copia.BulkCopyTimeout = 900000;

                   DataTable dt = (DataTable)JsonConvert.DeserializeObject(theString, typeof(DataTable));
                 //  DataTable dt = ConvertToDatatable(i);
                   DataTable TablaCopia = dt;
                   copia.DestinationTableName = "CostoEntrado";
                   copia.WriteToServer(TablaCopia);
                   TablaCopia.Dispose();

                   return "Ok CostoEntrado";
               
               

           }
           catch (Exception ex)
           {
               /*si hubo un error me envia este mensaje*/
               return "No Insertado CostoEntrado" + ex;
           }
           /*si tuvo exito me envia este mensaje de error*/
           
       }


       [WebMethod]
       public string InsertarTablaOrdenes(string dtBuildSQL)
       {
           try
            {
               /*Metodo que llena la lista ordenes para poder calcular el archivo de costos*/
               List<OrdenesDTO> i = CostosPptoProgJSON.CargarOrdenes(dtBuildSQL);
        
               /*Metodo que llena un datatable ordenes y lo inserta en la base de datos*/
               var theString = dtBuildSQL;
               var aStringBuilder = new StringBuilder(theString);
               theString = aStringBuilder.ToString().TrimEnd('"');
               theString = theString.TrimStart('"');
               System.IO.File.WriteAllText(@"F:\Usuarios\jvidal\Documents\Log\Ordenes.json", Holsa.RemoveWhitespace(theString));
               Utilidades cn = new Utilidades();
               string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
               SqlBulkCopy copia = new SqlBulkCopy(sConnectionString);
               copia.BulkCopyTimeout = 900000;
               DataTable dt = (DataTable)JsonConvert.DeserializeObject(theString,typeof(DataTable));
               DataTable TablaCopia = dt;
               copia.DestinationTableName = "Ordenes";
               copia.WriteToServer(TablaCopia);
               TablaCopia.Dispose();
              
               

            }
           catch (Exception ex)
           {
             /*si hubo un error me envia este mensaje*/
             return "No Insertado Ordenes"+ex;
           }
           /*si tuvo exito me envia este mensaje de error*/
           return "Ok Ordenes";
       }


       [WebMethod]
       public string InsertarTablaPedidos(string dtBuildSQL)
       {
           try
           {

               /*Metodo que llena la lista Pedidos para poder calcular el archivo de costos*/
               List<PedidosDTO> i = CostosPptoProgJSON.CargarPedidos(dtBuildSQL);

               /*Metodo que llena un datatable Pedidos y lo inserta en la base de datos*/
               var theString = dtBuildSQL;
               var aStringBuilder = new StringBuilder(theString);
               theString = aStringBuilder.ToString().TrimEnd('"');
               theString = theString.TrimStart('"');
               System.IO.File.WriteAllText(@"F:\Usuarios\jvidal\Documents\Log\Pedidos.json", Holsa.RemoveWhitespace(theString));
               Utilidades cn = new Utilidades();
               string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
               SqlBulkCopy copia = new SqlBulkCopy(sConnectionString);
               copia.BulkCopyTimeout = 900000;
               DataTable dt = (DataTable)JsonConvert.DeserializeObject(theString, typeof(DataTable));
               DataTable TablaCopia = dt;
               copia.DestinationTableName = "Pedidos";
               copia.WriteToServer(TablaCopia);
               TablaCopia.Dispose();


           }
           catch (Exception ex)
           {
               /*si hubo un error me envia este mensaje*/
               return "No Insertado Ordenes" + ex;
           }
           /*si tuvo exito me envia este mensaje de error*/
           return "Ok Pedidos";
       }


       [WebMethod]
       public string InsertarTablaDescuentos(string dtBuildSQL)
       {
           try
           {

               /*Metodo que llena la lista Pedidos para poder calcular el archivo de costos*/
               List<DescuentosDTO> i = CostosPptoProgJSON.CargarDescuentos(dtBuildSQL);

               /*Metodo que llena un datatable Pedidos y lo inserta en la base de datos*/
               var theString = dtBuildSQL;
               var aStringBuilder = new StringBuilder(theString);
               theString = aStringBuilder.ToString().TrimEnd('"');
               theString = theString.TrimStart('"');
               System.IO.File.WriteAllText(@"F:\Usuarios\jvidal\Documents\Log\Descuentos.json", Holsa.RemoveWhitespace(theString));
               Utilidades cn = new Utilidades();
               string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
               SqlBulkCopy copia = new SqlBulkCopy(sConnectionString);
               copia.BulkCopyTimeout = 900000;
               DataTable dt = (DataTable)JsonConvert.DeserializeObject(theString, typeof(DataTable));
               DataTable TablaCopia = dt;
               copia.DestinationTableName = "Descuentos";
               copia.WriteToServer(TablaCopia);
               TablaCopia.Dispose();


           }
           catch (Exception ex)
           {
               /*si hubo un error me envia este mensaje*/
               return "No Insertado Descuentos" + ex;
           }
           /*si tuvo exito me envia este mensaje de error*/
           return "Ok Descuentos";
       }

       [WebMethod]
       [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
       public string InsertarTablaCostoPptoProg(string dtBuildSQL)
       {
           try
           {
               List<CostosPptoProgDTOCOMPLETO> i = CostosPptoProgJSON.CargarCostos(dtBuildSQL);
               if (i != null && i.Count > 0)
               {

                   JavaScriptSerializer serializer = new JavaScriptSerializer();
                   serializer.MaxJsonLength = 999999999;
                   System.IO.File.WriteAllText(@"F:\Usuarios\jvidal\Documents\Log\CostoPptoProg.json", Holsa.RemoveWhitespace(serializer.Serialize(i)));

                    var theString = dtBuildSQL;
                    var aStringBuilder = new StringBuilder(theString);
                    //aStringBuilder.Remove(0, 1);
                    theString = aStringBuilder.ToString().TrimEnd('"');
                    theString = theString.TrimStart('"');
                    Utilidades cn = new Utilidades();
                    string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
                    SqlBulkCopy copia = new SqlBulkCopy(sConnectionString);
                    copia.BulkCopyTimeout = 900000;
                   // DataTable dt = (DataTable)JsonConvert.DeserializeObject(serializer.Serialize(i), typeof(DataTable));
                    List<CostosPptoProgDTOCOMPLETO> cos = CostosPptoProgJSON.ActualizarCosto();
            
                    
                    DataTable dt = ConvertToDatatable(cos);
                    DataTable TablaCopia = dt;
                    copia.DestinationTableName = "CostosPptoProg";
                    copia.WriteToServer(TablaCopia);
                    TablaCopia.Dispose();
                    return "Ok costopproptog";
               }
               else
               {
                   return "No se ha podido insertar Costos";
               }

           }
           catch (Exception ex) {

             return ex.Message;
           }
          
       }





        /*Metodo que se encarga de convertir un datatable a XML*/
        static DataTable ParseXML(string xmlString)
        {

            DataSet ds = new DataSet();
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlString);
            Stream memory = new MemoryStream(xmlBytes);
            ds.ReadXml(memory);
            return ds.Tables[0];
        }

        private static DataTable ConvertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /*Metodo que se encarga de convertir un datatable a JSON*/
        public static string DataTableToJSON(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(list);
        }
      
      

    }
    /*Clase estatica que contiene una funcion que me permite remover espacios en blanco en una cadena*/
    public static class Holsa{

       public static string RemoveWhitespace(this string input)
       {
           return new string(input.ToCharArray()
               .Where(c => !Char.IsWhiteSpace(c))
               .ToArray());
       }

   }
}
