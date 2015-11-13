<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebInforme.aspx.cs" Inherits="WebCostos.WebInforme" %>

<!DOCTYPE html>

<html ng-app="serviceCostos">
<head runat="server">
    <title></title>
     <script src="../../../../../../../Costos/Scripts/FileSaver.js"></script>
     <script src="../../../../../../../../Costos/Scripts/angular.min.js"></script>
     <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
   <form id="form1">
    <div>
        <div ng-controller="CostosController" data-ng-init="init()" id="exportable">
            
            <div class="h1 text-center">
                <h1>INFORME DE COSTOS</h1>
            </div>
          <br />

          <div class="row">
                <div class="col-lg-2" >
              

                 <label> Proyecto</label>
                 <select class="form-control" ng-model="Proy" ng-options="proyecto.Proyecto for proyecto in Proyectos" ng-change="cfechas()">
                 </select>
                <!-- {{Proy}}-->
                  <label> Semana Actual</label>
                 <select class="form-control" ng-model="SemanaA" ng-options="fechas.Fecha for fechas in Fechas">
                 </select>
                   <!--{{ddlFruits}}-->
                  <label> Semana Pasada</label>
                 <select class="form-control" ng-model="SemanaP" ng-options="fechas.Fecha for fechas in Fechas">
                 </select>
                  <!-- {{ddlFruits3}}-->

                  <label> Semana Linea Base</label>
                 <select disabled class="form-control" ng-model="SemanaL" ng-options="fechas.Fecha for fechas in FechasLineaBase">
                 </select>
                  <!-- {{ddlFruits2}}-->

             
                   </div>
                <h1>
                <button class="btn btn-success"  ng-click="Click();">Ejecutar</button>
                    </h1>
                 <h1>
                <button class="btn btn-success"  ng-click="Exportar();">Exportar a excel</button>
                    </h1>
            </div>

         <h3>Consolidado del Proyecto</h3>
          <table class="table table-striped table-bordered table-hover">
             <thead>
                <tr class="success">
                    <th>Presupuesto</th>
                    <th>Vlrproy</th>
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
                        {{i.Vlrproy | currency}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrmt2vivienda | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Area | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrxvivienda | currency}}
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
              <tr ng-repeat="i in ConCostosDirectosSemanaActual">
                      <th class="success"> Vlr Proy</th>
                      <td class="col-md-1" style="text-align:right;">{{i.Vlrproy | currency }}</td>
                      <td ng-repeat="i in ConCostosDirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{i.Vlrproy | currency }}</td> 
                      <td ng-repeat="i in ConCostosDirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{i.Vlrproy | currency }}</td>

                   <tr ng-repeat="i in ConCostosDirectosSemanaActual">
                      <th class="success"> Vlr mt2 vivienda</th>
                      <td  class="col-md-1" style="text-align:right;">{{i.Vlrmt2vivienda | currency }}</td>
                      <td ng-repeat="i in ConCostosDirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{i.Vlrmt2vivienda | currency }}</td> 
                      <td ng-repeat="i in ConCostosDirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{i.Vlrmt2vivienda | currency }}</td> 

                  <tr ng-repeat="i in ConCostosDirectosSemanaActual">
                      <th class="success"> Vlr x vivienda</th>
                      <td class="col-md-1" style="text-align:right;">{{i.Vlrxvivienda | currency }}</td>
                      <td ng-repeat="i in ConCostosDirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{i.Vlrxvivienda | currency }}</td> 
                      <td ng-repeat="i in ConCostosDirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{i.Vlrxvivienda | currency }}</td> 
                   </tr>
                 
               </tbody>
          </table>

         
         <table class="table table-striped table-bordered table-hover" style="width:27%">
            
               <thead>
                   <tr >
                      <th class="col-md-3">Costos Indirectos</th>
                      <th>Actual</th>
                      <th>Anterior</th>
                      <th>Linea Base</th>
                   </tr>
              </thead>
             <tbody>
              <tr ng-repeat="i in ConCostosIndirectosSemanaActual">
                      <th class="success"> Vlr Proy</th>
                      <td class="col-md-1" style="text-align:right;">{{i.Vlrproy | currency }}</td>
                      <td ng-repeat="i in ConCostosIndirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{i.Vlrproy | currency }}</td> 
                      <td ng-repeat="i in ConCostosIndirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{i.Vlrproy | currency }}</td> 
                      

                   <tr ng-repeat="i in ConCostosIndirectosSemanaActual">
                      <th class="success"> Vlr mt2 vivienda</th>
                      <td  class="col-md-1" style="text-align:right;">{{i.Vlrmt2vivienda | currency }}</td>
                      <td ng-repeat="i in ConCostosIndirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{i.Vlrmt2vivienda | currency }}</td> 
                      <td ng-repeat="i in ConCostosIndirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{i.Vlrmt2vivienda | currency }}</td> 
                   

                  <tr ng-repeat="i in ConCostosIndirectosSemanaActual">
                      <th class="success"> Vlr x vivienda</th>
                      <td class="col-md-1" style="text-align:right;">{{i.Vlrxvivienda | currency }}</td>
                      <td ng-repeat="i in ConCostosIndirectosSemanaPasada" class="col-md-1" style="text-align:right;">{{i.Vlrxvivienda | currency }}</td> 
                      <td ng-repeat="i in ConCostosIndirectosSemanaLineaBase" class="col-md-1" style="text-align:right;">{{i.Vlrxvivienda | currency }}</td> 
                   
                   </tr>
               </tbody>
          </table>
        <!--****************************************************************************-->
         <h3>Costos Directos</h3>
         <table class="table table-striped table-bordered table-hover">
             <thead>
                <tr class="success">
                    <th>Presupuesto</th>
                    <th>Vlrproy</th>
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
                        {{i.Vlrproy | currency}}
                    </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrmt2vivienda | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Area | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrxvivienda | currency}}
                   </td>
                </tr>
               </tbody>
           </table>
        <h3>Consolidado</h3>
         <table class="table table-striped table-bordered table-hover">
             <thead>
                <tr class="success">
                    <th>Presupuesto</th>
                    <th>Vlrproy</th>
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
                        {{i.Vlrproy | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrmt2vivienda | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Area | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrxvivienda | currency}}
                   </td>
                </tr>
               </tbody>
           </table>
        <h4>Detalles</h4>   
         <table class="table table-striped table-bordered table-hover">
             <thead>
                <tr class="success">
                    <th>Presupuesto</th>
                    <th>Vlrproy</th>
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
                        {{i.Vlrproy | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrmt2vivienda | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Area | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrxvivienda | currency}}
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
                    <th>Vlrproy</th>
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
                    <td class="col-md-2">
                      
                    </td>
                    <td  style="text-align:right;" class="col-md-1">
                        {{i.Vlrproy | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrmt2vivienda | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Area | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrxvivienda | currency}}
                   </td>
                </tr>
               </tbody>
           </table>
        <h4>Consolidado</h4>  
         <table class="table table-striped table-bordered table-hover">
             <thead>
                <tr class="success">
                    <th>Tipo</th>
                    <th>Vlrproy</th>
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
                        {{i.Vlrproy | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrmt2vivienda | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Area | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrxvivienda | currency}}
                   </td>
                </tr>
               </tbody>
           </table>   
         <h4>Detalles</h4>   
         <table class="table table-striped table-bordered table-hover">
             <thead>
                <tr class="panel panel-info">
                    <th>Presupuesto</th>
                    <th>Vlrproy</th>
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
                        {{i.Vlrproy | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.VlrCausado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrejecutado | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Causado*100  | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Ejecutado*100 | percentage:100}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrmt2vivienda | currency}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Area | currency}}
                   </td>
                    <td style="text-align:right;" class="col-md-1">
                        {{i.Nviviendas}}
                   </td>
                     <td style="text-align:right;" class="col-md-1">
                        {{i.Vlrxvivienda | currency}}
                   </td>
                </tr>
               </tbody>
           </table>

        </div>
        <br />
    </div>
       <script  type="text/javascript">


       </script>
        <script src="BllScriptsSyncServer/App/AppController.js"></script>
    </form>
</body>
</html>
