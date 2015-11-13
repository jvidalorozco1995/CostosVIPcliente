﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeCostoEntrado.aspx.cs" Inherits="WebCostos.InformeCostoEntrado" %>

<!DOCTYPE html>


<html ng-app="serviceCostos">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/angular-i18n/1.4.3/angular-locale_es-co.js"></script>

    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="Scripts/FileSaver.js"></script>
    <script src="Scripts/angular.js"></script>
    <style>
        .modal-header, .close {
            background-color: #B70000;
            color: white !important;
            text-align: center;
            font-size: 30px;
        }

        .modal-footer {
            background-color: #f9f9f9;
        }
    </style>
</head>
<body>
<div  ng-controller="CostosController" data-ng-init="init()">
 <div id="Contenido" style="display:none">
        <div class="h1 text-center">
            <h1>INFORME DE COSTOS</h1>
        </div>
        <br />
     <h3>Consolidado del Proyecto</h3>
    <div class="form-inline">
            <label>Proyecto</label><p style="display:inline"> {{Proy.Proyecto}}</p>
            <label>Semana Actual</label> <p style="display:inline">{{SemanaA.Fecha}}</p>
            <label>Semana Pasada</label> <p style="display:inline">{{SemanaP.Fecha}}</p>
            <label>Semana Linea Base</label><p style="display:inline">{{SemanaL.Fecha}}</p>
        </div>
       
     <form runat="server">
          <asp:ScriptManager runat="server" ID="sm">
 </asp:ScriptManager>
         <asp:updatepanel runat="server">
 <ContentTemplate>
     <button class="btn btn-success" ng-click="Exportar();">Exportar a excel</button>
