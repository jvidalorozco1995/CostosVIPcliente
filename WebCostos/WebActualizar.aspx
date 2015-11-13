﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebActualizar.aspx.cs" Inherits="WebCostos.WebActualizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="BllScriptsSyncServer/Get.js"></script>
    <script src="BllScriptsSyncServer/jquery.blockUI.js"></script>
    <script src="BllScriptsSyncServer/SyncServer.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="BllScriptsSyncServer/sweetalert.css" rel="stylesheet" />
    <script src="BllScriptsSyncServer/sweetalert.min.js"></script>


    <script type="text/javascript">
        
        $(document).ready(function () {
 
            //Consumo del wServi
            Clientes = _GET("Servicios/ProyectosWS.asmx/ListaProyectos");
            $("#CmbProyectos").append("<option value=''>Seleccionar...</option>");

            $.each(Clientes, function (k, v) {
                $("#CmbProyectos").append("<option value=\"" + v.Codigo + '-' + v.Filtro + "\">" + v.Proyecto + "</option>");
            })

            $(document).on('change', '#CmbProyectos', function () {
                var par = $('#CmbProyectos').val();
                var o = par.split("-");
                var Proyect = o[0];
                var fil = o[1];
                sessionStorage["Proyecto"] = Proyect;
                $('#<% =HiddenField1.ClientID %>').attr('value', Proyect);
                //  document.getElementById('<%=Button1.ClientID %>').click();
                //  document.getElementById('<%=GridView1.ClientID %>').();

            });

            $("#btnGuardar").click(function () {

                 GuardarFechas();
            });

        });

     </script>

     
    <style type="text/css">
        #CmbProyectos {
            width: 278px;
        }
    </style>

     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
     <div id="divMessage" style="display: none;">
            Please wait ....
        </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
       <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="18pt" ForeColor="#B70000" Text="Actualizar y Generar Costos"></asp:Label>
    <br />
  <div style="display:none">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
  </div>

    <br />
      
        <br />
      
        <select  id="CmbProyectos"/>

<br />

<br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
<br />
<br />
<br />
<br />
<br />
<br />
   
    </select><input type="button" id="btnGuardar" value="Guardar" /><br />
   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SlqListaFechas" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
            <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" SortExpression="Proyecto" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Excel.png"  OnCommand="BtnExportExcel_Command" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/convertirLB.gif"  OnCommand="BtnActualizar_Command" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
             </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:SqlDataSource ID="SlqListaFechas" runat="server" ConnectionString="<%$ ConnectionStrings:COSTOSVIPConnectionString %>" SelectCommand="SELECT * FROM [Fechas] WHERE ([Proyecto] = @Proyecto) ORDER BY [Fecha] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="CMS" Name="Proyecto" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

     <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>

</asp:Content>
