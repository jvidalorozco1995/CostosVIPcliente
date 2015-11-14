using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;

namespace WebCostos
{
    public partial class WebActualizar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                //Set the session value from HiddenField
  
             
            
           }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Proyecto"] = HiddenField1.Value;
           /// ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "DoPostBack", "__doPostBack(sender, e)", true);
        
        }

      

       
        protected void BtnExportExcel_Command(object sender, CommandEventArgs e)
        {
        try
        {

         
           if (e.CommandName != "Page")
           {
               try
               {
                        
                   using (XLWorkbook wb = new XLWorkbook())
                   {

                 


                       wb.AddWorksheet(ArchivoCostosSemanaActual(int.Parse(e.CommandArgument.ToString())), "COSTOS 100%");
                       wb.AddWorksheet(ArchivoCostosPedidos(int.Parse(e.CommandArgument.ToString())), "Pedidos");
                       wb.AddWorksheet(ArchivoCostosSalidas(int.Parse(e.CommandArgument.ToString())), "Salidas");
                       wb.AddWorksheet(ArchivoCostosOrdenes(int.Parse(e.CommandArgument.ToString())), "Ordenes");
                       wb.AddWorksheet(ArchivoCostosCostoEntrado(int.Parse(e.CommandArgument.ToString())), "CostoEntrado");

                       //wb.Worksheet(1).Column("Variacion").Style.NumberFormat.SetNumberFormatId;  
                       //("A4").Value = "Decimal";

                       Response.Clear();
                       Response.Buffer = true;
                       Response.Charset = "";
                       Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                       Response.AddHeader("content-disposition", "attachment;filename=Costos100%" + HiddenField1.Value + ".xlsx");



                       using (MemoryStream MyMemoryStream = new MemoryStream())
                       {
                           wb.SaveAs(MyMemoryStream);
                           MyMemoryStream.Seek(0, SeekOrigin.Begin); // Seem to have to manually rewind stream before applying it to the 
                           MyMemoryStream.WriteTo(Response.OutputStream);
                           Response.Flush();
                           Response.End();
                       }
                   }

               }
               catch (Exception ex)
               {

                   throw ex;
               }

           }
       }
       catch (Exception ex)
       {
           throw ex;

       }
        
    }

        public DataTable ArchivoCostosOrdenes(int Fecha)
        {
            try
            {
                string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPConnectionString"].ConnectionString;
                string query = "SELECT * FROM Ordenes WHERE IdFecha='" + Fecha + "'";

                using (SqlConnection sqlConn = new SqlConnection(sConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.CommandTimeout = 900000;
                    sqlConn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ArchivoCostosSalidas(int Fecha)
        {
            try
            {
                string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPConnectionString"].ConnectionString;
                string query = "SELECT * FROM Salidas WHERE IdFecha='" + Fecha + "'";

                using (SqlConnection sqlConn = new SqlConnection(sConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.CommandTimeout = 900000;
                    sqlConn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ArchivoCostosCostoEntrado(int Fecha)
        {
            try
            {
                string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPConnectionString"].ConnectionString;
                string query = "SELECT * FROM CostoEntrado WHERE IdFecha='" + Fecha + "'";

                using (SqlConnection sqlConn = new SqlConnection(sConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.CommandTimeout = 900000;
                    sqlConn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
      
        public DataTable ArchivoCostosPedidos(int Fecha)
        {
            try
            {
                string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPConnectionString"].ConnectionString;
                string query = "SELECT * FROM Pedidos WHERE IdFecha='" + Fecha + "'";

                using (SqlConnection sqlConn = new SqlConnection(sConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.CommandTimeout = 900000;
                    sqlConn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        public DataTable ArchivoCostosSemanaActual(int Fecha)
        {
            try{
            string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPConnectionString"].ConnectionString;
            string query = "SELECT * FROM CostosPptoProg WHERE IdFecha='" + Fecha + "'";

            using (SqlConnection sqlConn = new SqlConnection(sConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, sqlConn))
            {
                cmd.CommandTimeout = 900000;
                sqlConn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }

            }
               catch (Exception ex)
               {

                   throw ex;
               }
        }

        protected void BtnActualizar_Command(object sender, CommandEventArgs e)
        {
            try
            {

                if (e.CommandName != "Page")
                {

                    //get the gridview row where the command is raised

                    GridViewRow selectedRow = ((Control)sender).Parent.NamingContainer as GridViewRow;

                    FechasBll b = new FechasBll();

                    b.actualizarfecha(int.Parse(e.CommandArgument.ToString()), "CMS");
                    GridView1.DataBind();
                    Response.Write("<script>window.alert('" + "Se ha Cambiado el Estado de Esta Fecha a Linea base" + "');</script>");
                    
                    /*selectedRow.DataBind();*/

                }
            }
            catch (Exception ex)
            {


            }
        }


        protected void SlqListaFechas_DataBinding(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "DoPostBack", "__doPostBack(sender, e)", true);
        }

       
    }
}