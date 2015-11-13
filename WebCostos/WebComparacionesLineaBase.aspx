<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebComparacionesLineaBase.aspx.cs" Inherits="WebCostos.WebComparacionesLineaBase" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
<link rel="stylesheet" href="css/principal.css" type="text/css" /> 
<style>

        #tabla{  /*padre*/
	          width: 100%;
            }
/**/
        .Grilla {
            
           overflow:scroll;
            width:85%; 
            height:700px; 
            /*display:block;*/
            /*width: 100%;*/
            float: left;
   
    /*** Sólo a efectos de visualización ***/
   
   margin: 0;
        }

        .Acciones {
            display:none;
        }

        .Grupos {
           
     float: left;
     width:9%;
    /*** Sólo a efectos de visualización ***/
  
   margin: 0;
         }

        /*body,html {
  margin:0;
  padding:0;
}*/



     #Progress
    {
        position: fixed;
        top: 39%; 
        left: 42%; 
        height:19%; 
        width:18%; 
        z-index: 100001;  
        background-color: #FFFFFF; 
        border:1px solid Gray; 
        background-image:url('images/loader.gif');
        background-repeat: no-repeat; 
        background-position:center;
    }
    #Background
    {
        position: fixed; 
        top: 0px; 
        bottom: 0px; 
        left: 0px; 
        right: 0px; 
        overflow: hidden; 
        padding: 0; 
        margin: 0; 
        background-color: #F0F0F0; 
        filter: alpha(opacity=80); 
        opacity: 0.8; 
        z-index: 100000;
    }
        



</style>

     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script type="text/javascript">


   


    </script>

    <script type="text/javascript">
        function handleDDLChange() {
            __doPostBack($('div[id$="UpdatePanel2"]').attr('id'), 'ddlList_Changed_Or_Anything_Else_You_Might_Want_To_Key_Off_Of');
            __doPostBack($('div[id$="UpdatePanel1"]').attr('id'), 'ddlList_Changed_Or_Anything_Else_You_Might_Want_To_Key_Off_Of');


        }

        $('input[id$="DropDownList1"]').change(handleDDLChange);
        $('input[id$="RadioButtonList1"]').change(handleDDLChange);


</script>

    <script type="text/javascript">
        function pageLoad() {
            Sys.WebForms.PageRequestManager.getInstance().
                add_endRequest(onEndRequest);
        }

        function onEndRequest(sender, args) {

            if (args.get_error() != null) {
                var ex = args.get_error();
                var mesg = "HttpStatusCode: " + ex.httpStatusCode;
                mesg += "\n\nName: " + ex.name;
                mesg += "\n\nMessage: " + ex.message;
                mesg += "\n\nDescription: " + ex.description;

                alert(mesg);
                args.set_errorHandled(true);
            }

        }


</script>

