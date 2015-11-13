using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebCostos
{
    public partial class WebComparaciones : System.Web.UI.Page
    {
       
            decimal grdTotal = 0;
        DataTable dtVariacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scripManager = ScriptManager.GetCurrent(this.Page);

            scripManager.RegisterAsyncPostBackControl(DropDownList1);

            scripManager.RegisterAsyncPostBackControl(BtnEjecutar);
            scripManager.RegisterPostBackControl(BtnExportarExcel);


            
            if (!IsPostBack)
            {


                CargarGrilla.DataBind();
                SqlDataSource1.DataBind();
                SqlDataSource2.DataBind();
                /*LineasAgregadasSQLDATASOURCE.DataBind();
                LineasRetiradasSQLDATASOURCE.DataBind();*/

                GridView1.DataBind();
                GridView3.DataBind();
                
                UpdatePanel1.Update();
                UpdatePanel2.Update();


                UpdatePanel1.DataBind();
                UpdatePanel2.DataBind();

                BtnEjecutar_Click(sender, e);
               // litTest.Text = "No postback";


            }
            else if (Request["__EVENTARGUMENT"] == "ddlList_Changed_Or_Anything_Else_You_Might_Want_To_Key_Off_Of")
            {


             
               

               
                RadioButtonList1.SelectedValue = "1";
                Encontrar();
        
            }
            else
            {
                
            }
        }

        public class Country
        {
            public string Tipo { get; set; }

            public Country(string _Tipo)
            {

                Tipo = _Tipo;
            }
        }


        public List<string> Lista
        {
            get
            {
                if (HttpContext.Current.Session["Lista"] == null)
                {
                    HttpContext.Current.Session["Lista"] = new List<string>();
                }
                return HttpContext.Current.Session["Lista"] as List<string>;
            }
            set
            {
                HttpContext.Current.Session["Lista"] = value;
            }

        }

        protected DataTable DeleteDuplicateFromDataTable(DataTable dtDuplicate, string columnName)
        {

            try
            {
                Hashtable hashT = new Hashtable();
                ArrayList arrDuplicate = new ArrayList();
                
                foreach (DataRow row in dtDuplicate.Rows)
                {
                    if (hashT.Contains(row[columnName]))
                        arrDuplicate.Add(row);

                    else
                        hashT.Add(row[columnName], string.Empty);

                }
                foreach (DataRow row in arrDuplicate)
                   
                    dtDuplicate.Rows.Remove(row);
                   
                return dtDuplicate;
            }
            catch (Exception ex) { 
              throw ex;
            }
        }

     
        protected void ScriptManager1_AsyncPostBackError(object sender,
            AsyncPostBackErrorEventArgs e)
        {
            ToolkitScriptManager1.AsyncPostBackErrorMessage =
                "Ha ocurrido un error en la peticion: " +
                e.Exception.Message;
        }



        protected void BtnEjecutar_Click(object sender, EventArgs e)
        {
           

            // Save the customer to your data store here.
            System.Threading.Thread.Sleep(500);

            
         
    
            decimal sum = 0;
            try
            {
              
                if (String.IsNullOrEmpty(GridView1.SortExpression)) GridView1.Sort("referencia1", SortDirection.Ascending);
              
                DataView dv2Combox = (DataView)CargarGrilla.Select(DataSourceSelectArguments.Empty);
                DataTable dt2 = new DataTable();
                dt2 = dv2Combox.ToTable();

                DeleteDuplicateFromDataTable(dt2, "insutipo");

               
                DropDownList1.DataSource = dt2;
                DropDownList1.DataTextField = "insutipo";
                DropDownList1.DataValueField = "insutipo";
                DropDownList1.DataBind();

                GridView1.DataBind();

             


                compare(GridView1);
                int j = GridView1.Rows.Count;
                
             
           
                DataView dv = (DataView)CargarGrilla.Select(DataSourceSelectArguments.Empty);
                DataTable dt = new DataTable();
                dt = dv.ToTable();


                DataTable dt5 = ((DataView)this.CargarGrilla.Select(DataSourceSelectArguments.Empty)).ToTable(); // your data table
                DataView dv2 = dt5.DefaultView;
                dv2.Sort = "referencia1 desc";
                DataTable sortedDT = dv2.ToTable();
                CompararDatatable(sortedDT);


                DeleteDuplicateFromDataTable(dt, "insutipo");

             
                sum += Convert.ToDecimal((from row in sortedDT.AsEnumerable()
                                          select Convert.ToDecimal(row.Field<string>("Variacion"))).Sum());

                 Lista.Add("Total:"+sum.ToString());
                 Inicializar();
               

                
                foreach (DataRow row2 in dt.Rows)
                {

                    string ac = row2["insutipo"].ToString().Trim();

               
                   
                    decimal valor= ((from row in sortedDT.AsEnumerable()
                                                 where row.Field<string>("insutipo") == ac
                                                 select Convert.ToDecimal(row.Field<string>("Variacion"))).Sum());
                    Lista.Add(
                     ac + ":" + (from row in sortedDT.AsEnumerable()
                                                 where row.Field<string>("insutipo") == ac
                                                 select Convert.ToDecimal(row.Field<string>("Variacion"))).Sum());

                    Llenar(ac, valor);
                   

                }
                AsignarData();
                }
            catch (Exception ex)
            {
                throw ex;
            }

               }

 
   

        public void Inicializar()
        {
            dtVariacion = new DataTable();
            dtVariacion.Columns.AddRange(new DataColumn[2] { new DataColumn("Grupo", typeof(string)), new DataColumn("Variacion", typeof(decimal)) });
        
        }
        public void Llenar(string Grupo, decimal Variacion) {
            dtVariacion.Rows.Add(Grupo, Variacion);
        }

        public void VaciarData()
        {
            Inicializar();
            dtVariacion.Clear();
            GridView3.DataSource = dtVariacion;
        }
        public void AsignarData() {
            GridView3.DataSource = dtVariacion;
            GridView3.DataBind();

             
           
           
            UpdatePanel2.Update();
        }



        public void alert(string msg)
        {

            string content;
            string sMsg = msg.Replace("\n", "\\n");
            sMsg = msg.Replace("\"", "'");

            StringBuilder sb = new StringBuilder();

            sb.Append(@"<script language='javascript'>");
            sb.Append(@"alert( """ + sMsg + @""" );");
            sb.Append(@"</script>");

            content = sb.ToString();
        }


        /****************************COMPARA LA GRILLA*******************************/
        public void compare(GridView gridview1)
        {
            try
            {
                for (int currentRow = 0; currentRow < gridview1.Rows.Count; currentRow++)
                {
                    GridViewRow rowToCompare = gridview1.Rows[currentRow];
                    GridViewRow rowToCompare2 = gridview1.Rows[currentRow + 1];
                    for (int cells = 0; cells < gridview1.Rows[currentRow].Cells.Count; cells++)
                    {
                        GridViewRow row = gridview1.Rows[currentRow];
                        bool duplicateRow = true;
                        if (rowToCompare.Cells[cells].Text != rowToCompare2.Cells[cells].Text)
                        {
                            rowToCompare.Cells[cells].ForeColor = Color.OrangeRed;
                            rowToCompare.Cells[cells].BackColor = Color.LightGray;
                            rowToCompare2.Cells[cells].ForeColor = Color.OrangeRed;
                            rowToCompare2.Cells[cells].Font.Bold = true;
                            rowToCompare.Cells[cells].Font.Bold = true;


                        }
                        else if (duplicateRow)
                        {
                            rowToCompare.Cells[cells].BackColor = Color.LightGray;
                            // row.BackColor = Color.OrangeRed;
                            duplicateRow = false;
                        }

                    }
                    currentRow++;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        /**********************************************************************/


        //*Me convierte la Grilla en Datetable*/
        DataTable GetDataTable(GridView dtg)
        {

            DataTable dt = new DataTable();
            // add the columns to the datatable            
            if (dtg.HeaderRow != null)
            {

                for (int i = 0; i < dtg.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);


                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in dtg.Rows)
            {

                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {

                    if (i == 43)
                    {

                        dr[43] += Convert.ToDecimal(((Label)row.FindControl("Label1")).Text.Replace(" ", "")).ToString();
                    }
                    else
                    {
                        dr[i] = row.Cells[i].Text.Replace(" ", "");
                    }


                }

                dt.Rows.Add(dr);
            }

            //  add the footer row to the table
            if (dtg.FooterRow != null)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < dtg.FooterRow.Cells.Count; i++)
                {
                    dr[i] = dtg.FooterRow.Cells[i].Text.Replace(" ", "");
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /********************************************************************/



        public void CompararDatatable(DataTable tbl1)
        {
           /* if (tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
                return false;
            */
            try
            {  
                tbl1.Columns.Add(new DataColumn("Variacion", Type.GetType("System.String")));
                for (int i = 0; i < tbl1.Rows.Count; i++)
                {

                  

                    int d = i + 1;
                    for (int c = 0; c < tbl1.Columns.Count; c++)
                    {
                       

                        if (espar(i)) {

                            if (tbl1.Rows[i]["vlrproy"] != tbl1.Rows[d]["vlrproy"])
                            {

                                tbl1.Rows[i]["Variacion"] = (Convert.ToDecimal(tbl1.Rows[i][40]) - Convert.ToDecimal(tbl1.Rows[d][40])).ToString();
                                //tbl1.Rows[i+1]["Variacion"] = ((Convert.ToDecimal(tbl1.Rows[i][40]) - Convert.ToDecimal(tbl1.Rows[d][40]))* -1).ToString();

                            }
                        }
                        else
                        {
                            
                        }
                    }

                }
            }catch(Exception ex){
                throw ex;
            }
           
         
        }


        public bool espar(int numero) {

            if ((numero % 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        
        }

       


        protected void CmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            

                DataView dvSql = (DataView)CargarTextBox.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView drvSql in dvSql)
                {
              
                }

            
            }
            catch (Exception ex)
            {

            }
        }



        protected void BtnExportarExcel_Click(object sender, EventArgs e)
        {


            //try
            //{
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            /* Sin error */
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

         


            GridView dg5 = new GridView();
            dg5.EnableViewState = false;
  
            dg5.AllowPaging = false;
      

            DataTable dt5 = ((DataView)this.CargarGrilla.Select(DataSourceSelectArguments.Empty)).ToTable(); // your data table
            DataView dv = dt5.DefaultView;
            dv.Sort = "referencia1 desc";
            DataTable sortedDT = dv.ToTable();
            CompararDatatable(sortedDT);



            dg5.DataSource = sortedDT;
             
            dg5.DataBind();
            compare(dg5);


     

            /*AQUI ES EL CODI*/
            form.Controls.Add(GridView3);

            decimal result;
            
            for (int i = 0; i < dg5.Rows.Count; i++)
            {
                foreach (TableCell c in dg5.Rows[i].Cells)
                {

                    if (decimal.TryParse(c.Text, out result))
                    {
                        c.Text = String.Format("{0:n}", result);
                    }
                   
                }
            }
           
            form.Controls.Add(dg5);
      



            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);




            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            ///Response.ContentType = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment;filename=Archivocomparaciones.xls;");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

            GridView1.AllowPaging = true;
            GridView1.DataBind();







        
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void BtnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void BtnAgregadas_Click(object sender, EventArgs e)
        {

            try
            {
          

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "window.open('LineasAgregadas.aspx','Graph','height=400,width=500');", true);
            }
            catch (Exception ex)
            {

            }
        }

        protected void BtnRetiradas_Click(object sender, EventArgs e)
        {
            try
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "window.open('LineasRetiradas.aspx','Graph','height=400,width=500');", true);
            }
            catch (Exception ex)
            {

            }
        }

        protected void BtnCompararLineaBase_Click(object sender, EventArgs e)
        {
            try
            {
    

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "window.open('WebComparacionesLineaBase.aspx','Graph','height=400,width=500');", true);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
             
            }
            catch (Exception ex)
            {
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

          


            Response.Redirect("http://localhost:58836/Libro1.xlsm");
        }

        protected void CargarGrilla_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 300000;
        }

        protected void LineasAgregadasSQLDATASOURCE_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 300000;
        }

        protected void LineasRetiradasSQLDATASOURCE_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 300000;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }


        public void Encontrar() {

            decimal sum = 0;

            VaciarData();


            DataView dv = (DataView)CargarGrilla.Select(DataSourceSelectArguments.Empty);
            DataTable dt = new DataTable();
            dt = dv.ToTable();


            DataTable dt5 = ((DataView)this.CargarGrilla.Select(DataSourceSelectArguments.Empty)).ToTable(); // your data table
            DataView dv2 = dt5.DefaultView;
            dv2.Sort = "referencia1 desc";
            DataTable sortedDT = dv2.ToTable();
            CompararDatatable(sortedDT);


            DeleteDuplicateFromDataTable(dt, "insutipo");


            sum += Convert.ToDecimal((from row in sortedDT.AsEnumerable()
                                      select Convert.ToDecimal(row.Field<string>("Variacion"))).Sum());

            Lista.Add("Total:" + sum.ToString());
            Inicializar();



            foreach (DataRow row2 in dt.Rows)
            {

                string ac = row2["insutipo"].ToString().Trim();

                

                decimal valor = ((from row in sortedDT.AsEnumerable()
                                  where row.Field<string>("insutipo") == ac
                                  select Convert.ToDecimal(row.Field<string>("Variacion"))).Sum());

                string numero = String.Format("{0:C2}", valor);
                Lista.Add(
                 ac + ":" + (from row in sortedDT.AsEnumerable()
                             where row.Field<string>("insutipo") == ac
                             select Convert.ToDecimal(row.Field<string>("Variacion"))).Sum());

              
                Llenar(ac, valor);
               



            }

            AsignarData();

           
            GridView1.DataBind();
            

            compare(GridView1);
        
        
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            RadioButtonList1.SelectedValue = "0";
            BtnEjecutar_Click(sender,e);
        }

        protected void Ejecutar_Click(object sender, EventArgs e)
        {

        }

        protected void CmbSemanaPasada_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Encontrar();
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            Encontrar();
        }

       

        

   
      

        protected void BtnLineasAgregadas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "open('WebLineasAgregadas.aspx','NewWindow','top=0,left=0,width=800,height=600,status=yes,resizable=yes,scrollbars=yes');", true);
        }

        protected void BtnRetiradas_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "open('WebLineasRetiradas.aspx','NewWindow','top=0,left=0,width=800,height=600,status=yes,resizable=yes,scrollbars=yes');", true);

        }   
        
    }
}
        