<asp:Button class="btn btn-success" ID="Button1" runat="server"  Text="Variaciones semana actual vs semana pasada" OnClick="Button1_Click" autopostback="false" />
     <asp:Button class="btn btn-success" ID="Button2" runat="server"  Text="Variaciones semana actual vs semana linea base" OnClick="Button2_Click" autopostback="false" />

 </ContentTemplate>
 </asp:updatepanel>
       
           <asp:HiddenField ID="HiddenField1"  runat="server" />
           <asp:HiddenField ID="HiddenField2"  runat="server" />
           <asp:HiddenField ID="HiddenField3"  runat="server" />

     </form>

        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr class="success">
                    <th>Presupuesto</th>
                  
                    <th>Vlr Causado</th>
                    <th>Vlr Ejecutado</th>
                    <th>Causado</th>
                    <th>Ejecutado</th>
                    <th>Vlr mt2 Vivienda</th>
                    <th>Area</th>
                    <th>Nviviendas</th>
                    <th>Vlr x vivienda</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="i in TotalGlobal">
                    <td class="col-md-2">
                        {{i.Presupuesto }}
                    </td>
                    
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrmt2vivienda | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrxvivienda | euro}}
                    </td>
                </tr>
            </tbody>
        </table>
        <h3>Consolidado por semanas</h3>
        <table class="table table-striped table-bordered table-hover" style="width:27%">

            <thead>
                <tr>
                    <th class="col-md-3">Costos Directos</th>
                    <th>Actual</th>
                    <th>Anterior</th>
                    <th>Linea Base</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="d in ConCostosDirectosSemanaActual">
                    <th class="success"> Vlr Causado</th>
                    <td class="col-md-1" style="text-align:right;">{{d.VlrCausado | euro }}</td>
                    <td ng-repeat="i in ConCostosDirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{d.VlrCausado - i.VlrCausado | euro }}</td>
                    <td ng-repeat="i in ConCostosDirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{d.VlrCausado - i.VlrCausado | euro }}</td>

                <tr ng-repeat="d in ConCostosDirectosSemanaActual">
                    <th class="success"> Vlr mt2 vivienda</th>
                    <td class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Area  | euro }}</td>
                    <td ng-repeat="i in ConCostosDirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Area - i.VlrCausado/i.Area | euro }}</td>
                    <td ng-repeat="i in ConCostosDirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Area - i.VlrCausado/i.Area | euro }}</td>

                <tr ng-repeat="d in ConCostosDirectosSemanaActual">
                    <th class="success"> Vlr x vivienda</th>
                    <td class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Nviviendas | euro }}</td>
                    <td ng-repeat="i in ConCostosDirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Nviviendas - i.VlrCausado/i.Nviviendas| euro }}</td>
                    <td ng-repeat="i in ConCostosDirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Nviviendas - i.VlrCausado/i.Nviviendas | euro }}</td>
                </tr>

            </tbody>
        </table>


        <table class="table table-striped table-bordered table-hover" style="width:27%">

            <thead>
                <tr>
                    <th class="col-md-3">Costos Indirectos</th>
                    <th>Actual</th>
                    <th>Anterior</th>
                    <th>Linea Base</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="d in ConCostosIndirectosSemanaActual">
                    <th class="success"> Vlr Causado</th>
                    <td class="col-md-1" style="text-align:right;">{{d.VlrCausado | euro }} </td>
                    <td ng-repeat="i in ConCostosIndirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{d.VlrCausado - i.VlrCausado | euro }}</td>
                    <td ng-repeat="i in ConCostosIndirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{d.VlrCausado - i.VlrCausado | euro }}</td>


                <tr ng-repeat="d in ConCostosIndirectosSemanaActual">
                    <th class="success"> Vlr mt2 vivienda</th>
                    <td class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Area  | euro }}</td>
                    <td ng-repeat="i in ConCostosIndirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Area - i.VlrCausado/i.Area  | euro }}</td>
                    <td ng-repeat="i in ConCostosIndirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Area - i.VlrCausado/i.Area  | euro }}</td>


                <tr ng-repeat="d in ConCostosIndirectosSemanaActual">
                    <th class="success"> Vlr x vivienda</th>
                    <td class="col-md-1" style="text-align:right;">{{d.VlrCausado/d.Nviviendas | euro }}</td>
                    <td ng-repeat="i in ConCostosIndirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{d.VlrCausado/i.Nviviendas  - i.VlrCausado/i.Nviviendas | euro }}</td>
                    <td ng-repeat="i in ConCostosIndirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{d.VlrCausado/i.Nviviendas  - i.VlrCausado/i.Nviviendas | euro }}</td>

                </tr>
            </tbody>
        </table>
        <!--****************************************************************************-->
        <h3>Costos Directos</h3>
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr class="success">
                    <th>Presupuesto</th>
                   
                    <th>Vlr Causado</th>
                    <th>Vlr Ejecutado</th>
                    <th>Causado</th>
                    <th>Ejecutado</th>
                    <th>Vlr mt2 Vivienda</th>
                    <th>Area</th>
                    <th>Nviviendas</th>
                    <th>Vlr x vivienda</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="i in ConCostosDirectosSemanaActual">
                    <td class="col-md-2">
                        {{i.Presupuesto }}
                    </td>
                  
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                       {{i.VlrCausado / i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                       {{i.VlrCausado / i.Nviviendas | euro}}
                    </td>
                </tr>
            </tbody>
        </table>
        <h3>Consolidado</h3>
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr class="success">
                    <th>Presupuesto</th>
                    <th>Vlr Causado</th>
                    <th>Vlr Ejecutado</th>
                    <th>Causado</th>
                    <th>Ejecutado</th>
                    <th>Vlr mt2 Vivienda</th>
                    <th>Area</th>
                    <th>Nviviendas</th>
                    <th>Vlr x vivienda</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="i in GruCostosDirectosSemanaActual">
                    <td class="col-md-2">
                        {{i.Presupuesto }}
                    </td>
                   
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                       {{i.VlrCausado / i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                       {{i.VlrCausado / i.Nviviendas | euro}}
                    </td>
                </tr>
            </tbody>
        </table>
        <h4>Detalles</h4>
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr class="success">
                    <th>Presupuesto</th>
                    <th>Vlr Causado</th>
                    <th>Vlr Ejecutado</th>
                    <th>Causado</th>
                    <th>Ejecutado</th>
                    <th>Vlr mt2 Vivienda</th>
                    <th>Area</th>
                    <th>Nviviendas</th>
                    <th>Vlr x vivienda</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="i in DetCostosDirectosSemanaActual">
                    <td class="col-md-2">
                        {{i.Presupuesto }}
                    </td>
                   
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado / i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                       {{i.VlrCausado / i.Nviviendas | euro}}
                    </td>
                </tr>
            </tbody>
        </table>

        <!--****************************************************************************-->

        <h3>Costos Indirectos</h3>
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr class="success">
                    <th></th>
                    <th>Vlr Causado</th>
                    <th>Vlr Ejecutado</th>
                    <th>Causado</th>
                    <th>Ejecutado</th>
                    <th>Vlr mt2 Vivienda</th>
                    <th>Area</th>
                    <th>Nviviendas</th>
                    <th>Vlr x vivienda</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="i in ConCostosIndirectosSemanaActual">
                    <td class="col-md-2"></td>
                  
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado / i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                       {{i.VlrCausado / i.Nviviendas | euro}}
                    </td>
                </tr>
            </tbody>
        </table>
        <h4>Consolidado</h4>
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr class="success">
                    <th>Tipo</th>
                    <th>Vlr Causado</th>
                    <th>Vlr Ejecutado</th>
                    <th>Causado</th>
                    <th>Ejecutado</th>
                    <th>Vlr mt2 Vivienda</th>
                    <th>Area</th>
                    <th>Nviviendas</th>
                    <th>Vlr x vivienda</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="i in GruCostosIndirectosSemanaActual">
                    <td class="col-md-2">
                        {{i.Presupuesto }}
                    </td>
                   
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado / i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado / i.Nviviendas | euro}}
                    </td>
                </tr>
            </tbody>
        </table>
        <h4>Detalles</h4>
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr class="info">
                    <th>Presupuesto</th>
                    <th>Vlr Causado</th>
                    <th>Vlr Ejecutado</th>
                    <th>Causado</th>
                    <th>Ejecutado</th>
                    <th>Vlr mt2 Vivienda</th>
                    <th>Area</th>
                    <th>Nviviendas</th>
                    <th>Vlr x vivienda</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="i in DetCostosIndirectosSemanaActual">
                    <td class="col-md-2">
                        {{i.Capitulo }}
                    </td>
                   
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado / i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Area | euro}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado / i.Nviviendas | euro}}
                    </td>
                </tr>
            </tbody>
        </table>

   
  </div>



        <!-- Modal fechas escoger -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" style="padding:35px 50px;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4><span class="glyphicon glyphicon-folder-open"></span> Fechas para el Informe de costos</h4>
                    </div>
                    <div class="modal-body" style="padding:40px 50px;">
                        <form role="form">
                            <div class="form-group">
                                <label for="cmbproy">Proyecto</label>
                                <select class="form-control" id="cmbproy" ng-model="Proy" ng-options="proyecto.Proyecto for proyecto in Proyectos" ng-change="cfechas()"></select>
                            </div>
                            <div class="form-group">
                                <label for="cmbsemanaactu">Semana Actual</label>
                                <select class="form-control" id="cmbsemanaactu" ng-model="SemanaA" ng-value={{SemanaA.Id}} ng-options="fechas.Fecha for fechas in Fechas"></select>
                            </div>
                            <div class="form-group">
                                <label for="cmbsemanaactu">Semana Pasada</label>
                                <select class="form-control" id="cmbsemanapas" ng-model="SemanaP" ng-value={{SemanaP.Id}} ng-options="fechas.Fecha for fechas in Fechas"></select>
                             </div>
                            <div class="form-group">
                                <label for="cmblineabase">Linea Base</label>
                                <select disabled class="form-control" id="cmblineabase" ng-model="SemanaL" ng-value={{SemanaL.Id}} ng-options="fechas.Fecha for fechas in FechasLineaBase"></select>
                             </div>
                             <button data-dismiss="modal" id="BtnGenerar" class="btn btn-success" ng-click="Click();">Generar Informe</button>
                            <a  id="BtnAtras" class="btn btn-danger" href="WebActualizar.aspx">Atras</a>
                            </form>
                       </div>
                    <div class="modal-footer">

                    </div>
                </div>
               
               
             
            </div>
        </div>
       </div>
    </div>
    <script>
        $(document).ready(function () {
            $("#myModal").modal();
            $("#BtnGenerar").click(function () {

                document.getElementById('<%=HiddenField1.ClientID%>').value = $("#cmbsemanaactu").attr("ng-value");
                document.getElementById('<%=HiddenField2.ClientID%>').value = $("#cmbsemanapas").attr("ng-value");
                document.getElementById('<%=HiddenField3.ClientID%>').value = $("#cmblineabase").attr("ng-value");

            });
            //  $("#Contenido").modal();
        });

        function llamarNuevaVentana() {

            var win = window.open("WebComparaciones.aspx", '1366002941508'/*, 'width=500,height=200,left=375,top=330'*/);


        }

    </script>
    <script src="Scripts/loading-bar.min.js"></script>
    <link href="Content/loading-bar.min.css" rel="stylesheet" />
    <script src="BllScriptsSyncServer/App/AppController.js"></script>

</html>
