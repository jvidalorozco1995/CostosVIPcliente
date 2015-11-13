using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCostos
{
    public partial class InformeCostoEntrado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // Find the last occurrence of N.
            int index1 = HiddenField1.Value.ToString().LastIndexOf(':') + 1;
            if (index1 != -1)
            {

                Session["FechaActual"] = Convert.ToInt32(HiddenField1.Value.ToString().Substring(index1));

            }

            int index2 = HiddenField2.Value.ToString().LastIndexOf(':') + 1;
            if (index2 != -1)
            {
                Session["FechaPasada"] = Convert.ToInt32(HiddenField2.Value.ToString().Substring(index2));
            }



            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "open('WebComparaciones.aspx','NewWindow','top=0,left=0,width=800,height=600,status=yes,resizable=yes,scrollbars=yes');", true);

        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            // Find the last occurrence of N.
            int index1 = HiddenField1.Value.ToString().LastIndexOf(':') + 1;
            if (index1 != -1)
            {

                Session["FechaActual"] = Convert.ToInt32(HiddenField1.Value.ToString().Substring(index1));

            }


            int index3 = HiddenField3.Value.ToString().LastIndexOf(':') + 1;
            if (index3 != -1)
            {
                Session["FechaLineaBase"] = Convert.ToInt32(HiddenField3.Value.ToString().Substring(index3));
            }


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "open('WebComparacionesLineaBase.aspx','NewWindow','top=0,left=0,width=800,height=600,status=yes,resizable=yes,scrollbars=yes');", true);

        }
    }
}