</head>
<body>
    <form id="form1" runat="server">
   
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" OnAsyncPostBackError="ScriptManager1_AsyncPostBackError"></asp:ToolkitScriptManager>
        <asp:Label runat="server" ID="lblactual"></asp:Label>
         <asp:Label runat="server" ID="lblpasada"></asp:Label>

    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Comparaciones Semana Actual VS Semana Linea Base"  ForeColor="#B70000" Font-Names="Calibri" style="text-align: center; align-content:center;"></asp:Label>
      </div> 
    
          <%--<a href="javascript:toggleByClass();" id="aShow">Show Text</a>--%>
                       
             <asp:LinkButton Names="Calibri" ForeColor="#B70000" ID="BtnExportarExcel" runat="server" OnClick="BtnExportarExcel_Click" Text="Exportar a Excel" Width="160px" />
             <asp:LinkButton  Names="Calibri" ForeColor="#B70000" ID="BtnLineasAgregadas" runat="server" Text="Lineas Agregadas" Width="173px" OnClick="BtnLineasAgregadas_Click" />
             <asp:LinkButton Names="Calibri" ForeColor="#B70000" ID="BtnRetiradas" runat="server" OnClick="BtnRetiradas_Click1" Text="Lineas Retiradas" />
         <br />  
           
        <div id="Grilla" class="Grilla">
           
     
             
               <asp:UpdatePanel  Names="Calibri" ForeColor="#B70000" ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                     <div style="display:none">
                                    <asp:Button ID="BtnEjecutar" runat="server" OnClick="BtnEjecutar_Click" Text="Ejecutar" />
                                  </div>

           
                    <caption>
                     
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="CargarGrilla" PageSize="1000" AllowSorting="True" Font-Names="Calibri" Font-Size="12pt" Width="500px" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" EmptyDataText="No hubo ninguna variación en estas fechas">
                                       <Columns>
                                        <asp:BoundField DataField="origen" HeaderText="Origen" ReadOnly="True" SortExpression="origen" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Column1" HeaderText="Fecha" ReadOnly="True" SortExpression="Column1" >
                                       
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="referencia1" HeaderText="Referencia1" ReadOnly="True" SortExpression="referencia1" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="referencia2" HeaderText="Referencia2" ReadOnly="True" SortExpression="referencia2" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="referencia3" HeaderText="Referencia3" ReadOnly="True" SortExpression="referencia3" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="presupuesto" HeaderText="Presupuesto" ReadOnly="True" SortExpression="presupuesto" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="codcapi" HeaderText="Codcapi" ReadOnly="True" SortExpression="codcapi" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="capitulo" HeaderText="Capitulo" ReadOnly="True" SortExpression="capitulo" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="codunit" HeaderText="Codunit" ReadOnly="True" SortExpression="codunit" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="unitario" HeaderText="Unitario" ReadOnly="True" SortExpression="unitario" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="undunita" HeaderText="Undunita" ReadOnly="True" SortExpression="undunita" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cantxppto" HeaderText="Cantxppto" ReadOnly="True" SortExpression="cantxppto" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="codinsu" HeaderText="Codinsu" ReadOnly="True" SortExpression="codinsu" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="insutipo" HeaderText="Insutipo" ReadOnly="True" SortExpression="insutipo" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="insumo" HeaderText="Insumo" ReadOnly="True" SortExpression="insumo" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="unidinsu" HeaderText="Unidinsu" ReadOnly="True" SortExpression="unidinsu" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ctrlinven" HeaderText="Ctrlinven" ReadOnly="True" SortExpression="ctrlinven" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="validación" HeaderText="Validación" ReadOnly="True" SortExpression="validación" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="precioppto" HeaderText="Precioppto" ReadOnly="True" SortExpression="precioppto" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="consumounitario" HeaderText="Consumounitario" ReadOnly="True" SortExpression="consumounitario" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="consumototal" HeaderText="Consumototal" ReadOnly="True" SortExpression="consumototal" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="adic" HeaderText="adic" ReadOnly="True" SortExpression="adic" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="precioaut" HeaderText="Precioaut" ReadOnly="True" SortExpression="precioaut" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PrecioCompra" HeaderText="PrecioCompra" ReadOnly="True" SortExpression="PrecioCompra" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PrecioEntrado" HeaderText="PrecioEntrado" ReadOnly="True" SortExpression="PrecioEntrado" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ped" HeaderText="Ped" ReadOnly="True" SortExpression="Ped" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="aprob" HeaderText="Aprob" ReadOnly="True" SortExpression="aprob" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="comp" HeaderText="Comp" ReadOnly="True" SortExpression="comp" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ent" HeaderText="Ent" ReadOnly="True" SortExpression="ent" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sali" HeaderText="Sali" ReadOnly="True" SortExpression="sali" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="traslado" HeaderText="Traslado" ReadOnly="True" SortExpression="traslado" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="xcomp" HeaderText="Xcomp" ReadOnly="True" SortExpression="xcomp" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="xent" HeaderText="Xent" ReadOnly="True" SortExpression="xent" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="saldoxunit" HeaderText="Saldoxunit" ReadOnly="True" SortExpression="saldoxunit" DataFormatString="{0:n}" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SaldoXppto" HeaderText="SaldoXppto" ReadOnly="True" SortExpression="SaldoXppto" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vlrEnt" HeaderText="VlrEnt" ReadOnly="True" SortExpression="vlrEnt" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vlrEnttraslado" HeaderText="VlrEnttraslado" ReadOnly="True" SortExpression="vlrEnttraslado" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="VlrCompradoxent" HeaderText="VlrCompradoxent" ReadOnly="True" SortExpression="VlrCompradoxent" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vlrxcomp" HeaderText="vlrxcomp" ReadOnly="True" SortExpression="vlrxcomp" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="VlrTraslado" HeaderText="VlrTraslado" ReadOnly="True" SortExpression="VlrTraslado" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vlrproy" HeaderText="Vlrproy" ReadOnly="True" SortExpression="vlrproy" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Vlrini" HeaderText="Vlrini" ReadOnly="True" SortExpression="Vlrini" DataFormatString="{0:n}" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vlrejec" HeaderText="Vlrejec" ReadOnly="True" SortExpression="vlrejec" >
                                        <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                          
                    </caption>
       
                    </ContentTemplate>
                      <Triggers>
                            
                            <asp:AsyncPostBackTrigger ControlID="BtnEjecutar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                 <%--      <asp:AsyncPostBackTrigger ControlID="BtnAgregadas" EventName="Click" />--%>
                            <asp:PostBackTrigger ControlID="BtnExportarExcel" />
                          
                  
                        </Triggers>
                </asp:UpdatePanel>

    </div>

        <div id="Grupos" class="Grupos">
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/filter.gif" OnClick="ImageButton1_Click"  />
                <br />
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" DataTextField="insutipo" DataValueField="insutipo" Height="16px" Width="162px"  onchange="handleDDLChange()" >
                        </asp:DropDownList>
                <asp:GridView ID="GridView3" runat="server"></asp:GridView>

                    <div style="display:none">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="true" onchange="handleDDLChange()" >
                        <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        </asp:RadioButtonList>
                        </div>
                    </ContentTemplate>
                <Triggers>
                            
                            <asp:AsyncPostBackTrigger ControlID="BtnEjecutar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged"  />
                        </Triggers>
          </asp:UpdatePanel>
            
                        
                               
                      </div>


      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:COSTOSVIPConnectionString %>" SelectCommand="SELECT * FROM [Vistadepruebaporfavoreliminamecuandotermines]"></asp:SqlDataSource>
            
               

                    <asp:SqlDataSource ID="CargarTextBox" runat="server" ConnectionString="<%$ ConnectionStrings:COSTOSVIPConnectionString %>" SelectCommand="SELECT [Id], [Fecha], [Proyecto], [Tipo] FROM [Fechas] WHERE (([Proyecto] = @Proyecto) AND ([Tipo] = @Tipo))">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="CMS" Name="Proyecto" Type="String" />
                            <asp:Parameter DefaultValue="True" Name="Tipo" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="CargarProyecto" runat="server" ConnectionString="<%$ ConnectionStrings:COSTOSVIPConnectionString %>" SelectCommand="SELECT [Codigo], [Proyecto], [Filtro] FROM [Proyectos]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:COSTOSVIPConnectionString %>" SelectCommand="SELECT [Id], [Fecha], [Proyecto], [Tipo] FROM [Fechas] WHERE ([Tipo] = @Tipo) and Proyecto= @Proyecto order by Fecha DESC">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="False" Name="Tipo" Type="String" />
                            <asp:Parameter DefaultValue="CMS" Name="Proyecto" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
        <br />
                    
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
      
   
    <asp:SqlDataSource ID="CargarGrilla" runat="server" ConnectionString="<%$ ConnectionStrings:COSTOSVIPConnectionString %>" SelectCommand="ComparacionesModificaciones" SelectCommandType="StoredProcedure" OnSelecting="CargarGrilla_Selecting">
            <SelectParameters>
                
                <%--<asp:ControlParameter ControlID="RadioButtonList1" DefaultValue="0" Name="Opcion" PropertyName="SelectedValue" Type="Int32" />
                
                <asp:ControlParameter ControlID="DropDownList1" Name="Grupo" PropertyName="SelectedValue" Type="String" DefaultValue="CTC" />--%>
                <asp:SessionParameter Name="Fecha1" SessionField="FechaActual" Type="String"  />
                <asp:SessionParameter Name="Fecha2" SessionField="FechaLineaBase" Type="String" />
                <asp:ControlParameter ControlID="RadioButtonList1" Name="Opcion" PropertyName="SelectedValue" Type="Int32" DefaultValue="0" />
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="CTC" Name="Grupo" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
          </asp:SqlDataSource>
        
         

        </div>
   
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
       <div id="Background">

            </div>
        <div id="Progress">
                <h7> <p style="text-align:center"> <b>Procesando Datos, Espere Por Favor... </b> </p> </h7>
            </div>
            
        </ProgressTemplate>
    </asp:UpdateProgress>


    

    </form>
</body>
</html>