using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public class OrdenesBll
    {

        COSTOSVIPEnti db = new COSTOSVIPEnti();



       /* string sConnectionString1 = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
        //Abrir la Conexion
        WebCostos.Utilidades cn = new WebCostos.Utilidades();

        public DataTable CopiarOrdenesTemp(){
            try
            {
                SqlBulkCopy copia = new SqlBulkCopy(sConnectionString1);
                copia.BulkCopyTimeout = 900000;
                DataTable TablaCopia = ListaProyectos(2);
                copia.DestinationTableName = "OrdenesTemp";
                copia.WriteToServer(TablaCopia);
                     
                    
                return TablaCopia;
                TablaCopia.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }


     }*/


        //Mostrar Todas las Eps, Retorna una lista.
        public DataTable ListaOrdenes(int IdFecha)
        {

            try
            {
                List<OrdenesDTO> Est = new List<OrdenesDTO>();
                List<Ordenes> lst = db.Ordenes.Where(t => t.IdFecha == IdFecha).ToList();

                if (lst != null)
                {
                    Est = lst.Select(t => new OrdenesDTO
                    {
                        Id = t.Id,
                        Referencia1 = t.Referencia1,
                        Presupuesto = t.Presupuesto,
                        Cod_Unit = t.Cod_Unit,
                        Unitario = t.Unitario,
                        Cod_Insumo = t.Cod_Insumo,
                        Insumo = t.Insumo,
                        Und = t.Und,
                        Comp = t.Comp.GetValueOrDefault(0),
                        Ent = t.Ent.GetValueOrDefault(0),
                        PorEnt = t.PorEnt.GetValueOrDefault(0),
                        Fecha = t.Fecha,
                        Orden = t.Orden,
                        Tipo = t.Tipo,
                        Cod_Prov = t.Cod_Prov,
                        Proveedor = t.Proveedor,
                        VlrUnita = t.VlrUnita.GetValueOrDefault(0),
                        CostEnt = t.CostEnt.GetValueOrDefault(0),
                        Usuario = t.Usuario,
                        IdFecha = t.IdFecha,


                    }).ToList();
                }
                return ToDataTable(Est);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);

                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


        
    }
}
