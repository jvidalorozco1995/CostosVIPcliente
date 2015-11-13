<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebCostos.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="BllScriptsSyncServer/Get.js"></script>
    <script src="BllScriptsSyncServer/SyncServer.js"></script>
    <script src="BllScriptsSyncServer/BllFechasJs.js"></script>

    <script type="text/javascript">
         $(document).ready(function () {
           
             //Consumo del wServi
             Clientes = _GET("/Servicios/ProyectosWS.asmx/ListaProyectos");
             $("#CmbProyectos").append("<option value='n'>Seleccionar...</option>");
             $.each(Clientes, function (k, v) {
                 $("#CmbProyectos").append("<option value=\"" + v.Codigo+'-'+v.Filtro + "\">" + v.Proyecto + "</option>");
             })

             

             $("#btnGuardar").click(function () {
                 GuardarFechas();
             });
             
            
         });

     </script>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
        <input type="button" id="boton" value="LLAMAR" >ashahshhahs</input>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
        <input type="button" id="btnGuardar" value="Guardar" >ashahshhahs</input>
        <select  id="CmbProyectos"/>

    </div>
    </form>
</body>
</html>

